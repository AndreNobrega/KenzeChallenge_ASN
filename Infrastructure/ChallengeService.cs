using System.Text;
using Application;

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

            var targetWords = fileContent.Where(x => x.Length == wordSize).ToList();
            Console.WriteLine($"Found {targetWords.Count()} words that are {wordSize} characters long.");

            foreach (var targetWord in targetWords)
            {
                var wordFragments = fileContent
                                    .Where(x => x != targetWord && targetWord.Contains(x))
                                    .Distinct()
                                    .ToList();             

                foreach (var wordStart in wordFragments.Where(x => x.Substring(0, 1) == targetWord.Substring(0, 1)))
                {
                    var compositedWord = wordStart;
                    List<string> words = new List<string>() { wordStart };

                    do
                    {
                        var followup = wordFragments
                            .Where(x => x.Substring(0, 1) == targetWord.Substring(compositedWord.Length, 1) && targetWord.Contains(compositedWord + x))
                            .FirstOrDefault();

                        if (followup != null)
                        {
                            compositedWord += followup;
                            words.Add(followup);
                        }

                    } while (!compositedWord.Equals(targetWord));

                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < words.Count; i++)
                    {
                        sb.Append(words[i]);
                        if (i < words.Count - 1) sb.Append('+');
                    }
                    sb.Append($"={targetWord}");

                    Console.WriteLine(sb.ToString());
                }
            }
        }
    }
}
