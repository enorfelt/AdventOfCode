namespace AdventOfCode.Common;

public struct Elf
{
	public int Name { get; private set; }
	public int TotalCalories { get; private set; }
	public Section Section { get; private set; }

	public static Elf AssignSection(string[] sectionBounderies)
	{
		var start = int.Parse(sectionBounderies[0]);
		var end = int.Parse(sectionBounderies[1]);
		return new Elf()
		{
			Section = new Section(start, end),
		};
	}

	internal static Elf Create(int calories, int index)
	{
		return new Elf
		{
			Name = index,
			TotalCalories = calories
		};
	}
}