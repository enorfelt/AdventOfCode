public class PartOne
{
	public static void Run(string[] input)
	{
		var games = input.Select(line => Game.Create(line[0], line[2]));
		Console.WriteLine(games.Select(g => g.MyScore).Sum());
	}
}
