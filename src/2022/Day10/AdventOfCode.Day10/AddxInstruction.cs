namespace AdventOfCode.Day10
{
	internal class AddxInstruction : IInstruction
	{
		required public int Value { get; init; }

		public void Run()
		{
			ClockCircuit.GetInstance().Cycle();
			ClockCircuit.GetInstance().Cycle();
			Registry.GetInstance().Add(Value);
		}
	}
}