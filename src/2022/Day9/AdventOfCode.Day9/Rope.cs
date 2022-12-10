namespace AdventOfCode.Day9;

public class Rope
{
	required public Knot Head { get; init; }
	required public List<Knot> Knots { get; init; }

	internal void MoveHead(DirectionEnum direction)
	{
		if (direction is DirectionEnum.R) { Head.MoveRight(); }
		if (direction is DirectionEnum.L) { Head.MoveLeft(); }
		if (direction is DirectionEnum.U) { Head.MoveUp(); }
		if (direction is DirectionEnum.D) { Head.MoveDown(); }
	}

	internal void MoveKnots()
	{
		for (var i = 0; i < Knots.Count; i++)
		{
			var knot = Knots[i];
			var head = i == 0 ? Head : Knots[i - 1];
			var dX = head.CurrentPosition.X - knot.CurrentPosition.X;
			var dY = head.CurrentPosition.Y - knot.CurrentPosition.Y;
			var absX = Math.Abs(dX);
			var absY = Math.Abs(dY);
			if (absX > 1 || absY > 1)
			{
				if (absX > 0 && absY > 0)
				{
					if (dX > 0 && dY > 0)
					{
						knot.MoveUpRight();
					}
					else if (dX > 0 && dY < 0)
					{
						knot.MoveDownRight();
					}
					else if (dX < 0 && dY < 0)
					{
						knot.MoveDownLeft();
					}
					else
					{
						knot.MoveUpLeft();
					}
				}
				else if (absY > 1) // move up or down
				{
					if (dY > 0)
					{
						knot.MoveUp();
					}
					else
					{
						knot.MoveDown();
					}
				}
				else // move right or lef
				{
					if (dX > 0)
					{
						knot.MoveRight();
					}
					else
					{
						knot.MoveLeft();
					}
				}
			}
			else
			{
				return;
			}
		}
		
	}

	private void MoveRestOfKnots()
	{
		for (var i = 1; i < Knots.Count; i++)
		{
			var head = Knots[i - 1];
			var knot = Knots[i];

			var absX = Math.Abs(knot.CurrentPosition.X - head.CurrentPosition.X);
			var absY = Math.Abs(knot.CurrentPosition.Y - head.CurrentPosition.Y);

			var manhatanDistance = absX + absY;
			var diagonalDistance = Math.Min(absX, absY);


			if (manhatanDistance == 2 && diagonalDistance == 1)
			{
				return;
			}

			if (manhatanDistance > 1)
			{
				var deltaX = head.CurrentPosition.X - head.PreviousPostion.X;
				var deltaY = head.CurrentPosition.Y - head.PreviousPostion.Y;
				knot.Move(new(knot.CurrentPosition.X + deltaX, knot.CurrentPosition.Y + deltaY));

			}
			else
			{
				return;
			}
		}
	}
}
