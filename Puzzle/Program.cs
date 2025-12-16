// See https://aka.ms/new-console-template for more information

var inputReader = new Puzzle.PuzzleInputReader();

var day1Part1Solution = new Puzzle.Day1.SolutionPart1(inputReader);
var day1Part1Result = await day1Part1Solution.Solve();
Console.WriteLine($"Day{day1Part1Solution.PuzzleDay} Part 1: {day1Part1Result}");

var day1Part2Solution = new Puzzle.Day1.SolutionPart2(inputReader);
var day1Part2Result = await day1Part2Solution.Solve();
Console.WriteLine($"Day{day1Part2Solution.PuzzleDay} Part 2: {day1Part2Result}");

var day2Part1Solution = new Puzzle.Day2.SolutionPart1(inputReader);
var day2Part1Result = await day2Part1Solution.Solve();
Console.WriteLine($"Day{day2Part1Solution.PuzzleDay} Part 1: {day2Part1Result}");

var day2Part2Solution = new Puzzle.Day2.SolutionPart2(inputReader);
var day2Part2Result = await day2Part2Solution.Solve();
Console.WriteLine($"Day{day2Part2Solution.PuzzleDay} Part 2: {day2Part2Result}");