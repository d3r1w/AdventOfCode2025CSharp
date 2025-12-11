namespace Puzzle;

public abstract class AbstractPuzzleSolver
{
    private static Task<string[]> ReadInput()
    {
        return File.ReadAllLinesAsync("input.txt");
    }
    
    protected abstract Task<string> Solve(string[] input);
    
    public async Task<string> SolveAndReturnResult()
    {
        var input = await ReadInput();
        return await Solve(input);
    }
}