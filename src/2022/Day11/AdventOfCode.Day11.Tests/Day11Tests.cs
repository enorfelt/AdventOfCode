namespace AdventOfCode.Day11.Tests
{
	public class Day11Tests
	{
		[Fact]
		public void Test1()
		{
			var lines = File.ReadAllLines("TestInput.txt");

			var result = Part1.Run(lines);

			Assert.Equal(1, result.SomeResult);
		}
	}
}