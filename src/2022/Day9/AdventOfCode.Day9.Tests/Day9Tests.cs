using System.Numerics;

namespace AdventOfCode.Day9.Tests
{
	public class Day9Tests
	{
		[Fact]
		public void Test1()
		{
			var input = File.ReadAllLines("TestInput.txt");

			var result = Part1.Run(input);

			Assert.Equal(13, result.Tail.NumPositionsVisited);
		}

		[Fact]
		public void Test2()
		{
			var input = File.ReadAllLines("TestInput2.txt");

			var result = Part1.Run(input);

			Assert.Equal(6, result.Tail.NumPositionsVisited);
		}

		[Fact]
		public void Test3()
		{
			var input = new string[]
			{
				"L 2", // 1
				"D 2", // 2
				"R 1",
				"U 3", // 3
				"R 2", // 3
				"U 5", // 3
			};

			var result = Part1.Run(input);

			var t = new Vector2(0, 0);
			var h = new Vector2(-2, 0);

			var td = t - h;
			t = h + td;

			Assert.Equal(8, result.Tail.NumPositionsVisited);
			//Assert.Equal(result.Tail.CurrentPosition, result.Head.CurrentPosition);
		}

		[Fact]
		public void Test4()
		{
			var input = File.ReadAllLines("TestInput3.txt");

			var result = Part1.Run(input);

			Assert.Equal(5619, result.Tail.NumPositionsVisited);
		}

	}
}