// See https://aka.ms/new-console-template for more information

using AdventOfCode.Common;

namespace AdventOfCode.Day12;

public class Square
{
	required public Coords Coords { get; init; }
	required public int Height { get; init; }
	required public Square? Up { get; init; }
	required public Square? Left { get; init; }
	public Square? Right { get; set; }
	public Square? Down { get; set; }
	public bool IsHeighest => Height == ('z' % 32) + 1;
	public bool IsLowest => Height == 1;
	public bool IsStart => Height == 0;
	public bool CanGoDown => Down != null && Down.Height <= Height + 1;
	public bool CanGoUp => Up != null && Up.Height <= Height + 1;
	public bool CanGoRight => Right != null && Right.Height <= Height + 1;
	public bool CanGoLeft => Left != null && Left.Height <= Height + 1;

	internal IEnumerable<Square> Neighbours()
	{
		var neightbours = new List<Square>();
		if (Right is not null && CanGoRight)
			neightbours.Add(Right);
		if (Down is not null && CanGoDown)
			neightbours.Add(Down);
		if (Up is not null && CanGoUp)
			neightbours.Add(Up);
		if (Left is not null && CanGoLeft)
			neightbours.Add(Left);

		return neightbours;
	}
}
