namespace AdventOfCode.Day9.Tests
{
	public class Day9Tests
	{
		[Fact]
		public void Test1()
		{
			var input = File.ReadAllLines("TestInput.txt");

			var result = Part1.Run(input);

			Assert.Equal(1, result.SomeResult);
		}
	}
}