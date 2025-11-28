internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            ParseArgs(args);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error encountered while parsing arguments.");
            Console.WriteLine($"{e.ToString()}: {e.Message}");
            throw;
        }

        Console.WriteLine("Hello, World!");
    }

    private static void ParseArgs(string[] args)
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
    }
}