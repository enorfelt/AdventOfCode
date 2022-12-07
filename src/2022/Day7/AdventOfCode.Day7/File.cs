namespace AdventOfCode.Day7
{
	public class File : FolderItem
	{
		public File(string name, int size, Folder? parent)
			: base(name, parent)
		{
			Size = size;
		}
		public override bool IsFolder => false;
		public override int Size { get; }
	}
}
