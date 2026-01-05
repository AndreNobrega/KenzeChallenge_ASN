using Application;
using Moq;

namespace Infrastructure.Tests;

public class ChallengeServiceTests
{
    private readonly IChallengeService challengeService;
    private readonly Mock<IFileReader> fileReader;

    public ChallengeServiceTests()
    {
        fileReader = new Mock<IFileReader>();
        challengeService = new ChallengeService(fileReader.Object);
    }

    [Fact]
    public void Test1()
    {
        var words = new List<string> { "foobar", "foo", "bar" };
        fileReader
            .Setup(x => x.ReadFile(It.IsAny<string>()))
            .Returns(words);

        challengeService.ExtractWordsFromFile("test", 6);
    }
}