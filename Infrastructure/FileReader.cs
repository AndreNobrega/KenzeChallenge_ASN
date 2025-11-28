using Application;

namespace Infrastructure
{
    public class FileReader : IFileReader
    {
        public List<string> ReadFile(string sourceFilePath)
        {
            if (sourceFilePath == null)
                throw new ArgumentNullException(nameof(sourceFilePath));

            if (!File.Exists(sourceFilePath))
                throw new FileNotFoundException("File not found or accessible", sourceFilePath);

            if (Path.GetExtension(sourceFilePath) != ".txt")
                throw new Exception("File type not supported");

            var reader = new StreamReader(sourceFilePath);
            var content = reader.ReadToEnd();

            return content.Split("\r\n").Distinct().Where(x => !string.IsNullOrEmpty(x)).ToList();
        }
    }
}
