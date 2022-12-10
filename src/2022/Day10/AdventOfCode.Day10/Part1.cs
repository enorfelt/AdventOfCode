
namespace AdventOfCode.Day10
{
	public record Result(int SignalStrengths);
	public class Part1
	{
		public static Result Run(string[] input)
		{
			using var crt = new Crt();
			var instructions = GetInstructions(input);
			foreach (var instruction in instructions)
			{
				instruction.Run();
			}

			crt.Print();
			
			return new(ClockCircuit.GetInstance().SignalStrengths.Sum());
		}

		private static IEnumerable<IInstruction> GetInstructions(string[] lines)
		{
			foreach (var line in lines)
			{
				if (line.StartsWith("noop"))
				{
					yield return new NoopInstruction();
				}
				else
				{
					yield return new AddxInstruction
					{
						Value = int.Parse(line[5..])
					};
				}
			}
		}
	}
}