// See https://aka.ms/new-console-template for more information

using AdventOfCode.Common;
using System.Diagnostics;

namespace AdventOfCode.Day12;

public class HeightMap
{
	private readonly string[] input;
	private readonly List<Square> squares = new();

	public Square? HighestPoint => squares.MaxBy(x => x.Height);

	public HeightMap(string[] input)
	{
		this.input = input;
		Init();
	}

	private void Init()
	{
		for (var y = 0; y < input.Length; y++)
		{
			for (var x = 0; x < input[y].Length; x++)
			{
				var heightChar = input[y][x];
				var height = (int)heightChar % 32;
				if (heightChar == 'S')
				{
					height = 0;
				}
				if (heightChar == 'E')
				{
					height = ('z' % 32) + 1;
				}

				var square = new Square
				{
					Coords = new(x, y),
					Height = height,
					Left = squares.FirstOrDefault(s => s.Coords.X == x - 1 && s.Coords.Y == y),
					Up = squares.FirstOrDefault(s => s.Coords.X == x && s.Coords.Y == y - 1),
				};
				if (square.Left != null)
				{
					square.Left.Right = square;
				}
				if (square.Up != null)
				{
					square.Up.Down = square;
				}
				squares.Add(square);
			}
		}
	}

	internal int FindShortestPathFromStart()
	{
		var shortestPathTo = ShortestPath(squares.First());
		var target = squares.First(s => s.IsHeighest);

		var shortestPath = shortestPathTo(target);

		return shortestPath.Count();
	}

	internal int FindShortestPathFromClosestLowPoint()
	{
		var allLowPoints = squares.Where(x => x.IsLowest);
		var target = squares.First(s => s.IsHeighest);
		var results = new List<int>();
		
		Parallel.ForEach(allLowPoints, (lowPoint) =>
		{
			var shortestPathTo = ShortestPath(lowPoint);
			var result = shortestPathTo(target);
			var count = result.Count();
			if (count > 0)
			{
				results.Add(result.Count());
			}
		});
		return results.Min();
	}

	public static Func<Square, IEnumerable<Square>> ShortestPath(Square start)
	{
		var previous = new Dictionary<Coords, Square>();
		var queue = new Queue<Square>();
		queue.Enqueue(start);
		while (queue.Count > 0)
		{
			var square = queue.Dequeue();
			var neighbours = square.Neighbours();
			foreach (var neighbour in neighbours)
			{
				if (previous.ContainsKey(neighbour.Coords))
				{
					continue;
				}
				previous[neighbour.Coords] = square;
				queue.Enqueue(neighbour);
			}
		}

		IEnumerable<Square> shortestPath(Square v)
		{
			var path = new List<Square> { };

			var current = v;
			if (!previous.ContainsKey(current.Coords))
			{
				return path;
			}
			while (!current.Equals(start))
			{
				path.Add(current);
				current = previous[current.Coords];
			};

			path.Reverse();

			return path;
		}

		return shortestPath;
	}
}