using AdventOfCode.Common;

namespace AdventOfCode.Day12.Tests
{
	public class Day12Tests
	{
		[Fact]
		public void ShouldFindHighestPoint()
		{
			var input = File.ReadAllLines("TestInput.txt");

			var result = Part1.Run(input);

			var highestPoint = result.Map.HighestPoint;
			Assert.Equal(new Coords(5, 2), highestPoint?.Coords);
		}

		[Fact]
		public void ShouldFindFastestPathToTheTop()
		{
			var input = File.ReadAllLines("TestInput.txt");

			var result = Part1.Run(input);

			Assert.Equal(31, result.NumberOfSteps);
		}

		[Fact]
		public void ShouldFindShortestPathFromClosestLowPoint()
		{
			var input = File.ReadAllLines("TestInput.txt");

			var result = Part2.Run(input);

			Assert.Equal(29, result.NumberOfSteps);
		}
	}
}