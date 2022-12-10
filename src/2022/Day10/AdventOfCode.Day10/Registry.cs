
namespace AdventOfCode.Day10
{
	public class RegistryUpdatedEventArgs : EventArgs 
	{
		required public int X { get; init; }
	}

	public class Registry
	{
		private readonly object _lock = new object();
		private static Registry? _instance;
		private Registry()
		{
			X = 1;
		}

		public EventHandler<RegistryUpdatedEventArgs>? OnRegistryUpdated;

		public int X { get; private set; }

		public void Add(int value)
		{
			lock (_lock)
			{
				X += value;
				OnRegistryUpdated?.Invoke(this, new RegistryUpdatedEventArgs { X = X });
			}
		}
		public static Registry GetInstance()
		{
			if (_instance == null)
			{
				_instance = new Registry();
			}
			return _instance;
		}
	}
}