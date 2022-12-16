using AdventOfCode.Common;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AdventOfCode.Day14;
public class Part1
{
	public static int Run(string[] input)
	{
		var cave = Cave.Scan(input);
		
		while (!cave.IsFilledWithSand)
		{
			cave.StartPour();
			//Console.Clear();
			//Console.WriteLine(cave.SandCount);
		}

		//cave.Print();

		return cave.SandCount;
	}
}

public class Part2
{
	public static int Run(string[] input)
	{
		var cave = Cave.Scan(input);

		var start = new Coords(cave.LeftBoundary, cave.BottomBoundary + 2);
		var end = new Coords(cave.RightBoundary, cave.BottomBoundary + 2);

		cave.AddRocks(start, end);
		Console.WriteLine("Start");
		var stopWatch = Stopwatch.StartNew();
		while (!cave.IsFilledWithSand)
		{
			cave.StartPourWithLimit();
			//Console.WriteLine(cave.SandCount);
		}
		stopWatch.Stop();
		Console.WriteLine(stopWatch.Elapsed.TotalSeconds);
		//cave.Print();
		return cave.SandCount;
	}
}

public static class CollectionExtensions
{
	public static bool HaveObstacleBelow<T>(this ICollection<T> collection, T obstacle) where T : CaveObstacle
	{
		return collection.Any(o => o.Coords.X == obstacle.Coords.X && o.Coords.Y == obstacle.Coords.Y + 1);
	}

	public static bool HaveObstacleBelowWithLimit<T>(this ICollection<T> collection, T obstacle, int limit) where T : CaveObstacle
	{
		if (obstacle.Coords.Y + 1 == limit)
		{
			return true;
		}
		return collection.Any(o => o.Coords.X == obstacle.Coords.X && o.Coords.Y == obstacle.Coords.Y + 1);
	}

	public static bool HaveObstacleBelowLeft<T>(this ICollection<T> collection, T obstacle) where T : CaveObstacle
	{
		return collection.Any(o => o.Coords.X == obstacle.Coords.X - 1 && o.Coords.Y == obstacle.Coords.Y + 1);
	}

	public static bool HaveObstacleBelowLeftWithLimit<T>(this ICollection<T> collection, T obstacle, int limit) where T : CaveObstacle
	{
		if (obstacle.Coords.Y + 1 == limit)
		{
			return true;
		}
		return collection.Any(o => o.Coords.X == obstacle.Coords.X - 1 && o.Coords.Y == obstacle.Coords.Y + 1);
	}

	public static bool HaveObstacleBelowRight<T>(this ICollection<T> collection, T obstacle) where T : CaveObstacle
	{
		return collection.Any(o => o.Coords.X == obstacle.Coords.X + 1 && o.Coords.Y == obstacle.Coords.Y + 1);
	}
	public static bool HaveObstacleBelowRightWithLimit<T>(this ICollection<T> collection, T obstacle, int limit) where T : CaveObstacle
	{
		if (obstacle.Coords.Y + 1 == limit)
		{
			return true;
		}
		return collection.Any(o => o.Coords.X == obstacle.Coords.X + 1 && o.Coords.Y == obstacle.Coords.Y + 1);
	}
}

public class Cave
{
	private bool _filledWithSand = false;
	private Cave()
	{
		CaveObstacles = new HashSet<CaveObstacle>();
	}
	public HashSet<CaveObstacle> CaveObstacles { get; }

	public int LeftBoundary => CaveObstacles.Min(o => o.Coords.X);
	public int RightBoundary => CaveObstacles.Max(o => o.Coords.X);
	public int BottomBoundary => CaveObstacles.Max(r => r.Coords.Y);

	public bool IsFilledWithSand => _filledWithSand;

	public int SandCount => CaveObstacles.Where(o => o is Sand).Count();

	internal void AddRocks(Coords start, Coords end)
	{
		var dX = end.X - start.X;
		var dY = end.Y - start.Y;

		if (dX > 0)
		{
			for (var i = 0; i <= dX; i++)
			{
				CaveObstacles.Add(new Rock(start.X + i, start.Y));
			}
		}
		else if (dX < 0)
		{
			for (var i = 0; i >= dX; i--)
			{
				CaveObstacles.Add(new Rock(start.X + i, start.Y));
			}
		}
		else if (dY < 0)
		{
			for (var i = 0; i >= dY; i--)
			{
				CaveObstacles.Add(new Rock(start.X, start.Y + i));
			}
		}
		else
		{
			for (var i = 0; i <= dY; i++)
			{
				CaveObstacles.Add(new Rock(start.X, start.Y + i));
			}
		}
	}

	internal void StartPour()
	{
		var startingPoint = new Coords(500, -1);
		var firstObstackle = CaveObstacles.Where(o => o.Coords.X == startingPoint.X).MinBy(o => o.Coords.Y);
		if (firstObstackle == null)
		{
			_filledWithSand = true;
			return;
		}
		if (firstObstackle.Coords == new Coords(500, 0))
		{
			_filledWithSand = true;
			return;
		}
		var sand = new Sand(new Coords(firstObstackle.Coords.X, firstObstackle.Coords.Y - 1));
		var isAtRest = false;
		while (!isAtRest)
		{
			if (sand.Coords.X < LeftBoundary || sand.Coords.X > RightBoundary)
			{
				_filledWithSand = true;
				return;
			}

			if (!CaveObstacles.HaveObstacleBelow(sand))
			{
				firstObstackle = CaveObstacles.Where(o => o.Coords.X == sand.Coords.X && o.Coords.Y > sand.Coords.Y).MinBy(o => o.Coords.Y);
				if (firstObstackle == null)
				{
					_filledWithSand = true;
					return;
				}
				sand.FallTo(new Coords(firstObstackle.Coords.X, firstObstackle.Coords.Y - 1));
			}
			else if (!CaveObstacles.HaveObstacleBelowLeft(sand))
			{
				sand.MoveDownLeft();
			}
			else if (!CaveObstacles.HaveObstacleBelowRight(sand))
			{
				sand.MoveDownRight();
			}
			else
			{
				var success = CaveObstacles.Add(sand);
				if (!success)
				{
					throw new Exception("Spot is already taken");
				}
				isAtRest = true;
			}
		}
		//Print();
	}

	internal void StartPourWithLimit()
	{
		var startingPoint = new Coords(500, -1);
		var firstObstackle = CaveObstacles.Where(o => o.Coords.X == startingPoint.X).MinBy(o => o.Coords.Y);
		if (firstObstackle == null)
		{
			_filledWithSand = true;
			return;
		}
		if (firstObstackle.Coords == new Coords(500, 0))
		{
			_filledWithSand = true;
			return;
		}
		var sand = new Sand(new Coords(firstObstackle.Coords.X, firstObstackle.Coords.Y - 1));
		var isAtRest = false;
		while (!isAtRest)
		{
			//if (sand.Coords.X < LeftBoundary || sand.Coords.X > RightBoundary)
			//{
			//	_filledWithSand = true;
			//	return;
			//}

			if (!CaveObstacles.HaveObstacleBelowWithLimit(sand, BottomBoundary))
			{
				firstObstackle = CaveObstacles.Where(o => o.Coords.X == sand.Coords.X && o.Coords.Y > sand.Coords.Y).MinBy(o => o.Coords.Y);
				if (firstObstackle == null)
				{
					sand.FallTo(new Coords(sand.Coords.X, BottomBoundary - 1));
				}
				else
				{
					sand.FallTo(new Coords(firstObstackle.Coords.X, firstObstackle.Coords.Y - 1));
				}
			}
			else if (!CaveObstacles.HaveObstacleBelowLeftWithLimit(sand, BottomBoundary))
			{
				sand.MoveDownLeft();
			}
			else if (!CaveObstacles.HaveObstacleBelowRightWithLimit(sand, BottomBoundary))
			{
				sand.MoveDownRight();
			}
			else
			{
				var success = CaveObstacles.Add(sand);
				if (!success)
				{
					throw new Exception("Spot is already taken");
				}
				if (sand.Coords.Y + 1 == BottomBoundary)
				{
					CaveObstacles.Add(new Rock(sand.Coords.X, BottomBoundary));
				}
				isAtRest = true;
			}
			//Print();
		}
		//Print();
	}

	public static Cave Scan(string[] input)
	{
		var cave = new Cave();
		foreach (var line in input)
		{
			var parts = line.Split(" -> ");
			for (var i = 1; i < parts.Length; i++)
			{
				var end = parts[i].Split(",").Select(int.Parse).ToArray();
				var start = parts[i - 1].Split(",").Select(int.Parse).ToArray();
				cave.AddRocks(new Coords(start[0], start[1]), new Coords(end[0], end[1]));
			}
		}
		return cave;
	}

	public void Print()
	{
		var maxY = CaveObstacles.Max(r => r.Coords.Y);
		var minY = 0;
		var sb= new StringBuilder();
		var lastKnownSand = new Coords(0, 0);
		for (var y = minY; y <= maxY; y++)
		{
			for (var x = LeftBoundary; x <= RightBoundary; x++)
			{
				var obstacle = CaveObstacles.FirstOrDefault(r => r.Coords.X == x && r.Coords.Y == y);
				if (obstacle == null)
				{
					if (y == 0 && x == 500)
					{
						//Console.Write("+");
						sb.Append("+");
					}
					else
					{
						//Console.Write(".");
						sb.Append(".");
					}
				}
				else
				{
					var rockOrSand = obstacle is Rock ? "#" : "o";
					//Console.Write(rockOrSand);
					sb.Append(rockOrSand);
					if (obstacle is Sand)
					{
						lastKnownSand = obstacle.Coords;
					}
				}
			}
			sb.Append("\n");
		}

		Console.Clear();
		Console.Write(sb.ToString());
		Console.CursorVisible = false;
		Console.SetCursorPosition(0, lastKnownSand.Y - 10);
		Thread.Sleep(25);
		//Console.WriteLine($"{LeftBoundary} {RightBoundary}");
	}
}

public class CaveObstacle
{
	public CaveObstacle(int x, int y)
	{
		Coords = new Coords(x, y);
	}

	public CaveObstacle(Coords coords)
	{
		Coords = coords;
	}
	public virtual Coords Coords { get; protected set; }
	public override bool Equals(object? obj)
	{
		return obj is CaveObstacle rock &&
			   EqualityComparer<Coords>.Default.Equals(Coords, rock.Coords);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Coords);
	}

}

public class Rock : CaveObstacle
{
	public Rock(int x, int y)
		: base(new Coords(x, y))
	{ }

	public override bool Equals(object? obj)
	{
		return obj is Rock rock &&
			   EqualityComparer<Coords>.Default.Equals(Coords, rock.Coords);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Coords);
	}
}

public class Sand : CaveObstacle
{
	public Sand(int x, int y)
		: base(new Coords(x, y))
	{ }

	public Sand(Coords coords) : base(coords)
	{
	}

	public void MoveDown()
	{
		Coords = new Coords(Coords.X, Coords.Y + 1);
		//Console.WriteLine($"Move down {Coords}");
	}

	public void MoveDownLeft()
	{
		Coords = new Coords(Coords.X - 1, Coords.Y + 1);
		//Console.WriteLine($"Move down left {Coords}");
	}

	public void MoveDownRight()
	{
		Coords = new Coords(Coords.X + 1, Coords.Y + 1);
		//Console.WriteLine($"Move down right {Coords}");
	}

	public override bool Equals(object? obj)
	{
		return obj is Sand sand &&
			   EqualityComparer<Coords>.Default.Equals(Coords, sand.Coords);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Coords);
	}

	internal void FallTo(Coords coords)
	{
		Coords = coords;
	}
}