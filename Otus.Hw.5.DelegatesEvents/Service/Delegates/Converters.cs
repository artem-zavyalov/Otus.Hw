using System.Globalization;
using Otus.Hw._5.DelegatesEvents.Models;

namespace Otus.Hw._5.DelegatesEvents.Service.Delegates;

public static class Converters
{
    public static float StringToFloat(string str)
    {
        str = str.Replace(',', '.');
        var parsed = float.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out var candidate);

        if (parsed)
        {
            return candidate;
        }

        Console.WriteLine($"Warning! Unable to parse string {str} to float");

        return float.MinValue;
    }

    public static float CustomToFloat(Custom customClass)
    {
        var candidate = customClass.GetValue();

        return (float) candidate;
    }
}