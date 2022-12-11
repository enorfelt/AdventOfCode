// See https://aka.ms/new-console-template for more information

namespace AdventOfCode.Day11;
public class Part1
{
	public static Result Run(string[] input, Dictionary<int, IOperation> operations)
	{
		return MonkeyBusinessCalculator.Calculate(input, operations, (item) => (int)(item / 3));
	}
}
