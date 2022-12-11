// See https://aka.ms/new-console-template for more information
using AdventOfCode.Day11;
var operations = new Dictionary<int, IOperation>
		{
			{ 0, new Monkey0Operation() },
			{ 1, new Monkey1Operation() },
			{ 2, new Monkey2Operation() },
			{ 3, new Monkey3Operation() },
			{ 4, new Monkey4Operation() },
			{ 5, new Monkey5Operation() },
			{ 6, new Monkey6Operation() },
			{ 7, new Monkey7Operation() }
		};
var lines = File.ReadAllLines("Input.txt");
Console.WriteLine(Part1.Run(lines, operations));
Console.WriteLine(Part2.Run(lines, operations));
