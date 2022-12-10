
namespace AdventOfCode.Day10
{
	public record Result(int SignalStrengths);
	public class Part1
	{
		public static Result Run(string[] input)
		{
			var registry = new Registry();
			var clockCircuit = new ClockCircuit(registry);
			using var crt = new Crt(clockCircuit, registry);
			var instructions = GetInstructions(input, registry, clockCircuit);
			foreach (var instruction in instructions)
			{
				instruction.Run();
			}

			crt.Print();
			
			return new(clockCircuit.SignalStrengths.Sum());
		}

		private static IEnumerable<IInstruction> GetInstructions(string[] lines, Registry registry, ClockCircuit clockCircuit)
		{
			foreach (var line in lines)
			{
				if (line.StartsWith("noop"))
				{
					yield return new NoopInstruction(clockCircuit);
				}
				else
				{
					yield return new AddxInstruction(clockCircuit, registry)
					{
						Value = int.Parse(line[5..])
					};
				}
			}
		}
	}
}