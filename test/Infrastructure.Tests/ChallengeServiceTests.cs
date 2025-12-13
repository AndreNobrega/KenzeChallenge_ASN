using Application;
using FakeItEasy;
using Moq;

namespace Infrastructure.Tests
{


    public class ChallengeServiceTests
    {
        private IChallengeService challengeService;
        private Mock<IFileReader> fileReader;

        public ChallengeServiceTests()
        {
            fileReader = new Mock<IFileReader>();
            challengeService = new ChallengeService(fileReader.Object);
        }

        [Fact]
        public void Test1()
        {
            List<string> words = new List<string>() { "foobar", "foo", "bar" };
            fileReader
                .Setup(x => x.ReadFile(It.IsAny<string>()))
                .Returns(words);

            challengeService.ExtractWordsFromFile("test", 6);
        }
    }
}
