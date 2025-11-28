namespace Application
{
    public interface IChallengeService
    {
        void ExtractWordsFromFile(string sourceFilePath, int wordSize);
    }
}
