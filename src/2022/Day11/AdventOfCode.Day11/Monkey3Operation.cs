// See https://aka.ms/new-console-template for more information

namespace AdventOfCode.Day11;

public class Monkey3Operation : IOperation
{
	public int ForMonkey => 3;

	public int Mod => 17;

	public double Operation(double old)
	{
		return old + 2;
	}

	public bool Test(double item)
	{
		return item % Mod == 0;
	}
}
