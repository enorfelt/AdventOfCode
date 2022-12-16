namespace AdventOfCode.Day15.Tests
{
	public class Day15Tests
	{
		[Fact]
		public void Part1Tests()
		{
			var input = File.ReadAllLines("TestInput.txt");

			var result = Part1.Run(input, 10);

			Assert.Equal(26, result);
		}

		[Fact]
		public void Part2Tests()
		{
			var input = File.ReadAllLines("TestInput.txt");

			var result = Part2.Run(input, 20);

			Assert.Equal(56000011, result);
		}
	}
}