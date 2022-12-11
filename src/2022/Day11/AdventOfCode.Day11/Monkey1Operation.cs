// See https://aka.ms/new-console-template for more information

namespace AdventOfCode.Day11;

public class Monkey1Operation : IOperation
{
	public int ForMonkey => 1;

	public int Mod => 19;

	public double Operation(double old)
	{
		return old * old;
	}

	public bool Test(double item)
	{
		return item % Mod == 0;
	}
}
