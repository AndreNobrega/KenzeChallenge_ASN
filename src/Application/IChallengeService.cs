namespace Application
{
    public interface IChallengeService
    {
        IEnumerable<string> ExtractWordsFromFile(string sourceFilePath, int wordSize);
    }
}
