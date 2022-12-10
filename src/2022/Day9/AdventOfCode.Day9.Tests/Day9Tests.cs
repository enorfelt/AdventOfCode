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

			Assert.Equal(8, result.Tail.NumPositionsVisited);
		}

		[Fact]
		public void Test4()
		{
			var input = File.ReadAllLines("TestInput3.txt");

			var result = Part1.Run(input);

			Assert.Equal(5619, result.Tail.NumPositionsVisited);
		}

		[Fact]

		public void Test5()
		{
			var input = new string[]
			{
				"R 5",
				"U 8",
				"L 8",
				"D 3",
				"R 17",
				"D 10",
				"L 25",
				"U 20"
			};

			var result = Part1.Run(input, 9);

			Assert.Equal(36, result.Tail.NumPositionsVisited);
		}

		[Fact]
		public void Test6()
		{
			var input = new string[]
			{
				"R 4",
				"U 4"
			};

			var result = Part1.Run(input, 9);

			Assert.Equal(new Position(4, 4), result.Head.CurrentPosition);
			Assert.Equal(new Position(4, 3), result.Knots[0].CurrentPosition);
			Assert.Equal(new Position(4, 2), result.Knots[1].CurrentPosition);
			Assert.Equal(new Position(3, 2), result.Knots[2].CurrentPosition);
			Assert.Equal(new Position(2, 2), result.Knots[3].CurrentPosition);
			Assert.Equal(new Position(1, 1), result.Knots[4].CurrentPosition);
			Assert.Equal(new Position(0, 0), result.Knots[5].CurrentPosition);

		}

		[Fact]
		public void Test7()
		{
			var input = new string[]
			{
				"R 4",
				"U 4",
				"L 3"
			};

			var result = Part1.Run(input, 9);

			Assert.Equal(new Position(1, 4), result.Head.CurrentPosition);
			Assert.Equal(new Position(2, 4), result.Knots[0].CurrentPosition);
			Assert.Equal(new Position(3, 3), result.Knots[1].CurrentPosition);
			Assert.Equal(new Position(3, 2), result.Knots[2].CurrentPosition);
			Assert.Equal(new Position(2, 2), result.Knots[3].CurrentPosition);
			Assert.Equal(new Position(1, 1), result.Knots[4].CurrentPosition);
			Assert.Equal(new Position(0, 0), result.Knots[5].CurrentPosition);

		}

		[Fact]
		public void Test8()
		{
			var input = new string[]
			{
				"R 4",
				"U 4",
				"L 3",
				"D 1"
			};

			var result = Part1.Run(input, 9);

			Assert.Equal(new Position(1, 3), result.Head.CurrentPosition);
			Assert.Equal(new Position(2, 4), result.Knots[0].CurrentPosition);
			Assert.Equal(new Position(3, 3), result.Knots[1].CurrentPosition);
			Assert.Equal(new Position(3, 2), result.Knots[2].CurrentPosition);
			Assert.Equal(new Position(2, 2), result.Knots[3].CurrentPosition);
			Assert.Equal(new Position(1, 1), result.Knots[4].CurrentPosition);
			Assert.Equal(new Position(0, 0), result.Knots[5].CurrentPosition);

		}

		[Fact]
		public void Test9()
		{
			var input = new string[]
			{
				"R 4",
				"U 4",
				"L 3",
				"D 1",
				"R 4"
			};

			var result = Part1.Run(input, 9);

			Assert.Equal(new Position(5, 3), result.Head.CurrentPosition);
			Assert.Equal(new Position(4, 3), result.Knots[0].CurrentPosition);
			Assert.Equal(new Position(3, 3), result.Knots[1].CurrentPosition);
			Assert.Equal(new Position(3, 2), result.Knots[2].CurrentPosition);
			Assert.Equal(new Position(2, 2), result.Knots[3].CurrentPosition);
			Assert.Equal(new Position(1, 1), result.Knots[4].CurrentPosition);
			Assert.Equal(new Position(0, 0), result.Knots[5].CurrentPosition);

		}

		[Fact]
		public void Test10()
		{
			var input = new string[]
			{
				"R 4",
				"U 4",
				"L 3",
				"D 1",
				"R 4",
				"D 1"
			};

			var result = Part1.Run(input, 9);

			Assert.Equal(new Position(5, 2), result.Head.CurrentPosition);
			Assert.Equal(new Position(4, 3), result.Knots[0].CurrentPosition);
			Assert.Equal(new Position(3, 3), result.Knots[1].CurrentPosition);
			Assert.Equal(new Position(3, 2), result.Knots[2].CurrentPosition);
			Assert.Equal(new Position(2, 2), result.Knots[3].CurrentPosition);
			Assert.Equal(new Position(1, 1), result.Knots[4].CurrentPosition);
			Assert.Equal(new Position(0, 0), result.Knots[5].CurrentPosition);

		}

		[Fact]
		public void Test11()
		{
			var input = new string[]
			{
				"R 4",
				"U 4",
				"L 3",
				"D 1",
				"R 4",
				"D 1",
				"L 5"
			};

			var result = Part1.Run(input, 9);

			Assert.Equal(new Position(0, 2), result.Head.CurrentPosition);
			Assert.Equal(new Position(1, 2), result.Knots[0].CurrentPosition);
			Assert.Equal(new Position(2, 2), result.Knots[1].CurrentPosition);
			Assert.Equal(new Position(3, 2), result.Knots[2].CurrentPosition);
			Assert.Equal(new Position(2, 2), result.Knots[3].CurrentPosition);
			Assert.Equal(new Position(1, 1), result.Knots[4].CurrentPosition);
			Assert.Equal(new Position(0, 0), result.Knots[5].CurrentPosition);

		}

		[Fact]
		public void Test12()
		{
			var input = new string[]
			{
				"R 4",
				"U 4",
				"L 3",
				"D 1",
				"R 4",
				"D 1",
				"L 5",
				"R 2"
			};

			var result = Part1.Run(input, 9);

			Assert.Equal(new Position(2, 2), result.Head.CurrentPosition);
			Assert.Equal(new Position(1, 2), result.Knots[0].CurrentPosition);
			Assert.Equal(new Position(2, 2), result.Knots[1].CurrentPosition);
			Assert.Equal(new Position(3, 2), result.Knots[2].CurrentPosition);
			Assert.Equal(new Position(2, 2), result.Knots[3].CurrentPosition);
			Assert.Equal(new Position(1, 1), result.Knots[4].CurrentPosition);
			Assert.Equal(new Position(0, 0), result.Knots[5].CurrentPosition);
			Assert.Equal(1, result.Tail.NumPositionsVisited);
		}

		[Fact]
		public void Test13()
		{
			var input = new string[]
			{
				"R 4",
				"U 4",
				"L 3",
				"D 1",
				"R 4",
				"D 1",
				"L 5",
				"R 2"
			};

			var result = Part1.Run(input, 5);

			Assert.Equal(new Position(2, 2), result.Head.CurrentPosition);
			Assert.Equal(new Position(1, 2), result.Knots[0].CurrentPosition);
			Assert.Equal(new Position(2, 2), result.Knots[1].CurrentPosition);
			Assert.Equal(new Position(3, 2), result.Knots[2].CurrentPosition);
			Assert.Equal(new Position(2, 2), result.Knots[3].CurrentPosition);
			Assert.Equal(new Position(1, 1), result.Knots[4].CurrentPosition);
			Assert.Equal(2, result.Tail.NumPositionsVisited);
		}

	}
}