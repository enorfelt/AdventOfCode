// See https://aka.ms/new-console-template for more information

namespace AdventOfCode.Day11;

public class Monkey4Operation : IOperation
{
	public int ForMonkey => 4;

	public int Mod => 3;

	public double Operation(double old)
	{
		return old * 11;
	}

	public bool Test(double item)
	{
		return item % Mod == 0;
	}
}
