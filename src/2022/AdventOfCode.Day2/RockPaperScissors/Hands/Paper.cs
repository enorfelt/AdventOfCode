public class Paper : HandBase
{
	public override HandEnum Hand => HandEnum.Paper;
	public override HandEnum WinsOver => HandEnum.Rock;
	public override HandEnum LosesTo => HandEnum.Scissors;
}
