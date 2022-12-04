using AdventOfCode.Common;

public record struct ElfPair(Elf Elf1, Elf Elf2)
{
	public bool IntersectsFully => Elf1.Section.Containes(Elf2.Section) || Elf2.Section.Containes(Elf1.Section);
	public bool IntersectsPartially => Elf1.Section.Intersects(Elf2.Section);

	internal static ElfPair Create(string line)
	{
		var assignedSectionsForGroup = line.Split(",");
		var elf1 = Elf.AssignSection(assignedSectionsForGroup[0].Split('-'));
		var elf2 = Elf.AssignSection(assignedSectionsForGroup[1].Split('-'));
		return new ElfPair(elf1, elf2);
	}
}
