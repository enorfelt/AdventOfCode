namespace AdventOfCode.Day13;

public class Part2
{
	public static int Run(string[] input)
	{
		var packets = new List<Packet>()
		{
			new Packet("[[2]]", true),
			new Packet("[[6]]", true)
		};
		var span = input.AsSpan();
		foreach(var line in input)
		{
			if (string.IsNullOrEmpty(line))
			{
				continue;
			}

			packets.Add(new Packet(line));
		}

		packets.Sort();

		var dividerIndexes = packets.Select((p, index) => new {Packet = p, Index = index + 1}).Where(p => p.Packet.IsDivider).ToList();
		var result = dividerIndexes[0].Index * dividerIndexes[1].Index;

		return result;
	}
}
