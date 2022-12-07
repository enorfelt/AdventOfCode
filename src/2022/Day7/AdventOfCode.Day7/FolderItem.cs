namespace AdventOfCode.Day7
{
	public abstract class FolderItem
	{
		public FolderItem(string name, Folder? parent)
		{
			Name = name;
			Parent = parent;
		}
		public abstract bool IsFolder { get; }
		public abstract int Size { get; }
		public string Name { get; private set; }
		public bool IsRoot => Parent is null;
		public Folder? Parent { get; private set; }
	}
}
