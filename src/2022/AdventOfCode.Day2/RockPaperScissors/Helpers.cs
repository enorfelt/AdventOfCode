internal static class Helpers
{
	public static HandEnum ToHand(char hand)
	{
		switch (hand)
		{
			case 'X':
			case 'A':
				return HandEnum.Rock;
			case 'Y':
			case 'B':
				return HandEnum.Paper;
			case 'Z':
			case 'C':
				return HandEnum.Scissors;
			default:
				throw new Exception("Value not allowed");
		}
	}

	public static ResultEnum ToResult(char v)
	{
		switch (v)
		{
			case 'X':
				return ResultEnum.Loss;
			case 'Y':
				return ResultEnum.Draw;
			case 'Z':
				return ResultEnum.Win;
			default:
				throw new Exception("Value not allowed");
		}
	}
}