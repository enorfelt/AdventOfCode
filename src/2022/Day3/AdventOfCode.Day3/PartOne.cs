public class PartOne
{
	public static void Run(string[] input)
	{
		var rucksacks = input.Select(line => new Rucksack(line)).ToList(); ;
		Console.WriteLine($"Part 1; {rucksacks.Select(r => r.CommonItemTypePriority).Sum()}");
	}
}
