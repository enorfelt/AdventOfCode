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
				var direction = GetDirection(absX, absY, dX, dY);
				switch (direction)
				{
					case DirectionEnum.R:
						knot.MoveRight();
						break;
					case DirectionEnum.U:
						knot.MoveUp();
						break;
					case DirectionEnum.L:
						knot.MoveLeft();
						break;
					case DirectionEnum.D:
						knot.MoveDown();
						break;
					case DirectionEnum.UR:
						knot.MoveUpRight();
						break;
					case DirectionEnum.UL:
						knot.MoveUpLeft();
						break;
					case DirectionEnum.DR:
						knot.MoveDownRight();
						break;
					case DirectionEnum.DL:
						knot.MoveDownLeft();
						break;
					default:
						break;
				}
			}
			else
			{
				return;
			}
		}
		
	}

	private DirectionEnum GetDirection(int absX, int absY, int dX, int dY) =>
		(absX, absY, dX, dY) switch
		{
			_ when absX > 0 && absY > 0 && dX > 0 && dY > 0 => DirectionEnum.UR,
			_ when absX > 0 && absY > 0 && dX < 0 && dY > 0 => DirectionEnum.UL,
			_ when absX > 0 && absY > 0 && dX > 0 && dY < 0 => DirectionEnum.DR,
			_ when absX > 0 && absY > 0 && dX < 0 && dY < 0 => DirectionEnum.DL,
			_ when absY > 1 && dY > 0 => DirectionEnum.U,
			_ when absY > 1 && dY < 0 => DirectionEnum.D,
			_ when absX > 1 && dX > 0 => DirectionEnum.R,
			_ when absX > 1 && dX < 0 => DirectionEnum.L,
			_ => throw new Exception("Case not covered")
		};
}
