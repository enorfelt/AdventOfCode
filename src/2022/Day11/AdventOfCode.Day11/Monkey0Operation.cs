// See https://aka.ms/new-console-template for more information

namespace AdventOfCode.Day11;

public class Monkey0Operation : IOperation
{
	public int ForMonkey => 0;

	public int Mod => 11;

	public double Operation(double old)
	{
		return old * 2;
	}

	public bool Test(double item)
	{
		return item % Mod == 0;
	}
}
