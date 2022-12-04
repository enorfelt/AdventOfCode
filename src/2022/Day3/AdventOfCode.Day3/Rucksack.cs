public class Rucksack
{
	private readonly string line;

	public Rucksack(string line)
	{
		this.line = line;
		var lineLenght = this.line.Length;
		var half = lineLenght / 2;
		Compartment1 = new Compartment(line.Substring(0, half));
		Compartment2 = new Compartment(line.Substring(half));
	}
	public string Content => this.line;
	private Compartment Compartment1 { get; set; }
	private Compartment Compartment2 { get; set; }

	public int CommonItemTypePriority => FindCommonPriority();

	private int FindCommonPriority()
	{
		var commonItems = Compartment1.ItemTypes.IntersectBy(Compartment2.ItemTypes.Select(x => x.Priority), x => x.Priority);
		if (commonItems.Count() != 1)
		{
			throw new Exception("Wrong number of items");
		}
		return commonItems.First().Priority;
	}
}