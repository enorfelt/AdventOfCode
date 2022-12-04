public class HandFactory
{
	public static HandBase Create(char handChar)
	{
		return Create(Helpers.ToHand(handChar));
	}

	public static HandBase Create(HandEnum handEnum)
	{
		if (handEnum == HandEnum.Rock)
		{
			return new Rock();
		}
		if (handEnum == HandEnum.Paper)
		{
			return new Paper();
		}
		return new Scissors();
	}

	public static HandBase CreateForResult(HandBase opponentsHand, ResultEnum wantedResult)
	{
		if (wantedResult == ResultEnum.Win)
		{
			return Create(opponentsHand.LosesTo);
		}
		if (wantedResult == ResultEnum.Loss) 
		{
			return Create(opponentsHand.WinsOver);
		}
		return Create(opponentsHand.Hand);
	}
}
