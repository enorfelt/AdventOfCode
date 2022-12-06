using AdventOfCode.Day6;

var input = File.ReadAllText("Input.txt");
Console.WriteLine(MarkerDetector.Detect(input, 4));
Console.WriteLine(MarkerDetector.Detect(input, 14));
