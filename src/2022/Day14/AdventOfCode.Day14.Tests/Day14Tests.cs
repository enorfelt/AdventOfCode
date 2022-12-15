namespace AdventOfCode.Day14.Tests
{
	public class Day14Tests
	{
		[Fact]
		public void Part1Tests()
		{
			var input = File.ReadAllLines("TestInput.txt");

			var result = Part1.Run(input);

			Assert.Equal(24, result);
		}

		[Fact]
		public void Part2Tests()
		{
			var input = File.ReadAllLines("TestInput.txt");

			var result = Part2.Run(input);

			Assert.Equal(93, result);
		}
	}
}