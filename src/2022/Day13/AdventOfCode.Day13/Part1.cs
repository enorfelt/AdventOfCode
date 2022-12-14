using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace AdventOfCode.Day13;

public class Part1
{
	public static int Run(string[] input)
	{
		var pairs = new List<PacketPair>();
		var span = input.AsSpan();
		var index = 0;
		for (var i = 0; i < span.Length; i +=3)
		{
			pairs.Add(new PacketPair()
			{
				Index = ++index,
				Left = new(span[i]),
				Right = new(span[i+1])
			});
		}

		return pairs.Where(p => p.IsInOrder()).Select(p => p.Index).Sum();
	}
}
