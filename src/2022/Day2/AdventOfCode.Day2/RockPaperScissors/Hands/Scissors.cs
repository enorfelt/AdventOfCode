public class Scissors : HandBase
{
	public override HandEnum Hand => HandEnum.Scissors;
	public override HandEnum WinsOver => HandEnum.Paper;
	public override HandEnum LosesTo => HandEnum.Rock;
}