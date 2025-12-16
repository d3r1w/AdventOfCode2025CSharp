namespace Puzzle.Day2;

public sealed class SolutionPart2(IPuzzleInputReader inputReader) : IAbstractPuzzleSolver
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
            .Where(x => IsNumberPatternRepeating(x.ToString()))
            .Sum();

        return invalidIdSum.ToString();
    }
    
    private static bool IsNumberPatternRepeating(string number)
    {
        var hasRepeatingPattern = false;

        for (var i = 2; i <= number.Length; i++)
        {
            hasRepeatingPattern |= IsNumberNthTimesIncluded(number, i);
        }
        
        return hasRepeatingPattern;
    }
    
    private static bool IsNumberNthTimesIncluded(string number, int n)
    {
        if (number.Length % n != 0) return false;
        
        var partLength = number.Length / n;
        var part1 = number.AsSpan(0, partLength);
        
        for (var i = 1; i < n; i++)
        {
            var nthPart = number.AsSpan(partLength * i, partLength);
            if (!part1.SequenceEqual(nthPart))
            {
                return false;
            }
        }
        return true;
    }
    
    private static IEnumerable<long> CreateRange(long start, long count)
    {
        for (var i = 0; i < count; i++)
        {
            yield return start + i;
        }
    }
}