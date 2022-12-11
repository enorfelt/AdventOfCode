using System.Numerics;

namespace AdventOfCode.Day11.Tests
{
	public class Monkey0Operation : IOperation
	{
		public int ForMonkey => 0;

		public double Operation(double old)
		{
			return old * 19;
		}

		public bool Test(double item)
		{
			return item % 23 == 0;
		}
	}
	public class Monkey1Operation : IOperation
	{
		public int ForMonkey => 1;

		public double Operation(double old)
		{
			return old + 6;
		}

		public bool Test(double item)
		{
			return item % 19 == 0;
		}
	}
	public class Monkey2Operation : IOperation
	{
		public int ForMonkey => 2;

		public double Operation(double old)
		{
			return old * old;
		}

		public bool Test(double item)
		{
			return item % 13 == 0;
		}
	}
	public class Monkey3Operation : IOperation
	{
		public int ForMonkey => 3;

		public double Operation(double old)
		{
			return old + 3;
		}

		public bool Test(double item)
		{
			return item % 17 == 0;
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

		[Fact]
		public void Test1()
		{
			var lines = File.ReadAllLines("TestInput.txt");

			var result = Part1.Run(lines, operations, 20);

			Assert.Equal(10197, result.SomeResult);
		}

		[Fact]
		public void Test2()
		{
			var lines = File.ReadAllLines("TestInput.txt");

			var result = Part1.Run(lines, operations, 10000);

			Assert.Equal(2713310158, result.SomeResult);
		}
	}
}