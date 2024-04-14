using System.Globalization;

namespace Otus.Hw._5.DelegatesEvents.Models;

public class Custom
{
    private int Seed { get; }
    private int Pow { get; }

    public Custom(int seed, int pow)
    {
        Seed = seed;
        Pow = pow;
    }

    public double GetValue()
    {
        return Math.Pow(Seed, Pow);
    }

    public override string ToString()
    {
        return GetValue().ToString(CultureInfo.InvariantCulture);
    }
}