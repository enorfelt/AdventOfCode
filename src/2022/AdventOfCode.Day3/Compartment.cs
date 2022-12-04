using System.Reflection.Metadata.Ecma335;

internal class Compartment
{
	private readonly IEnumerable<ItemType> itemTypes;

	public Compartment(string items)
	{
		this.itemTypes = items.Select(i => new ItemType(i));
	}

	public IEnumerable<ItemType> ItemTypes => itemTypes;
}