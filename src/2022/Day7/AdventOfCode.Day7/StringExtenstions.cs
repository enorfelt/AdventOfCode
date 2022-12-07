namespace AdventOfCode.Day7
{
	public static class StringExtenstions
	{
		public static bool IsCommand(this string line)
		{
			return line.StartsWith("$");
		}
		public static bool IsLsCommand(this string line)
		{
			return line.StartsWith("$ ls");
		}
		public static bool IsCdCommand(this string line)
		{
			return line.StartsWith("$ cd");
		}
		public static bool IsDir(this string line)
		{
			return line.StartsWith("dir");
		}
		public static string ToFolderName(this string line)
		{
			return line.Replace("dir ", "").Replace("$ cd ", "");
		}
		public static (string Name, int Size) ToFileInfo(this string line)
		{
			var fileInfo = line.Split(" ");
			var fileName = fileInfo[1];
			var fileSize = int.Parse(fileInfo[0]);
			return (fileName, fileSize);
		}
	}
}
