namespace AdventOfCode.Day5
{
	public record struct MoveInstruction(int Amount, int From, int To)
	{
		public static MoveInstruction Create(string instructionsRow)
		{
			var instructionsList = instructionsRow.Split(" ");
			var amountToMove = int.Parse(instructionsList[1]);
			var from = int.Parse(instructionsList[3]) - 1;
			var to = int.Parse(instructionsList[5]) - 1;
			return new MoveInstruction(amountToMove, from, to);

		}
	}
}