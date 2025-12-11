namespace Puzzle;

public interface IAbstractPuzzleSolver
{
    public byte PuzzleDay { get; }

    public ValueTask<string> Solve();
}