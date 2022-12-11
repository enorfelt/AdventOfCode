using System.Numerics;

namespace AdventOfCode.Day11.Tests
{
	public class Monkey0Operation : IOperation
	{
		public int ForMonkey => 0;

		public int Mod => 23;

		public double Operation(double old)
		{
			return old * 19;
		}

		public bool Test(double item)
		{
			return item % Mod == 0;
		}
	}
	public class Monkey1Operation : IOperation
	{
		public int ForMonkey => 1;

		public int Mod => 19;

		public double Operation(double old)
		{
			return old + 6;
		}

		public bool Test(double item)
		{
			return item % Mod == 0;
		}
	}
	public class Monkey2Operation : IOperation
	{
		public int ForMonkey => 2;

		public int Mod => 13;

		public double Operation(double old)
		{
			return old * old;
		}

		public bool Test(double item)
		{
			return item % Mod == 0;
		}
	}
	public class Monkey3Operation : IOperation
	{
		public int ForMonkey => 3;

		public int Mod => 17;

		public double Operation(double old)
		{
			return old + 3;
		}

		public bool Test(double item)
		{
			return item % Mod == 0;
		}
	}
	public class Day11Tests
	{
		private readonly Dictionary<int, IOperation> operations = new()
		{
			{0, new Monkey0Operation() },
			{1, new Monkey1Operation() },
			{2, new Monkey2Operation() },
			{3, new Monkey3Operation() },
		};

		private readonly int superMod; 

		public Day11Tests()
		{
			superMod = operations.Select(x => x.Value).Select(v => v.Mod).Aggregate(1, (x, y) => x * y);
		}

		[Fact]
		public void Part1Test()
		{
			var lines = File.ReadAllLines("TestInput.txt");

			var result = Part1.Run(lines, operations);

			Assert.Equal(10605, result.LevelOfMonkeyBusiness);
		}

		[Fact]
		public void Part2Test()
		{
			var lines = File.ReadAllLines("TestInput.txt");

			var result = Part2.Run(lines, operations);

			Assert.Equal(2713310158, result.LevelOfMonkeyBusiness);
		}
	}
}