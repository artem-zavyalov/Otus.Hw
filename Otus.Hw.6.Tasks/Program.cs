using System.Diagnostics;
using Otus.Hw._6.Tasks;

var sw = new Stopwatch();

sw.Start();

PartOne.Process();
await PartTwo.Process();

sw.Stop();

Console.WriteLine();
Console.WriteLine($"Total app execution: {sw.ElapsedMilliseconds} ms");

