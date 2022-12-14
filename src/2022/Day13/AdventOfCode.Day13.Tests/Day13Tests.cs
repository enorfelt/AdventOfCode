namespace AdventOfCode.Day13.Tests
{
	public class Day13Tests
	{
		[Fact]
		public void ShouldCompareTwoArrays()
		{
			var input = File.ReadAllLines("TestInput1.txt");

			var result = Part1.Run(input);

			Assert.Equal(1, result);
		}

		[Fact]
		public void ShouldHandleArraysInArrays()
		{
			var input = File.ReadAllLines("TestInput2.txt");

			var result = Part1.Run(input);

			Assert.Equal(1, result);
		}

		[Fact]
		public void ShouldHandleNotInOrder()
		{
			var input = File.ReadAllLines("TestInput3.txt");

			var result = Part1.Run(input);

			Assert.Equal(0, result);
		}

		[Fact]
		public void ShouldHandleLeftSideOutOfItems()
		{
			var input = File.ReadAllLines("TestInput4.txt");

			var result = Part1.Run(input);

			Assert.Equal(1, result);
		}

		[Fact]
		public void ShouldHandleRightSideOutOfItems()
		{
			var input = File.ReadAllLines("TestInput5.txt");

			var result = Part1.Run(input);

			Assert.Equal(0, result);
		}

		[Fact]
		public void ShouldHandleEmptyArrays()
		{
			var input = File.ReadAllLines("TestInput6.txt");

			var result = Part1.Run(input);

			Assert.Equal(1, result);
		}

		[Fact]
		public void ShouldHandleMultiEmptyArrays()
		{
			var input = File.ReadAllLines("TestInput7.txt");

			var result = Part1.Run(input);

			Assert.Equal(0, result);
		}

		[Fact]
		public void ShouldHandleMoreComplexInput()
		{
			var input = File.ReadAllLines("TestInput8.txt");

			var result = Part1.Run(input);

			Assert.Equal(0, result);
		}

		[Fact]
		public void ShouldCalculateSumOfIndexesInOrder()
		{
			var input = File.ReadAllLines("TestInput.txt");

			var result = Part1.Run(input);

			Assert.Equal(13, result);
		}

		[Fact]
		public void ShouldCalculateDividerIndex()
		{
			var input = File.ReadAllLines("TestInput.txt");

			var result = Part2.Run(input);

			Assert.Equal(140, result);
		}
	}
}