// See https://aka.ms/new-console-template for more information

namespace AdventOfCode.Day11;

public class Monkey7Operation : IOperation
{
	public int ForMonkey => 7;

	public int Mod => 2;

	public double Operation(double old)
	{
		return old + 5;
	}

	public bool Test(double item)
	{
		return item % Mod == 0;
	}
}
