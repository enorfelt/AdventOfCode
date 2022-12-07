namespace AdventOfCode.Day7
{
	public class DiskTraverser
	{
		public static Result Run(string[] input)
		{
			var foldersFlat = new List<Folder>();
			var root = new Folder("root", null);
			foldersFlat.Add(root);

			var lines = input.AsSpan()[1..];
			var currentDirectory = root;
			var currentCommand = "$ cd /";
			foreach (var line in lines)
			{
				if (line.IsCommand())
				{
					currentCommand = line;
				}
				if (currentCommand.IsLsCommand())
				{
					CreateFileOrFolder(foldersFlat, currentDirectory, line);
				}
				if (currentCommand.IsCdCommand())
				{
					currentDirectory = ChangeDirectory(currentDirectory, currentCommand);
				}
			}

			var sumOfSmallestFolders = foldersFlat.Where(f => f.Size <= 100000).Select(x => x.Size).Sum();

			var usedSpace = root.Size;
			var totalDiskSpace = 70000000;
			var neededSpace = 30000000;
			var freeSpace = totalDiskSpace - usedSpace;
			var diff = neededSpace - freeSpace;

			var foldersBySize = foldersFlat.OrderBy(x => x.Size);
			var folderForDeletaionSize = foldersBySize.First(x => diff - x.Size <= 0).Size;

			return new Result(sumOfSmallestFolders, folderForDeletaionSize);
		}

		private static void CreateFileOrFolder(List<Folder> foldersFlat, Folder? currentDirectory, string line)
		{
			if (line.IsLsCommand())
			{
				return;
			}
			if (line.IsDir())
			{
				CreateFolder(foldersFlat, currentDirectory, line);
			}
			else
			{
				CreateFile(currentDirectory, line);
			}
		}

		private static void CreateFile(Folder? currentDirectory, string line)
		{
			var (Name, Size) = line.ToFileInfo();
			var file = new File(Name, Size, currentDirectory);
			currentDirectory?.AddItem(file);
		}

		private static void CreateFolder(List<Folder> foldersFlat, Folder? currentDirectory, string line)
		{
			var folder = new Folder(line.ToFolderName(), currentDirectory);
			foldersFlat.Add(folder);
			currentDirectory?.AddItem(folder);
		}

		private static Folder? ChangeDirectory(Folder? currentDirectory, string currentCommand)
		{
			var directoryName = currentCommand.ToFolderName();
			if (directoryName == "..")
			{
				return currentDirectory?.Parent;
			}
			else
			{
				return currentDirectory?.FolderItems.Where(x => x.IsFolder && x.Name == directoryName).First() as Folder;
			}
		}
	}
}
