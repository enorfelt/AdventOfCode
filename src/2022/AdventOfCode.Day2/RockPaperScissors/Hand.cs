public abstract class HandBase
{
	public abstract HandEnum Hand { get; }

	public abstract HandEnum WinsOver { get; }

	public abstract HandEnum LosesTo { get; }

	public int Score => (int)Hand;

	public ResultEnum WinLosOrDraw(HandBase opponents)
	{
		if (WinsOver == opponents.Hand)
		{
			return ResultEnum.Win;
		}

		if (LosesTo == opponents.Hand) 
		{
			return ResultEnum.Loss;
		}

		return ResultEnum.Draw;
	}
}
