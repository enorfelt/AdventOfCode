namespace AdventOfCode.Day13;

public class PacketPair
{
	required public int Index { get; init; }
	required public Packet Left { get; init; }
	required public Packet Right { get; init; }
	public bool IsInOrder()
	{
		return Left.CompareTo(Right) == -1;
	}
}
