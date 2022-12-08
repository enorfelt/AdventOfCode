namespace AdventOfCode.Day8;

public class TreeInspector
{
	public static Result Inspect(string[] input)
	{
		var trees = new Tree[input.Length, input[0].Length];
		var treesFlat = new List<Tree>();
		var rows = input.AsSpan();
		for (var y = 0; y < rows.Length; y++)
		{
			var row = rows[y].AsSpan();
			for (var x = 0; x < row.Length; x++)
			{
				var up = y > 0 ? trees[y - 1, x] : null;
				var left = x > 0 ? trees[y, x - 1] : null;
				var height = int.Parse(row[x].ToString());
				var tree = Tree.Create(x, y, height, left, up);
				treesFlat.Add(tree);
				trees[y, x] = tree;
			}
		}

		return new Result(treesFlat.Where(t => t.IsVisible).Count(), treesFlat.Max(t => t.ScenicScore));
	}
}
