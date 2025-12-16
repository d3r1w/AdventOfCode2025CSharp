using Moq;
using Puzzle.Day2;

namespace Puzzle.Tests.Unit.Day2;

public class SolutionPart2Test
{

    [Theory]
    [InlineData("2147483847-2147483849", 0)]
    [InlineData("11-22", 33)]
    [InlineData("95-115", 210)]
    [InlineData("998-1012", 2009)]
    [InlineData("1188511880-1188511890", 1188511885)]
    [InlineData("222220-222224", 222222)]
    [InlineData("1698522-1698528", 0)]
    [InlineData("446443-446449", 446446)]
    [InlineData("38593856-38593862", 38593859)]
    [InlineData("565653-565659", 565656)]
    [InlineData("824824821-824824827", 824824824)]
    [InlineData("2121212118-2121212124", 2121212121)]
    [InlineData("11-22,95-115", 243)]
    [InlineData("11-22,95-115,998-1012", 2252)]
    [InlineData("11-22,95-115,998-1012,1188511880-1188511890", 1188514137)]
    [InlineData("11-22,95-115,998-1012,1188511880-1188511890,222220-222224", 1188736359)]
    [InlineData("11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528", 1188736359)]
    [InlineData("11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449", 1189182805)]
    [InlineData("11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862", 1227776664)]
    [InlineData("11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,824824821-824824827", 2052601488)]
    [InlineData("11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,824824821-824824827,2121212118-2121212124", 4173813609)]
    public async Task Solve_WithSingleInput_ReturnsCorrectResult(string input, long expected)
    {
        var readerMock = new Mock<IPuzzleInputReader>(MockBehavior.Strict);
        var sut = new SolutionPart2(readerMock.Object);
        
        readerMock.Setup(x => x.ReadInputAsync(sut.PuzzleDay)).ReturnsAsync([input]);
        
        var result = await sut.Solve();
        
        Assert.Equal(expected.ToString(), result);
    }
}