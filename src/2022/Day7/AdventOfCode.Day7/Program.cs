// See https://aka.ms/new-console-template for more information
using AdventOfCode.Day7;

var input = System.IO.File.ReadAllLines("Input.txt");

var result = DiskTraverser.Run(input);

Console.WriteLine(result);