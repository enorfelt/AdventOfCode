public class PartTwo
{
	public static void Run(string[] input)
	{
		var groups = new List<Group>();
		for (int i = 0; i < input.Length; i += 3)
		{
			groups.Add(new Group(
				input[i],
				input[i + 1],
				input[i + 2]
			));
		}
		Console.WriteLine($"Part 2: {groups.Select(g => g.BadgePriority).Sum()}");
	}
}