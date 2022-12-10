namespace AdventOfCode.Day9;

public class Part1
{
	public static Result Run(string[] input, int numberOfKnots = 1)
	{
		var knots = new List<Knot>();
		for (var i = 0; i < numberOfKnots; i++)
		{
			knots.Add(new(new Position(0, 0), (i+1).ToString()));
		}

		var rope = new Rope
		{
			Head = new(new Position(0, 0), "Head"),
			Knots = knots
		};

		var instructions = GetInstructions(input);
		foreach (var instruction in instructions)
		{
			//Console.WriteLine(instruction.ToString());
			for (var i = 0; i < instruction.Steps; i++)
			{
				rope.MoveHead(instruction.Direction);
				rope.MoveKnots();
				//Console.Clear();
				//Console.WriteLine(instruction);
				//for (var y = 15; y > -15; y--)
				//{
				//	for (var x = -15; x < 15; x++)
				//	{
				//		var position = new Position(x, y);
				//		var toPrint = ".";
				//		var knot = rope.Knots.FirstOrDefault(x => x.CurrentPosition.Equals(position));
				//		if (knot != null)
				//		{
				//			toPrint = knot.Id;
				//		}
				//		if (rope.Head.CurrentPosition.Equals(position))
				//		{
				//			toPrint = "H";
				//		}
				//		Console.Write(toPrint);
				//	}
				//	Console.WriteLine();
				//}
				//Console.ReadLine();
			}


		}

		return new Result(rope.Head, rope.Knots.Last(), rope.Knots);
	}

	private static IEnumerable<MoveInstruction> GetInstructions(string[] lines)
	{
		foreach (var line in lines)
		{
			var steps = int.Parse(line[2..].ToString());

			switch (line[0])
			{
				case 'R':
					yield return new MoveInstruction(DirectionEnum.R, steps);
					break;
				case 'L':
					yield return new MoveInstruction(DirectionEnum.L, steps);
					break;
				case 'U':
					yield return new MoveInstruction(DirectionEnum.U, steps);
					break;
				case 'D':
					yield return new MoveInstruction(DirectionEnum.D, steps);
					break;
				default:
					throw new ArgumentException("No matching instruction", nameof(lines));
			}
		}
	}
}
