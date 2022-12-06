namespace AdventOfCode.Day5
{
	public class Ship
	{
		private readonly Cargobay cargobay;
		private readonly ICrane crane;

		public Ship(Cargobay cargobay, ICrane crane)
		{
			this.cargobay = cargobay;
			this.crane = crane;
		}

		public string CargoMessage => string.Join(string.Empty, cargobay.CrateStacks.Select(x => x.Peek().Content));

		internal void MoveCargo(IEnumerable<MoveInstruction> instructions)
		{
			foreach(var instruction in instructions)
			{
				crane.Move(instruction.Amount, cargobay.CrateStacks[instruction.To], cargobay.CrateStacks[instruction.From]);
			}
		}
	}
}