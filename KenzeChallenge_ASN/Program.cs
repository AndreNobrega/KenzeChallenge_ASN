using Application;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class Program
{
    private static void Main(string[] args)
    {
#if DEBUG
        args = new string[] { @"C:\Users\andre\Downloads\6LetterWordChallenge\input.txt", "6" };
#endif

        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddTransient<IFileReader, FileReader>();
                services.AddTransient<IChallengeService, ChallengeService>();
            })
            .Build();

        string sourceFile;
        int wordSize = 0;

        try
        {
            (sourceFile, wordSize) = ParseArgs(args);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error encountered while parsing arguments.");
            Console.WriteLine($"{e.ToString()}: {e.Message}");
            throw;
        }

        var challengeService = host.Services.GetRequiredService<IChallengeService>();
        challengeService.ExtractWordsFromFile(sourceFile, wordSize);
    }


    private static (string, int) ParseArgs(string[] args)
    {
        if (args.Length != 2)
        {
            throw new ArgumentException("Incorrect number of arguments. Expected a file path and a word size.");
        }

        string sourceFilePath = args[0];

        int wordSize = 0;
        var wordSizeParsed = int.TryParse(args[1], out wordSize);
        if (!wordSizeParsed)
        {
            throw new ArgumentException("Second argument was not a valid integer");
        }

        return (sourceFilePath,  wordSize);
    }
}