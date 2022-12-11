// See https://aka.ms/new-console-template for more information

namespace AdventOfCode.Day11;

public class MonkeyBusinessCalculator
{
	public static Result Calculate(string[] input, Dictionary<int, IOperation> operations, Func<double, double> reducer, int numOfRounds = 20)
	{
		var monkeys = GetMonkeys(input, operations, reducer).ToList();
		for (var i = 0; i < numOfRounds; i++)
		{
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

	private static IEnumerable<Monkey> GetMonkeys(string[] rows, Dictionary<int, IOperation> operations, Func<double, double> reducer)
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
				Reducer = reducer,
				IfTrue = ifTrueMonkey,
				IfFalse = ifFalseMonkey
			};
		}
	}
}
