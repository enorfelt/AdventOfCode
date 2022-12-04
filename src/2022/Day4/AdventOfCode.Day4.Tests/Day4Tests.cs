namespace AdventOfCode.Day4.Tests;

public class Day4Tests
{
	[Theory]
	[InlineData("1-4,2-3", true)]
	[InlineData("1-4,1-4", true)]
	[InlineData("2-3,1-4", true)]
	[InlineData("1-4,1-3", true)]
	[InlineData("1-4,2-4", true)]
	[InlineData("1-4,3-5", false)]
	[InlineData("1-4,4-5", false)]
	[InlineData("1-4,5-5", false)]
	public void ShouldFindContainingSections(string line, bool expected)
	{
		var elfPair = ElfPair.Create(line);

		Assert.Equal(expected, elfPair.IntersectsFully);
	}

	[Theory]
	[InlineData("1-4,2-3", true)]
	[InlineData("1-4,1-4", true)]
	[InlineData("2-3,1-4", true)]
	[InlineData("1-4,1-3", true)]
	[InlineData("1-4,2-4", true)]
	[InlineData("1-4,3-5", true)]
	[InlineData("1-4,4-5", true)]
	[InlineData("4-6,5-7", true)]
	[InlineData("1-4,5-5", false)]
	public void ShouldFindPartiallyIntersectingSections(string line, bool expected)
	{
		var elfPair = ElfPair.Create(line);

		Assert.Equal(expected, elfPair.IntersectsPartially);
	}

	[Theory]
	[InlineData("1-2,2-3", 1)]
	[InlineData("2-3,1-3", 2)]
	[InlineData("1-3,1-3", 3)]
	[InlineData("1-3,2-3", 2)]
	[InlineData("1-3,4-5", 0)]
	[InlineData("4-5,1-3", 0)]
	[InlineData("60-79,70-90", 10)]
	[InlineData("70-90,60-79", 10)]
	public void ShouldFindNumberOfIntersectingSections(string line, int expected)
	{
		var elfPair = ElfPair.Create(line);

		Assert.Equal(expected, elfPair.IntersectingSections);
	}
}