// See https://aka.ms/new-console-template for more information

namespace AdventOfCode.Common;

public record struct Coords(int X, int Y)
{
	public int DistanceTo(Coords coords)
	{
		return Math.Abs(X - coords.X) + Math.Abs(Y - coords.Y);
	}
}
