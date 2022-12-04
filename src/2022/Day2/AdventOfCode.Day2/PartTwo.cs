public class PartTwo
{
	public static void Run(string[] input)
	{
		var games = input.Select(line => Game.CreateFromResult(line[0], line[2]));
		Console.WriteLine(games.Select(g => g.MyScore).Sum());
	}
}