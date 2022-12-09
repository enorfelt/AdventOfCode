namespace AdventOfCode.Day9;

public enum Direction { R, U, L, D }

public record Result(RopeEnd Head, RopeEnd Tail);

public record struct MoveInstruction(Direction Direction, int Steps);

public readonly struct Position
{
	public Position(int x, int y)
	{
		X = x;
		Y = y;
	}
	public int X { get; }
	public int Y { get; }
}

public class RopeEnd
{
	private readonly List<Position> positions = new();
	public RopeEnd(Position initialPosition)
	{
		CurrentPosition = PreviousPostion = initialPosition;
		positions.Add(CurrentPosition);
	}
	public Position CurrentPosition { get; private set; }
	public Position PreviousPostion { get; private set; }
	public int NumPositionsVisited => positions.Distinct().Count();
	public List<Position> PositionsVisited => positions;
	public void Move(Position newPosition)
	{
		PreviousPostion = CurrentPosition;
		CurrentPosition = newPosition;
		positions.Add(newPosition);


	}
	public void MoveRight()
	{
		var newPosition = new Position(CurrentPosition.X + 1, CurrentPosition.Y);
		Move(newPosition);
	}
	public void MoveLeft()
	{
		var newPosition = new Position(CurrentPosition.X - 1, CurrentPosition.Y);
		Move(newPosition);
	}
	public void MoveUp()
	{
		var newPosition = new Position(CurrentPosition.X, CurrentPosition.Y + 1);
		Move(newPosition);
	}
	public void MoveDown()
	{
		var newPosition = new Position(CurrentPosition.X, CurrentPosition.Y - 1);
		Move(newPosition);
	}
}

public class Rope
{
	required public RopeEnd Head { get; init; }
	required public RopeEnd Tail { get; init; }

	internal void MoveHead(Direction direction)
	{
		if (direction is Direction.R) { Head.MoveRight(); }
		if (direction is Direction.L) { Head.MoveLeft(); }
		if (direction is Direction.U) { Head.MoveUp(); }
		if (direction is Direction.D) { Head.MoveDown(); }
	}

	internal void MoveTail()
	{
		var absX = Math.Abs(Tail.CurrentPosition.X - Head.CurrentPosition.X);
		var absY = Math.Abs(Tail.CurrentPosition.Y - Head.CurrentPosition.Y);

		var manhatanDistance = absX + absY;
		var diagonalDistance = Math.Min(absX, absY);


		if (manhatanDistance == 2 && diagonalDistance == 1)
		{
			return;
		}
		if (manhatanDistance > 1)
		{
			Tail.Move(Head.PreviousPostion);
		}


	}
}

public class Part1
{
	public static Result Run(string[] input)
	{
		var rope = new Rope
		{
			Head = new RopeEnd(new Position(0, 0)),
			Tail = new RopeEnd(new Position(0, 0))
		};

		var instructions = GetInstructions(input);
		foreach (var instruction in instructions)
		{
			for (var i = 0; i < instruction.Steps; i++)
			{
				rope.MoveHead(instruction.Direction);
				rope.MoveTail();
			}
		}

		return new Result(rope.Head, rope.Tail);
	}

	private static IEnumerable<MoveInstruction> GetInstructions(string[] lines)
	{
		foreach (var line in lines)
		{
			var steps = int.Parse(line.Substring(2).ToString());

			switch (line[0])
			{
				case 'R':
					yield return new MoveInstruction(Direction.R, steps);
					break;
				case 'L':
					yield return new MoveInstruction(Direction.L, steps);
					break;
				case 'U':
					yield return new MoveInstruction(Direction.U, steps);
					break;
				case 'D':
					yield return new MoveInstruction(Direction.D, steps);
					break;
				default:
					throw new ArgumentException("No matching instruction", nameof(lines));
			}
		}
	}
}
