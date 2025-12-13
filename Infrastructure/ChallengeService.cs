using Application;
using Domain;

namespace Infrastructure
{
    public class ChallengeService : IChallengeService
    {
        private IFileReader fileReader;

        public ChallengeService(IFileReader _fileReader)
        {
            fileReader = _fileReader;
        }

        public void ExtractWordsFromFile(string sourceFilePath, int wordSize)
        {
            var fileContent = fileReader.ReadFile(sourceFilePath);

            var targetWords = fileContent.Where(x => x.Length == wordSize).Select(x => new TargetWord(x)).ToList();
            Console.WriteLine($"Found {targetWords.Count()} words that are {wordSize} characters long.");

            foreach (var targetWord in targetWords)
            {
                var wordFragments = fileContent
                                    .Where(x => x != targetWord.FullWord && targetWord.FullWord.Contains(x))
                                    .Distinct()
                                    .ToList();             

                targetWord.AddSegments(wordFragments);

                var combos = targetWord.GetAllCombinations();

                foreach (var combo in combos)
                {
                    Console.WriteLine(combo);
                }
            }
        }
    }
}
