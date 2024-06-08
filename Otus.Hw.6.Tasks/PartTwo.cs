namespace Otus.Hw._6.Tasks;

public static class PartTwo
{
    public static async Task Process()
    {
        Console.WriteLine("Part two:");
        const string pathPart = "files";
        var dirName = string.Join("\\", Environment.CurrentDirectory, pathPart);

        await ReadAllAndCountAsync(dirName);

        async Task ReadAllAndCountAsync(string directory)
        {
            var files = Directory.GetFiles(directory);
            var sumSpaces = 0;

            await Task.Run(() => Parallel.ForEach(files, s =>
            {
                var spaceCount = Extensions.ReadAndCount(s);
                sumSpaces += spaceCount;
            }));

            Console.WriteLine($"Total spaces at {files.Length}: {sumSpaces}");
        }
    }
}