namespace AdventOfCode.Common;

public readonly record struct Section(int Start, int End)
{
	public bool Intersects(Section other)
	{
		return Start <= other.End && other.Start <= End;
	}
	public bool Containes(Section other)
	{
		return Start <= other.Start && other.End <= End;
	}
}
