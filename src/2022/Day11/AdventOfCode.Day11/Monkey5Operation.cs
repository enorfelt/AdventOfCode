// See https://aka.ms/new-console-template for more information

namespace AdventOfCode.Day11;

public class Monkey5Operation : IOperation
{
	public int ForMonkey => 5;

	public int Mod => 5;

	public double Operation(double old)
	{
		return old + 7;
	}

	public bool Test(double item)
	{
		return item % Mod == 0;
	}
}
