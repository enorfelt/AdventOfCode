using System.Runtime.Serialization;

namespace AdventOfCode.Day8;

public class Tree
{
	private enum Direction { Up, Down, Left, Right }
	private Tree(int x, int y, int height)
	{
		Position = new TreePosition(x, y);
		Height = height;
	}
	public TreePosition Position { get; }
	public int Height { get; }
	public Tree? Up { get; private set; }
	public Tree? Right { get; private set; }
	public Tree? Down { get; private set; }
	public Tree? Left { get; private set; }
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

	public static Tree Create(int x, int y, int height, Tree? left, Tree? up)
	{
		var tree = new Tree(x, y, height)
		{
			Left = left,
			Up = up,
		};
		if (left != null)
		{
			left.Right = tree;
		}
		if (up != null)
		{
			up.Down = tree;
		}

		return tree;
	}

	private int SeeingDistance(Direction direction, Tree? neighbour, int testHeight)
	{
		if (neighbour == null)
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
		if (tree == null)
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

	private static Tree? NextNeighbour(Direction direction, Tree? neighbour)
	{
		return direction == Direction.Up ? neighbour?.Up :
					direction == Direction.Down ? neighbour?.Down :
					direction == Direction.Left ? neighbour?.Left :
					neighbour?.Right;
	}
}
