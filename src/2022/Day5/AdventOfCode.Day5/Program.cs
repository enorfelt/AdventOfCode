using AdventOfCode.Day5;

var lines = File.ReadAllLines("Input.txt");
Console.WriteLine("Day5");
var cargoConfig = new CargoConfiguration { InstructionsStartRow = 11, NumberOfStacks = 9, StackHeight = 8 };
Console.WriteLine(CargoMover.Move(lines, cargoConfig, new CargoCrane9000()));
Console.WriteLine(CargoMover.Move(lines, cargoConfig, new CargoCrane9001()));
