namespace AdventOfCode.Day10.Tests
{
	public class Day10Tests
	{
		[Fact]
		public void Test1()
		{
			var input = File.ReadAllLines("TestInput.txt");

			var result = Part1.Run(input);

			Assert.Equal(13140, result.SignalStrengths);
		}
	}
}