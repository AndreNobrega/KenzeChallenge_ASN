using Application;

namespace Infrastructure
{
    public class ChallengeService : IChallengeService
    {
        private IFileReader fileReader;

        public ChallengeService(IFileReader _fileReader)
        {
            //fileReader = _fileReader;
            fileReader = new FileReader(); // NOT GOOD! Proper DI would be preferable, if I had time
        }

        public void ExtractWordsFromFile(string sourceFilePath, int wordSize)
        {
            var fileContent = fileReader.ReadFile(sourceFilePath);

            var targetWords = fileContent.Where(x => x.Length == wordSize).ToList();
            Console.WriteLine($"Found {targetWords.Count()} words that are {wordSize} characters long.");

            foreach (var targetWord in targetWords)
            {
                int startIndex = 0;

                var wordFragments = fileContent
                                    .Where(x => x != targetWord
                                                && targetWord.Substring(startIndex).Contains(x)
                                                && x.Substring(0, 1) == targetWord.Substring(startIndex, 1)) // Exclude duplicates of the full word
                                    .ToList();


            }
        }
    }
}
