// See https://aka.ms/new-console-template for more information

namespace AdventOfCode.Day11;

public class Part2
{
	public static Result Run(string[] input, Dictionary<int, IOperation> operations)
	{
		var mod = operations.Select(x => x.Value).Select(v => v.Mod).Aggregate(1, (x, y) => x * y);
		return MonkeyBusinessCalculator.Calculate(input, operations, (item) => item % mod, 10000);
	}
}