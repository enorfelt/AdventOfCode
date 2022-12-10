namespace AdventOfCode.Day9;

public class Knot
{
	private readonly HashSet<Position> positions = new();
	public Knot(Position initialPosition, string id)
	{
		CurrentPosition = PreviousPostion = initialPosition;
		positions.Add(CurrentPosition);
		Id = id;
	}
	public string Id { get; private set; }
	public Position CurrentPosition { get; private set; }
	public Position PreviousPostion { get; private set; }
	public int NumPositionsVisited => positions.Count();
	public HashSet<Position> PositionsVisited => positions;
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

	internal void MoveUpRight()
	{
		var newPosition = new Position(CurrentPosition.X + 1, CurrentPosition.Y + 1);
		Move(newPosition);
	}
	internal void MoveUpLeft()
	{
		var newPosition = new Position(CurrentPosition.X - 1, CurrentPosition.Y + 1);
		Move(newPosition);
	}
	internal void MoveDownRight()
	{
		var newPosition = new Position(CurrentPosition.X + 1, CurrentPosition.Y - 1);
		Move(newPosition);
	}
	internal void MoveDownLeft()
	{
		var newPosition = new Position(CurrentPosition.X - 1, CurrentPosition.Y - 1);
		Move(newPosition);
	}
}
