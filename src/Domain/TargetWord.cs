namespace Domain;

public class TargetWord
{
    private readonly List<string> _segments = new();

    public TargetWord(string fullWord)
    {
        FullWord = fullWord;
    }

    public string FullWord { get; }

    public void AddSegment(string segment)
    {
        if (FullWord.Contains(segment) && !_segments.Contains(segment)) _segments.Add(segment);
    }

    public void AddSegments(IEnumerable<string> segments)
    {
        foreach (var segment in segments) AddSegment(segment);
    }

    public IEnumerable<string> GetAllCombinations()
    {
        List<List<string>> solutions = new();
        List<string> currentPath = new();

        Backtrack(0, currentPath, solutions);

        foreach (var solution in solutions) yield return $"{string.Join("+", solution)}={FullWord}";
    }

    private void Backtrack(int index, List<string> currentPath, List<List<string>> solutions)
    {
        if (index == FullWord.Length && string.Join("", currentPath) == FullWord)
        {
            solutions.Add([.. currentPath]);
            return;
        }

        foreach (var segment in _segments)
            if (FullWord.Length >= index + segment.Length
                && FullWord.Substring(index, segment.Length) == segment)
            {
                currentPath.Add(segment);
                Backtrack(index + segment.Length, currentPath, solutions);
                currentPath.RemoveAt(currentPath.Count - 1);
            }
    }
}