namespace Otus.Hw._6.Tasks;

public static class PartOne
{
    public static void Process()
    {
        Console.WriteLine("Part one:");
        const string pathPart = "files";

        var fileName1 = string.Join("\\", Environment.CurrentDirectory, pathPart, "file1.txt");
        var fileName2 = string.Join("\\", Environment.CurrentDirectory, pathPart, "file2.txt");
        var fileName3 = string.Join("\\", Environment.CurrentDirectory, pathPart, "file3.txt");

        var task1 = Task.Factory.StartNew(() => Extensions.ReadAndCount(fileName1));
        var task2 = Task.Factory.StartNew(() => Extensions.ReadAndCount(fileName2));
        var task3 = Task.Factory.StartNew(() => Extensions.ReadAndCount(fileName3));

        Task.WaitAll(task1, task2, task3);

        Console.WriteLine();
    }
}