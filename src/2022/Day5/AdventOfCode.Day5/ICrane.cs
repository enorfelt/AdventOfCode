namespace AdventOfCode.Day5
{
	public interface ICrane
	{
		public abstract void Move(int amount, Stack<Crate> to, Stack<Crate> from);
	}
}