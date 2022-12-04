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

	public int NumberOfIntersected(Section other)
	{
		var start = Math.Max(Start, other.Start);
		var end = Math.Min(End, other.End);

		return Math.Abs(end - start) + 1;
	}
}
