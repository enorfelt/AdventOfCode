// See https://aka.ms/new-console-template for more information

namespace AdventOfCode.Day12;
public class Part1
{
	public static Result Run(string[] input)
	{
		var map = new HeightMap(input);

		var result = map.FindShortestPathFromStart();

		return new(result, map);
	}
}
