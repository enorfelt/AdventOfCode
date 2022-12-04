public class Rock : HandBase
{
	public override HandEnum Hand => HandEnum.Rock;
	public override HandEnum WinsOver => HandEnum.Scissors;
	public override HandEnum LosesTo => HandEnum.Paper;
}
