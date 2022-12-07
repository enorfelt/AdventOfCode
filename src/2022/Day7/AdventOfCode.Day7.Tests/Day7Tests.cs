namespace AdventOfCode.Day7.Tests
{
	public class Day7Tests
	{
		[Fact]
		public void ShouldCalculateSumOfSmallestFolders()
		{
			var input = System.IO.File.ReadAllLines("TestInput.txt");

			var result = DiskTraverser.Run(input);

			Assert.Equal(95437, result.SumOfSmallestFolders);
		}

		[Fact]
		public void ShouldFindSizeOfFolderForDeletion()
		{
			var input = System.IO.File.ReadAllLines("TestInput.txt");

			var result = DiskTraverser.Run(input);

			Assert.Equal(24933642, result.FolderForDeletaionSize);
		}
	}
}