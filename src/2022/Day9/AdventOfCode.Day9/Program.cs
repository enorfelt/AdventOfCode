// See https://aka.ms/new-console-template for more information
using AdventOfCode.Day9;

var lines = File.ReadAllLines("Input.txt");

Console.WriteLine(Part1.Run(lines).Tail.NumPositionsVisited);
