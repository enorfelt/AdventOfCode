namespace AdventOfCode.Day5
{
	public class CargoCrane9001 : ICrane
	{
		public void Move(int amount, Stack<Crate> to, Stack<Crate> from)
		{
			var itemsToMove = from.PopRange(amount);
			to.PushRange(itemsToMove);
		}
	}
}