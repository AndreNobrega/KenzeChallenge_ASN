namespace Application;

public interface IFileReader
{
    List<string> ReadFile(string sourceFilePath);
}