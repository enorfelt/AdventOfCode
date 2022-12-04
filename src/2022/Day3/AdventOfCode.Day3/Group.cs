internal class Group
{
	private Rucksack rucksack1;
	private Rucksack rucksack2;
	private Rucksack rucksack3;

	public Group(string v1, string v2, string v3)
	{
		this.rucksack1 = new Rucksack(v1);
		this.rucksack2 = new Rucksack(v2);
		this.rucksack3 = new Rucksack(v3);
	}

	public int BadgePriority => FindBadePriority();

	private int FindBadePriority()
	{
		var listOfLists = new List<List<char>>() 
		{ 
			rucksack1.Content.Select(x => x).ToList(),
			rucksack2.Content.Select(x => x).ToList(),
			rucksack3.Content.Select(x => x).ToList() 
		};
		var intersection = listOfLists.Aggregate((previousList, nextList) => previousList.Intersect(nextList).ToList());
		if (intersection.Count() != 1)
		{
			throw new Exception("Wrong number of items");
		}
		return "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(intersection.First()) + 1;

	}
}