namespace Puzzle;

public interface IPuzzleInputReader
{
    Task<string[]> ReadInputAsync(byte day);
}