namespace AdventOfCode.Day5
{
	public class Cargobay
	{
		private readonly List<Stack<Crate>> stacks = new List<Stack<Crate>>();
		private readonly CargoConfiguration config;

		public Cargobay(Span<string> input, CargoConfiguration config)
		{
			this.config = config;
			Init(input);
		}

		public List<Stack<Crate>> CrateStacks => stacks;

		private void Init(Span<string> input)
		{
			CreateStacks();
			FillStacks(input);
		}

		private void FillStacks(Span<string> input)
		{
			var cratesRows = input.Slice(0, config.StackHeight);

			for (var i = config.StackHeight - 1; i >= 0; i--)
			{
				var createsRow = cratesRows[i];
				for (var j = 0; j < config.NumberOfStacks; j++)
				{
					var start = j * 4;
					var cargo = createsRow.Substring(start, 3)[1];
					if (cargo == ' ')
					{
						continue;
					}
					var stack = stacks[j];
					stack.Push(new Crate { Content = cargo });
				}
			}
		}

		private void CreateStacks()
		{
			for (var i = 0; i < config.NumberOfStacks; i++)
			{
				stacks.Add(new Stack<Crate>());
			}
		}
	}
}