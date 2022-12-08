using System.Runtime.Serialization;

namespace AdventOfCode.Day8;

public class Tree
{
	required public TreePosition Position { get; init; }
	required public int Height { get; init; }
	required public Tree? Up { get; init; }
	required public Tree? Left { get; init; }
	public Tree? Right { get; private set; }
	public Tree? Down { get; private set; }
	public bool IsOnEdge => Up == null || Right == null || Left == null || Down == null;
	public bool IsVisible => IsOnEdge 
		|| VisibleInDirection(Direction.Up, Up, Height) 
		|| VisibleInDirection(Direction.Right, Right, Height) 
		|| VisibleInDirection(Direction.Down, Down, Height) 
		|| VisibleInDirection(Direction.Left, Left, Height);
	public int ScenicScore => SeeingDistance(Direction.Up, Up, Height) 
		* SeeingDistance(Direction.Down, Down, Height) 
		* SeeingDistance(Direction.Left, Left, Height) 
		* SeeingDistance(Direction.Right, Right, Height);

	private enum Direction { Up, Down, Left, Right }

	public static Tree Create(int x, int y, int height, Tree? left, Tree? up)
	{
		var tree = new Tree
		{
			Position = new TreePosition(x, y),
			Height= height,
			Left = left,
			Up = up,
		};
		if (left is not null)
		{
			left.Right = tree;
		}
		if (up is not null)
		{
			up.Down = tree;
		}

		return tree;
	}

	private int SeeingDistance(Direction direction, Tree? neighbour, int testHeight)
	{
		if (neighbour is null)
		{
			return 0;
		}

		if (neighbour.Height >= testHeight)
		{
			return 1;
		}

		var nextNeighbour = NextNeighbour(direction, neighbour);

		var result = 1;
		result += SeeingDistance(direction, nextNeighbour, testHeight);
		return result;
	}

	private bool VisibleInDirection(Direction direction, Tree? tree, int testHeight)
	{

		if (tree is null)
		{
			return true;
		}
		if (tree.Height >= testHeight)
		{
			return false;
		}

		var nextNeighbour = NextNeighbour(direction, tree);

		return VisibleInDirection(direction, nextNeighbour, testHeight);
	}

	private static Tree? NextNeighbour(Direction direction, Tree? neighbour) =>
		direction switch
		{
			Direction.Up => neighbour?.Up,
			Direction.Down => neighbour?.Down,
			Direction.Left => neighbour?.Left,
			Direction.Right => neighbour?.Right,
			_ => throw new ArgumentException("Invalid enum value for command", nameof(direction))
		};
}
