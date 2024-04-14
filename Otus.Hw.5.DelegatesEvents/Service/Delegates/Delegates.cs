using Otus.Hw._5.DelegatesEvents.Models;

namespace Otus.Hw._5.DelegatesEvents.Service.Delegates;

public static class Delegates
{
    public static void Process()
    {
        //string
        var strArray = new[] {"6,66", "-1", "72,22", "0", "4", "5", "hello"};
        var maxString = strArray.GetMax(Converters.StringToFloat);
        Console.WriteLine($"maxStr: {maxString}");

        //CustomClass
        var customArray = new Custom[]
        {
            new(1, 1),
            new(2, 3),
            new(3, 2)
        };
        var maxCustom = customArray.GetMax(Converters.CustomToFloat);
        Console.WriteLine($"maxCustom: {maxCustom}");
    }
}