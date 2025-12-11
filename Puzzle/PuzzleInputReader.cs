namespace Puzzle;

public sealed class PuzzleInputReader : IPuzzleInputReader
{
    public async Task<string[]> ReadInputAsync(byte day)
    {
        return await ReadInputAsync($"Day{day}/input.txt");
    }
    
    private static async Task<string[]> ReadInputAsync(string filePath)
    {
        return await File.ReadAllLinesAsync(filePath);
    }
}