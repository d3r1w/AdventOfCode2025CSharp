namespace Puzzle.Day1;

public sealed class SolutionPart2(IPuzzleInputReader inputReader) : IAbstractPuzzleSolver
{
    private const int StartingPoint = 50;
    private const int WheelMax = 99;
    private const int FullRotation = 100;

    public byte PuzzleDay => 1;

    public async ValueTask<string> Solve()
    {
        var input = await inputReader.ReadInputAsync(PuzzleDay);
        
        var position = StartingPoint;
        var visitedPositionZeroCount = 0;
        foreach (var rotationCommand in input)
        {
            position = RotateWheel(position, rotationCommand);
            if (position == 0)
            {
                visitedPositionZeroCount++;
            }
        }

        return visitedPositionZeroCount.ToString();
    }
    
    private static int RotateWheel(int wheelPosition, string rotationCommand)
    {
        var rotationAmount = RemoveFullRotations(int.Parse(rotationCommand[1..]));
        
        if (rotationCommand.StartsWith('R'))
        {
            return RotateWheelToTheRight(wheelPosition, rotationAmount);
        }
        
        if (rotationCommand.StartsWith('L'))
        {
            return RotateWheelToTheLeft(wheelPosition, rotationAmount);
        }
        
        throw new InvalidOperationException("Invalid rotation command format");
    }

    private static int RemoveFullRotations(int rotationAmount)
    {
        return rotationAmount % FullRotation;
    }

    private static int RotateWheelToTheLeft(int wheelPosition, int rotationAmount)
    {
        var newWheelPosition = wheelPosition - rotationAmount;
        if (newWheelPosition < 0)
        {
            return FullRotation + newWheelPosition;
        }

        return newWheelPosition;
    }
    
    private static int RotateWheelToTheRight(int wheelPosition, int rotationAmount)
    {
        var newWheelPosition = wheelPosition + rotationAmount;

        if (newWheelPosition > WheelMax)
        {
            return newWheelPosition - FullRotation;
        }

        return newWheelPosition;
    }
}