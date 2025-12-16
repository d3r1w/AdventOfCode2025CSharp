namespace Puzzle.Day2;

public sealed class SolutionPart1(IPuzzleInputReader inputReader) : IAbstractPuzzleSolver
{
    public byte PuzzleDay => 2;

    public async ValueTask<string> Solve()
    {
        var input = await inputReader.ReadInputAsync(PuzzleDay);
        var rangeList = input
            .Single()
            .Split(",")
            .Select(x => x.Split("-"))
            .Select(x => (long.Parse(x[0]), long.Parse(x[1])))
            .Select(x => CreateRange(x.Item1, x.Item2 - x.Item1 + 1));

        var invalidIdSum = rangeList
            .SelectMany(x => x)
            .Where(x => IsNumberIncludedTwice(x.ToString()))
            .Sum();

        return invalidIdSum.ToString();
    }
    
    private static bool IsNumberIncludedTwice(string number)
    {
        if (number.Length % 2 != 0) return false;
        var part1 = number.AsSpan(0, number.Length / 2);
        var part2 = number.AsSpan(number.Length / 2, number.Length / 2);
        return part1.SequenceEqual(part2);
    }
    
    private static IEnumerable<long> CreateRange(long start, long count)
    {
        for (var i = 0; i < count; i++)
        {
            yield return start + i;
        }
    }
}