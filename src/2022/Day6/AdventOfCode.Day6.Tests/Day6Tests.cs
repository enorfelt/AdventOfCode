namespace AdventOfCode.Day6.Tests
{
	public class Day6Tests
	{
		[Theory]
		[InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
		[InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
		[InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
		[InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
		public void ShouldDetectStartOfPacketMarker(string input, int expected)
		{
			var result = MarkerDetector.Detect(input, 4);

			Assert.Equal(expected, result);
		}

		[Theory]
		[InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
		[InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
		[InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
		[InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
		[InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
		public void ShouldDetectStartOfMessageMarker(string input, int expected)
		{
			var result = MarkerDetector.Detect(input, 14);

			Assert.Equal(expected, result);

		}
	}
}