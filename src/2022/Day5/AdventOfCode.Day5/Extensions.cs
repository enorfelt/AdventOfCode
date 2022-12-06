namespace AdventOfCode.Day5
{
	public static class Extensions
	{
		public static List<T> PopRange<T>(this Stack<T> stack, int amount)
		{
			var result = new List<T>(amount);
			while (amount-- > 0 && stack.Count > 0)
			{
				result.Add(stack.Pop());
			}
			return result;
		}

		public static void PushRange<T>(this Stack<T> stack, IEnumerable<T> values)
		{
			var reversed = values.Reverse();
			foreach(var item in reversed)
			{
				stack.Push(item);
			}
		}
	}
}