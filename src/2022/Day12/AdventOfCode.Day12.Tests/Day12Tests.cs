namespace AdventOfCode.Day12.Tests
{
	public class Day12Tests
	{
		[Fact]
		public void Part1Test()
		{
			var input = File.ReadAllLines("TestInput.txt");

			var result = Part1.Run(input);

			Assert.Equal(1, result.SomeResult);
		}
	}
}