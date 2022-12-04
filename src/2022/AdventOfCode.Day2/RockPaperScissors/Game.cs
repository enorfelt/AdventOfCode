using Microsoft.VisualBasic;

public class Game
{
	private Game(HandBase myHand, HandBase opponentsHand) 
	{
		MyHand= myHand;
		OpponentsHand= opponentsHand;
	}
	public HandBase MyHand { get; private set; }
	public HandBase OpponentsHand { get; private set; }
	public ResultEnum Result => MyHand.WinLosOrDraw(OpponentsHand);
	public int MyScore => (int)MyHand.Score + (int)Result;
	public static Game Create(char opponent, char me)
	{
		return new Game(HandFactory.Create(me), HandFactory.Create(opponent));
	}

	public static Game CreateFromResult(char opponentsHandChar, char wantedResult)
	{
		var opponentsHand = HandFactory.Create(opponentsHandChar);
		var myHand = HandFactory.CreateForResult(opponentsHand, Helpers.ToResult(wantedResult));
		return new Game(myHand, opponentsHand);
	}
}
