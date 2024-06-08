using System.Collections.Concurrent;
using System.Diagnostics;

var arrayDimensions = new[] {100_000, 1_000_000, 10_000_000};

foreach (var dimension in arrayDimensions)
{
    ProcessSum(dimension);
}

void ProcessSum(int dimension)
{
    var testArray = CreateAndFillArray(dimension);

    var timer = new Stopwatch();
    long sum;
    Console.WriteLine($"Count: {dimension:N0}");

    timer.Start();
    sum = SumArrayCasual(testArray);
    timer.Stop();

    Console.WriteLine($"CasualSum: {timer.ElapsedMilliseconds} ms, sum: {sum:N0}");

    timer.Restart();
    sum = SumArrayThread(testArray);
    timer.Stop();

    Console.WriteLine($"ThreadSum: {timer.ElapsedMilliseconds} ms, sum: {sum:N0}");

    timer.Restart();
    sum = SumArrayLinq(testArray);
    timer.Stop();

    Console.WriteLine($"LinqSum: {timer.ElapsedMilliseconds} ms, sum: {sum:N0}");

    Console.WriteLine();
}

long SumArrayCasual(long[] array)
{
    long sumArray = 0;

    foreach (var t in array)
    {
        sumArray += t;
    }

    return sumArray;
}

long SumArrayThread(long[] array)
{
    var rangePartitioner = Partitioner.Create(0, array.Length);
    var total = new Total();

    Parallel.ForEach(rangePartitioner, range =>
    {
        var subtotal = new long();

        for (var i = range.Item1; i < range.Item2; i++)
        {
            subtotal += array[i];
        }

        lock (total)
        {
            total.Sum += subtotal;
        }
    });

    return total.Sum;
}

long SumArrayLinq(long[] array)
{
    return array.AsParallel().Sum();
}

long[] CreateAndFillArray(int dimension)
{
    var array = new long[dimension];
    var randNum = new Random();

    for (var i = 0; i < array.Length; i++)
    {
        array[i] = randNum.Next();
    }

    return array;
}

public class Total
{
    public long Sum = 0;
};