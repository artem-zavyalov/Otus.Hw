namespace Otus.Hw._6.Tasks;

public static class Extensions
{
    public static int ReadAndCount(string fileName)
    {
        var text = File.ReadAllText(fileName);
        var count = CountSpaces(text);

        var file = fileName.Substring(fileName.LastIndexOf('\\') + 1);

        Console.WriteLine($"{file} has {count} spaces");

        return count;
    }

    static int CountSpaces(string text)
    {
        return text.Count(s => s == ' ');
    }
}