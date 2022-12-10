
namespace AdventOfCode.Day10
{
	public class OnCycleEventsArgs : EventArgs
	{
		required public int Cycle { get; init; }
	}

	public class ClockCircuit
	{
		private static ClockCircuit? _instance;
		private readonly List<int> _signalStrenghts = new();
		private int cycleChecks = 20;

		private readonly object _lock = new object();

		public event EventHandler? OnCycle;

		private ClockCircuit()
		{
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
					var signalStrength = Cycles * Registry.GetInstance().X;
					_signalStrenghts.Add(signalStrength);
					cycleChecks += 40;
				}
			}
		}

		public static ClockCircuit GetInstance()
		{
			if (_instance == null)
			{
				_instance = new ClockCircuit();
			}
			return _instance;
		}
	}
}