namespace AdventOfCode.Day10
{
	internal class NoopInstruction : IInstruction
	{

		public void Run()
		{
			ClockCircuit.GetInstance().Cycle();
		}
	}
}