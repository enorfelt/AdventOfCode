
namespace AdventOfCode.Day10
{
	public class OnCycleEventsArgs : EventArgs
	{
		required public int Cycle { get; init; }
	}

	public class ClockCircuit
	{
		private readonly List<int> _signalStrenghts = new();
		private int cycleChecks = 20;

		private readonly object _lock = new object();
		private readonly Registry registry;

		public event EventHandler? OnCycle;

		public ClockCircuit(Registry registry)
		{
			this.registry = registry;
		}

		public int Cycles { get; private set; }

		public List<int> SignalStrengths => _signalStrenghts;

		public void Cycle()
		{
			lock (_lock)
			{
				Cycles++;
				OnCycle?.Invoke(this, new OnCycleEventsArgs { Cycle = Cycles });
				if (Cycles == cycleChecks)
				{
					var signalStrength = Cycles * registry.X;
					_signalStrenghts.Add(signalStrength);
					cycleChecks += 40;
				}
			}
		}
	}
}