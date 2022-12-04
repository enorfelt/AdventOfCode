namespace AdventOfCode.Common;
public class ElfsProvider
{
	public static IEnumerable<Elf> CreateElfs(string[] input)
	{
		return CaloriesPerElf(input).Select((calories, index) => Elf.Create(calories, index));
	}

	private static IEnumerable<int> CaloriesPerElf(string[] lines)
	{
		var totalCalories = 0;
		foreach (var line in lines)
		{
			if (!int.TryParse(line, out var calories))
			{
				yield return totalCalories;
				totalCalories = 0;
			}
			totalCalories += calories;
		}
	}
}