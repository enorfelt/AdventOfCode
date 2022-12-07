namespace AdventOfCode.Day7
{
	public class Folder : FolderItem
	{
		public Folder(string name, Folder? parent)
			: base(name, parent)
		{
			FolderItems = new List<FolderItem>();
		}
		public override bool IsFolder => true;
		public override int Size => FolderItems.Select(x => x.Size).Sum();
		public List<FolderItem> FolderItems { get; private set; }
		public void AddItem(FolderItem item)
		{
			FolderItems.Add(item);
		}
	}
}
