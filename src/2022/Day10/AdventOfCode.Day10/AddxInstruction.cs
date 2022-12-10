namespace AdventOfCode.Day10
{
	internal class AddxInstruction : IInstruction
	{
		private readonly ClockCircuit clockCircuit;
		private readonly Registry registry;

		public AddxInstruction(ClockCircuit clockCircuit, Registry registry)
		{
			this.clockCircuit = clockCircuit;
			this.registry = registry;
		}
		required public int Value { get; init; }

		public void Run()
		{
			clockCircuit.Cycle();
			clockCircuit.Cycle();
			registry.Add(Value);
		}
	}
}