namespace Puzzle.Day1;

public sealed class SolutionPart2(IPuzzleInputReader inputReader) : IAbstractPuzzleSolver
{
    private const int StartingPoint = 50;
    private const int WheelMin = 0;
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
            var result = RotateWheel(position, rotationCommand);
            position = result.Position;
            visitedPositionZeroCount += result.RotationsOverZeroCount;
            /*if (position == 0)
            {
                visitedPositionZeroCount++;
            }*/
        }

        return visitedPositionZeroCount.ToString();
    }
    
    private static RotationResult RotateWheel(int wheelPosition, string rotationCommand)
    {
        var absoluteRotationAmount = int.Parse(rotationCommand[1..]);
        var fullRotations = CountFullRotations(absoluteRotationAmount);
        var rotationAmount = RemoveFullRotations(absoluteRotationAmount);
        
        if (rotationCommand.StartsWith('R'))
        {
            var result = RotateWheelToTheRight(wheelPosition, rotationAmount);
            return new RotationResult
            {
                Position = result.Position,
                RotationsOverZeroCount = fullRotations + result.RotationsOverZeroCount
            };
        }
        
        if (rotationCommand.StartsWith('L'))
        {
            var result = RotateWheelToTheLeft(wheelPosition, rotationAmount);
            return new RotationResult
            {
                Position = result.Position,
                RotationsOverZeroCount = fullRotations + result.RotationsOverZeroCount
            };
        }
        
        throw new InvalidOperationException("Invalid rotation command format");
    }

    private static int CountFullRotations(int wheelPosition)
    {
        return wheelPosition / FullRotation;
    }

    private static int RemoveFullRotations(int rotationAmount)
    {
        return rotationAmount % FullRotation;
    }

    private static RotationResult RotateWheelToTheLeft(int wheelPosition, int rotationAmount)
    {
        var newWheelPosition = wheelPosition - rotationAmount;
        if (newWheelPosition < WheelMin)
        {
            return new RotationResult
            {
                Position = FullRotation + newWheelPosition,
                RotationsOverZeroCount = wheelPosition > WheelMin ? 1 : 0
            };
        }

        return new RotationResult
        {
            Position = newWheelPosition,
            RotationsOverZeroCount = newWheelPosition == WheelMin ? 1 : 0
        };
    }
    
    private static RotationResult RotateWheelToTheRight(int wheelPosition, int rotationAmount)
    {
        var newWheelPosition = wheelPosition + rotationAmount;

        if (newWheelPosition > WheelMax)
        {
            return new RotationResult
            {
                Position = newWheelPosition - FullRotation,
                RotationsOverZeroCount = 1
            };
        }

        return new RotationResult
        {
            Position = newWheelPosition,
            RotationsOverZeroCount = 0
        };
    }
}