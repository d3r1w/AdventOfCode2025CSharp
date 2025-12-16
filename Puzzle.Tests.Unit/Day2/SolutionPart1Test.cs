using Moq;
using Puzzle.Day2;

namespace Puzzle.Tests.Unit.Day2;

public class SolutionPart1Test
{

    [Theory]
    [InlineData("2147483847-2147483849", 0)]
    [InlineData("11-22", 33)]
    [InlineData("95-115", 99)]
    [InlineData("998-1012", 1010)]
    [InlineData("1188511880-1188511890", 1188511885)]
    [InlineData("222220-222224", 222222)]
    [InlineData("1698522-1698528", 0)]
    [InlineData("446443-446449", 446446)]
    [InlineData("38593856-38593862", 38593859)]
    [InlineData("11-22,95-115", 132)]
    [InlineData("11-22,95-115,998-1012", 1142)]
    [InlineData("11-22,95-115,998-1012,1188511880-1188511890", 1188513027)]
    [InlineData("11-22,95-115,998-1012,1188511880-1188511890,222220-222224", 1188735249)]
    [InlineData("11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528", 1188735249)]
    [InlineData("11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449", 1189181695)]
    [InlineData("11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862", 1227775554)]
    public async Task Solve_WithSingleInput_ReturnsCorrectResult(string input, int expected)
    {
        var readerMock = new Mock<IPuzzleInputReader>(MockBehavior.Strict);
        var sut = new SolutionPart1(readerMock.Object);
        
        readerMock.Setup(x => x.ReadInputAsync(sut.PuzzleDay)).ReturnsAsync([input]);
        
        var result = await sut.Solve();
        
        Assert.Equal(expected.ToString(), result);
    }
}