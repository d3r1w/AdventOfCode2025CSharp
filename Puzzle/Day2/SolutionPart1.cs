namespace Puzzle.Day2;

public sealed class SolutionPart1(IPuzzleInputReader inputReader) : IAbstractPuzzleSolver
{
    public byte PuzzleDay => 2;

    public async ValueTask<string> Solve()
    {
        var input = await inputReader.ReadInputAsync(PuzzleDay);

        return "";
    }
}