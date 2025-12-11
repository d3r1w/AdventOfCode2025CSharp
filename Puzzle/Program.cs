// See https://aka.ms/new-console-template for more information

var inputReader = new Puzzle.PuzzleInputReader();

var day1Solution = new Puzzle.Day1.SolutionPart1(inputReader);
var day1Result = await day1Solution.Solve();
Console.WriteLine($"Day{day1Solution.PuzzleDay}: {day1Result}");