// See https://aka.ms/new-console-template for more information

namespace AdventOfCode.Day11;

public class Monkey
{
	private double seenItems = 0;
	required public int IfTrue { get; init; }
	required public int IfFalse { get; init; }
	required public Queue<double> Items { get; init; }
	required public IOperation Operation { get; init; }
	required public Func<double, double> Reducer { get; init; }
	public double SeenItems => seenItems;
	public (int Monkey, double Item) Throw()
	{
		seenItems++;
		var item = Items.Dequeue();
		item = Operation.Operation(item);
		item = Reducer(item);
		if (Operation.Test(item))
		{
			return ((IfTrue, item));
		}
		return (IfFalse, item);
	}
	public void Catch(double item)
	{
		Items.Enqueue(item);
	}

}
