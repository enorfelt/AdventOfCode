using System.Numerics;
using System.Text;

namespace AdventOfCode.Day15;

public record struct Coords(int X, int Y)
{
	public int DistanceTo(Coords coords)
	{
		return Math.Abs(X - coords.X) + Math.Abs(Y - coords.Y);
	}
}
public class Beacon
{
	public Beacon(Coords coords)
	{
		Coords = coords;
	}

	public Coords Coords { get; }

	public override string ToString()
	{
		return "B";
	}

	public override bool Equals(object? obj)
	{
		return obj is Beacon beacon &&
			   EqualityComparer<Coords>.Default.Equals(Coords, beacon.Coords);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Coords);
	}
}

public class Sensor
{
	public Sensor(Coords coords)
	{
		Coords = coords;
	}

	public Coords Coords { get; }
	required public Beacon ClosestBeacon { get; init; }
	public int DistanceToBeacon => Math.Abs(Coords.X - ClosestBeacon.Coords.X) + Math.Abs(Coords.Y - ClosestBeacon.Coords.Y);

	public override string ToString()
	{
		return "S";
	}

	public override bool Equals(object? obj)
	{
		return obj is Sensor sensor &&
			   EqualityComparer<Coords>.Default.Equals(Coords, sensor.Coords);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Coords);
	}
}
public class Part1
{
	public static int Run(string[] input, int rowToTest)
	{
		var sensors = new HashSet<Sensor>();
		var beacons = new HashSet<Beacon>();
		foreach (var line in input)
		{
			(Coords sensorCoords, Coords beaconCoords) = line.Split(" ") switch
			{
				[_, _, var sX, var sY, .., var bX, var bY] =>
					(new Coords(int.Parse(sX[2..^1]), int.Parse(sY[2..^1])), new Coords(int.Parse(bX[2..^1]), int.Parse(bY[2..]))),
				_ => throw new Exception("Format not supported")
			};
			var beacon = new Beacon(beaconCoords);
			sensors.Add(new Sensor(sensorCoords)
			{
				ClosestBeacon = beacon
			}); ;
			beacons.Add(beacon);
		}

		var minX = Math.Min(sensors.Min(s => s.Coords.X), beacons.Min(b => b.Coords.X));
		var maxX = Math.Max(sensors.Max(s => s.Coords.X), beacons.Max(b => b.Coords.X));

		var noneBeaconLocation = new HashSet<Coords>();
		var beaconOnRow = new HashSet<Coords>();

		foreach (var sensor in sensors)
		{
			var distanceToRow = Math.Abs(sensor.Coords.Y - rowToTest);
			var dist = sensor.DistanceToBeacon - distanceToRow;
			for (var i = 0; i <= dist; i++)
			{
				noneBeaconLocation.Add(new(sensor.Coords.X - i, rowToTest));
				noneBeaconLocation.Add(new(sensor.Coords.X + i, rowToTest));
			}

			if (sensor.ClosestBeacon.Coords.Y == rowToTest)
			{
				beaconOnRow.Add(sensor.ClosestBeacon.Coords);
			}
		}

		//Print(sensors, beacons, noneBeaconLocation);

		return noneBeaconLocation.Count - beaconOnRow.Count;
	}

	private static void Print(HashSet<Sensor> sensors, HashSet<Beacon> beacons, HashSet<Coords> noneBeaconLocation)
	{
		var minX = Math.Min(sensors.Min(s => s.Coords.X), beacons.Min(b => b.Coords.X));
		var maxX = Math.Max(sensors.Max(s => s.Coords.X), beacons.Max(b => b.Coords.X));
		var minY = Math.Min(sensors.Min(s => s.Coords.Y), beacons.Min(b => b.Coords.Y));
		var maxY = Math.Max(sensors.Max(s => s.Coords.Y), beacons.Max(b => b.Coords.Y));
		var sb = new StringBuilder();
		for (var y = minY; y < maxY; y++)
		{
			for (var x = minX; x < maxX; x++)
			{
				var coords = new Coords(x, y);
				var sensor = sensors.FirstOrDefault(s => s.Coords == coords);
				if (sensor is not null)
				{
					sb.Append(sensor);
				}
				else if (beacons.TryGetValue(new(coords), out var beacon))
				{
					sb.Append(beacon);
				}
				else if (noneBeaconLocation.TryGetValue(new(x, y), out var position))
				{
					sb.Append("#");
				}
				else
				{
					sb.Append(".");
				}
			}
			sb.Append("\n");
		}

		Console.WriteLine(sb.ToString());
	}
}

public class Part2
{
	public static BigInteger Run(string[] input, int searchSpace)
	{
		var sensors = new HashSet<Sensor>();
		var beacons = new HashSet<Beacon>();
		foreach (var line in input)
		{
			(Coords sensorCoords, Coords beaconCoords) = line.Split(" ") switch
			{
				[_, _, var sX, var sY, .., var bX, var bY] =>
					(new Coords(int.Parse(sX[2..^1]), int.Parse(sY[2..^1])), new Coords(int.Parse(bX[2..^1]), int.Parse(bY[2..]))),
				_ => throw new Exception("Format not supported")
			};
			var beacon = new Beacon(beaconCoords);
			sensors.Add(new Sensor(sensorCoords)
			{
				ClosestBeacon = beacon
			}); ;
			beacons.Add(beacon);
		}

		var minX = Math.Min(sensors.Min(s => s.Coords.X), beacons.Min(b => b.Coords.X));
		var maxX = Math.Max(sensors.Max(s => s.Coords.X), beacons.Max(b => b.Coords.X));
		BigInteger result = 0;
		Parallel.ForEach(sensors, (sensor) =>
		//foreach (var sensor in sensors)
		{
			Console.WriteLine($"Start searching sensor {sensor.Coords}");
			var min = -(sensor.DistanceToBeacon - 1);
			var max = sensor.DistanceToBeacon + 1;

			for (var i = min; i <= max; i++)
			{
				var y = sensor.Coords.Y + i;
				if (y < 0 || y > searchSpace)
				{
					break;
				}

				var xCoords = new int[]
				{
					sensor.Coords.X - Math.Abs(sensor.DistanceToBeacon + 1 - i),
					sensor.Coords.X + Math.Abs(sensor.DistanceToBeacon + 1 - i),
				};

				foreach (var x in xCoords)
				{
					if (x < 0 || x > searchSpace)
					{
						break;
					}

					var match = true;

					foreach (var otherSensor in sensors)
					{
						var pos = new Coords(x, y);
						var distManhattan = otherSensor.Coords.DistanceTo(pos);

						if (distManhattan <= otherSensor.DistanceToBeacon)
						{
							match = false;
							break;
						}
					}

					if (match)
					{
						Console.WriteLine($"Found match {x} {y}");
						result = BigInteger.Multiply(x, 4000000) + y;
						return;
					}
				}
			}
		});

		return result;
	}
}
