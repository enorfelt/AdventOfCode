namespace AdventOfCode.Day9.Tests
{
	public class Day9Part2Tests
	{
		[Fact]
		public void Step1()
		{
			var input = new string[]
			{
				"R 5",
				//"U 8",
				//"L 8",
				//"D 3",
				//"R 17",
				//"D 10",
				//"L 25",
				//"U 20"
			};

			var result = Part1.Run(input, 9);

			Assert.Equal(new Position(5, 0), result.Head.CurrentPosition);
			Assert.Equal(new Position(4, 0), result.Knots[0].CurrentPosition);
			Assert.Equal(new Position(3, 0), result.Knots[1].CurrentPosition);
			Assert.Equal(new Position(2, 0), result.Knots[2].CurrentPosition);
			Assert.Equal(new Position(1, 0), result.Knots[3].CurrentPosition);
			Assert.Equal(new Position(0, 0), result.Knots[4].CurrentPosition);
			Assert.Equal(new Position(0, 0), result.Knots[5].CurrentPosition);
			Assert.Equal(new Position(0, 0), result.Knots[6].CurrentPosition);
			Assert.Equal(new Position(0, 0), result.Knots[7].CurrentPosition);
			Assert.Equal(new Position(0, 0), result.Knots[8].CurrentPosition);

			Assert.Equal(1, result.Tail.NumPositionsVisited);
		}

		[Fact]
		public void Step2()
		{
			var input = new string[]
			{
				"R 5",
				"U 8",
				//"L 8",
				//"D 3",
				//"R 17",
				//"D 10",
				//"L 25",
				//"U 20"
			};

			var result = Part1.Run(input, 9);

			Assert.Equal(new Position(5, 8), result.Head.CurrentPosition);
			Assert.Equal(new Position(5, 7), result.Knots[0].CurrentPosition);
			Assert.Equal(new Position(5, 6), result.Knots[1].CurrentPosition);
			Assert.Equal(new Position(5, 5), result.Knots[2].CurrentPosition);
			Assert.Equal(new Position(5, 4), result.Knots[3].CurrentPosition);
			Assert.Equal(new Position(4, 4), result.Knots[4].CurrentPosition);
			Assert.Equal(new Position(3, 3), result.Knots[5].CurrentPosition);
			Assert.Equal(new Position(2, 2), result.Knots[6].CurrentPosition);
			Assert.Equal(new Position(1, 1), result.Knots[7].CurrentPosition);
			Assert.Equal(new Position(0, 0), result.Knots[8].CurrentPosition);

			Assert.Equal(1, result.Tail.NumPositionsVisited);
		}

		[Fact]
		public void Step3()
		{
			var input = new string[]
			{
				"R 5",
				"U 8",
				"L 8",
				//"D 3",
				//"R 17",
				//"D 10",
				//"L 25",
				//"U 20"
			};

			var result = Part1.Run(input, 9);

			Assert.Equal(new Position(-3, 8), result.Head.CurrentPosition);
			Assert.Equal(new Position(-2, 8), result.Knots[0].CurrentPosition);
			Assert.Equal(new Position(-1, 8), result.Knots[1].CurrentPosition);
			Assert.Equal(new Position(0, 8), result.Knots[2].CurrentPosition);
			Assert.Equal(new Position(1, 8), result.Knots[3].CurrentPosition);
			Assert.Equal(new Position(1, 7), result.Knots[4].CurrentPosition);
			Assert.Equal(new Position(1, 6), result.Knots[5].CurrentPosition);
			Assert.Equal(new Position(1, 5), result.Knots[6].CurrentPosition);
			Assert.Equal(new Position(1, 4), result.Knots[7].CurrentPosition);
			Assert.Equal(new Position(1, 3), result.Knots[8].CurrentPosition);

			Assert.Equal(4, result.Tail.NumPositionsVisited);
		}

	}
}