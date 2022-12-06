namespace AdventOfCode.Day5
{
	public class CargoCrane9000 : ICrane
	{
		public void Move(int amount, Stack<Crate> to, Stack<Crate> from)
		{
			for (var i = 0; i < amount; i++)
			{
				to.Push(from.Pop());
			}
		}
	}
}