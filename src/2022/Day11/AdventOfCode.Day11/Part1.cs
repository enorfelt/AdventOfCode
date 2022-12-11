// See https://aka.ms/new-console-template for more information

using System.Numerics;

namespace AdventOfCode.Day11;
public interface IOperation
{
	int ForMonkey { get; }
	double Operation(double old);
	bool Test(double item);
}

public class Monkey0Operation : IOperation
{
	public int ForMonkey => 0;

	public double Operation(double old)
	{
		return old * 2;
	}

	public bool Test(double item)
	{
		return item % 11 == 0;
	}
}
public class Monkey1Operation : IOperation
{
	public int ForMonkey => 1;

	public double Operation(double old)
	{
		return old * old;
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
		return old + 6;
	}

	public bool Test(double item)
	{
		return item % 7 == 0;
	}
}
public class Monkey3Operation : IOperation
{
	public int ForMonkey => 3;

	public double Operation(double old)
	{
		return old + 2;
	}

	public bool Test(double item)
	{
		return item % 17 == 0;
	}
}
public class Monkey4Operation : IOperation
{
	public int ForMonkey => 4;

	public double Operation(double old)
	{
		return old * 11;
	}

	public bool Test(double item)
	{
		return item % 3 == 0;
	}
}
public class Monkey5Operation : IOperation
{
	public int ForMonkey => 5;

	public double Operation(double old)
	{
		return old + 7;
	}

	public bool Test(double item)
	{
		return item % 5 == 0;
	}
}
public class Monkey6Operation : IOperation
{
	public int ForMonkey => 6;

	public double Operation(double old)
	{
		return old + 1;
	}

	public bool Test(double item)
	{
		return item % 13 == 0;
	}
}
public class Monkey7Operation : IOperation
{
	public int ForMonkey => 7;

	public double Operation(double old)
	{
		return old + 5;
	}

	public bool Test(double item)
	{
		return item % 2 == 0;
	}
}

public class Monkey
{
	private double seenItems = 0;
	required public int IfTrue { get; init; }
	required public int IfFalse { get; init; }
	required public Queue<double> Items { get; init; }
	required public IOperation Operation { get; init; }
	public double SeenItems => seenItems;
	public (int Monkey, double Item) Throw()
	{
		seenItems++;
		var item = Items.Dequeue();
		item = Operation.Operation(item);
		//item /= 3;
		//item %= 96577;
		item %= 9699690;
		if (Operation.Test(item))
		{
			return ((IfTrue, item));
		}
		return (IfFalse, item);
	}
	public void Catch(double item)
	{
		Items.Enqueue(item);
	}

}
public record Result(double SomeResult);
public class Part1
{
	public static Result Run(string[] input, Dictionary<int, IOperation> operations, int numOfRounds = 20)
	{
		var monkeys = GetMonkeys(input, operations).ToList();
		for (var i = 0; i < numOfRounds; i++)
		{
			Console.WriteLine($"Round {i + 1}");
			foreach (var throwingMonkey in monkeys)
			{
				if (throwingMonkey.Items.Count == 0)
				{
					continue;
				}
				while (throwingMonkey.Items.Count > 0)
				{
					var monkeyThrows = throwingMonkey.Throw();
					var catchingMonkey = monkeys[monkeyThrows.Monkey];
					catchingMonkey.Catch(monkeyThrows.Item);
				}
			}
		}
		var monkeysByMosteActive = monkeys.OrderByDescending(x => x.SeenItems).ToList();
		var m1 = monkeysByMosteActive[0].SeenItems;
		var m2 = monkeysByMosteActive[1].SeenItems;
		var result = m1 * m2;
		return new(result);
	}

	private static IEnumerable<Monkey> GetMonkeys(string[] rows, Dictionary<int, IOperation> operations)
	{
		for (var i = 0; i < rows.Length; i += 7)
		{
			var monkey = int.Parse(rows[i][^2].ToString());
			var items = rows[(i + 1)][18..].ToString().Split(", ").Select(x => double.Parse(x)).ToList();
			var ifTrueMonkey = int.Parse(rows[(i + 4)][29..].ToString());
			var ifFalseMonkey = int.Parse(rows[(i + 5)][30..].ToString());
			yield return new Monkey
			{
				Items = new Queue<double>(items),
				Operation = operations[monkey],
				IfTrue = ifTrueMonkey,
				IfFalse = ifFalseMonkey
			};
		}
	}
}