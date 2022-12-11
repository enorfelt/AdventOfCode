// See https://aka.ms/new-console-template for more information

namespace AdventOfCode.Day11;

public class Monkey6Operation : IOperation
{
	public int ForMonkey => 6;

	public int Mod => 13;

	public double Operation(double old)
	{
		return old + 1;
	}

	public bool Test(double item)
	{
		return item % Mod == 0;
	}
}
