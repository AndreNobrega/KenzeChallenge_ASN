using Application;

namespace Infrastructure.Tests
{
    public class FileReaderTests
    {
        protected IFileReader fileReader;
        public FileReaderTests()
        {
            fileReader = new FileReader();
        }

        [Fact]
        public void IfFileNotFound_ThrowFileNotFoundException()
        {
            Assert.Throws<FileNotFoundException>(() => fileReader.ReadFile("nonexisting file"));
        }

        [Fact]
        public void IfFilePathIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => fileReader.ReadFile(null));
        }

        [Fact]
        public void IfFileTypeIsNotTxt_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => fileReader.ReadFile("./Resources/InvalidFileType.csv"));
        }

        [Fact]
        public void HappyPath_ReturnStringList()
        {
            Assert.True(false);
        }
    }
}
