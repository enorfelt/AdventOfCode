// See https://aka.ms/new-console-template for more information

namespace AdventOfCode.Day11;

public class Monkey2Operation : IOperation
{
	public int ForMonkey => 2;

	public int Mod => 7;

	public double Operation(double old)
	{
		return old + 6;
	}

	public bool Test(double item)
	{
		return item % Mod == 0;
	}
}
