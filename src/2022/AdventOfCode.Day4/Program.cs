var lines = File.ReadAllLines("Input.txt").AsSpan();
var elfPairs = new List<ElfPair>();
foreach (var line in lines)
{
	elfPairs.Add(ElfPair.Create(line));
}
Console.WriteLine(elfPairs.Where(x => x.IntersectsFully).Count()); // 573
Console.WriteLine(elfPairs.Where(x => x.IntersectsPartially).Count()); // 867