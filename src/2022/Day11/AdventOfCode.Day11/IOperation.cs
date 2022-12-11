// See https://aka.ms/new-console-template for more information

namespace AdventOfCode.Day11;

public interface IOperation
{
	int ForMonkey { get; }
	int Mod { get; }
	double Operation(double old);
	bool Test(double item);
}
