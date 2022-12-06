using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day6
{
	public class MarkerDetector
	{
		public static int Detect(string input, int markerLenght)
		{
			var span = input.AsSpan();
			for (var i = 0; i < span.Length; i++) 
			{
				var slice = span.Slice(i, markerLenght);
				var grouped = slice.ToArray().Distinct();
				if (grouped.Count() == markerLenght)
				{
					return i + markerLenght;
				}
			}
			return -1;
		}
	}
}
