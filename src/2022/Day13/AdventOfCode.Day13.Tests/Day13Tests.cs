namespace AdventOfCode.Day13.Tests
{
	public class Day13Tests
	{
		[Fact]
		public void Part1Tests()
		{
			var input = File.ReadAllLines("TestInput.txt");

			var result = Part1.Run(input);

			Assert.Equal(1, result.SomeResult);
		}
	}
}