namespace AdventOfCode.Day8.Tests
{
	public class Day8Tests
	{
		[Fact]
		public void ShouldCountVisibleTrees()
		{
			var input = File.ReadAllLines("TestInput.txt");

			var result = TreeInspector.Inspect(input);

			Assert.Equal(21, result.NumOfVisibleTrees);
		}

		[Fact]
		public void ShouldFindHighestScenicScorePossible()
		{
			var input = File.ReadAllLines("TestInput.txt");

			var result = TreeInspector.Inspect(input);

			Assert.Equal(8, result.HighestScenicScore);
		}
	}
}