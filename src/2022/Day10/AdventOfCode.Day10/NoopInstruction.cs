namespace AdventOfCode.Day10
{
	internal class NoopInstruction : IInstruction
	{
		private readonly ClockCircuit clockCircuit;

		public NoopInstruction(ClockCircuit clockCircuit)
		{
			this.clockCircuit = clockCircuit;
		}

		public void Run()
		{
			clockCircuit.Cycle();
		}
	}
}