namespace AdventOfCode.Day5
{

	public class CargoMover
	{
		public static string Move(string[] input, CargoConfiguration config, ICrane crane)
		{
			var cargoBay = new Cargobay(input, config);
			var ship = new Ship(cargoBay, crane);

			var instructions = CreateInstructions(input.Where((x, i) => i >= config.InstructionsStartRow - 1).ToArray());

			ship.MoveCargo(instructions);
			
			return ship.CargoMessage;
		}

		public static IEnumerable<MoveInstruction> CreateInstructions(string[] rows)
		{
			for(var i = 0; i < rows.Length; i++)
			{
				yield return MoveInstruction.Create(rows[i]);
			}
		}
	}
}