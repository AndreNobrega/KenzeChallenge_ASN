using Application;
using Domain;

namespace Infrastructure;

public class ChallengeService : IChallengeService
{
    private readonly IFileReader fileReader;

    public ChallengeService(IFileReader _fileReader)
    {
        fileReader = _fileReader;
    }

    public IEnumerable<string> ExtractWordsFromFile(string sourceFilePath, int wordSize)
    {
        var fileContent = fileReader.ReadFile(sourceFilePath);

        var targetWords = fileContent.Where(x => x.Length == wordSize).Select(x => new TargetWord(x)).ToList();
        Console.WriteLine($"Found {targetWords.Count()} words that are {wordSize} characters long.");

        List<string> results = new();

        foreach (var targetWord in targetWords)
        {
            var wordFragments = fileContent
                .Where(x => x != targetWord.FullWord && targetWord.FullWord.Contains(x))
                .Distinct()
                .ToList();

            targetWord.AddSegments(wordFragments);

            results.AddRange(targetWord.GetAllCombinations());
        }

        return results;
    }
}