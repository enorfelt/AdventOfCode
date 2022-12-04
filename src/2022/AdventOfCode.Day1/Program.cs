using AdventOfCode.Common;

var input = File.ReadAllLines("Input.txt");

var elfs = ElfsProvider.CreateElfs(input).OrderByDescending(x => x.TotalCalories);

Console.WriteLine($"The elf {elfs.First().Name} has the most calories with {elfs.First().TotalCalories} calories");
Console.WriteLine($"The top three elfs carries a total of {elfs.Take(3).Select(x => x.TotalCalories).Sum()} calories");

Console.Read();