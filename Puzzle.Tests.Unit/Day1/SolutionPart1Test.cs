using Moq;
using Puzzle.Day1;

namespace Puzzle.Tests.Unit.Day1;

public class SolutionPart1Test
{

    [Theory]
    [InlineData("R1", 0)]
    [InlineData("L1", 0)]
    [InlineData("L50", 1)]
    [InlineData("R50", 1)]
    [InlineData("R99", 0)]
    [InlineData("L99", 0)]
    [InlineData("L999", 0)]
    [InlineData("R999", 0)]
    [InlineData("R0", 0)]
    [InlineData("L0", 0)]
    [InlineData("L51", 0)]
    [InlineData("R51", 0)]
    [InlineData("R49", 0)]
    [InlineData("L49", 0)]
    public async Task Solve_WithSingleInput_ReturnsCorrectResult(string input, int expected)
    {
        var readerMock = new Mock<IPuzzleInputReader>(MockBehavior.Strict);
        var sut = new SolutionPart1(readerMock.Object);
        
        readerMock.Setup(x => x.ReadInputAsync(sut.PuzzleDay)).ReturnsAsync([input]);
        
        var result = await sut.Solve();
        
        Assert.Equal(expected.ToString(), result);
    }
    
    [Theory]
    [InlineData(new[] {"L68", "L30", "R48" }, 1)]
    [InlineData(new[] {"L68", "L30", "R48", "L5", "R60", "L55" }, 2)]
    [InlineData(new[] {"L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99" }, 3)]
    [InlineData(new[] {"L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82" }, 3)]
    public async Task Solve_WithMultipleInput_ReturnsCorrectResult(string[] input, int expected)
    {
        var readerMock = new Mock<IPuzzleInputReader>(MockBehavior.Strict);
        var sut = new SolutionPart1(readerMock.Object);
        
        readerMock.Setup(x => x.ReadInputAsync(sut.PuzzleDay)).ReturnsAsync(input);
        
        var result = await sut.Solve();
        
        Assert.Equal(expected.ToString(), result);
    }
}