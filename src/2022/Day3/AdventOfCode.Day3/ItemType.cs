internal class ItemType
{
	private char item;

	public ItemType(char item)
	{
		this.item = item;
	}

	public char Item => item;
	public int Priority => "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(Item) + 1;
}