namespace AdventOfCode.Day5.Tests;

public class Day5Tests
{
	[Fact]
	public async Task ShouldReturnCorrectMessageForPart1()
	{
		var input = await File.ReadAllLinesAsync("TestInput.txt");

		var message = CargoMover.Move(input, new CargoConfiguration { StackHeight = 3, NumberOfStacks = 3, InstructionsStartRow = 6 }, new CargoCrane9000());

		Assert.Equal("CMZ", message);
	}

	[Fact]
	public async Task ShouldReturnCorrectMessageForPart2()
	{
		var input = await File.ReadAllLinesAsync("TestInput.txt");

		var message = CargoMover.Move(input, new CargoConfiguration { StackHeight = 3, NumberOfStacks = 3, InstructionsStartRow = 6 }, new CargoCrane9001());

		Assert.Equal("MCD", message);
	}
}