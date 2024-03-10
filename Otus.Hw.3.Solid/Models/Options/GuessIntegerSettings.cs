namespace Otus.Hw._3.Solid.Models.Options;

public class GuessIntegerSettings
{
    public const string ConfigKey = "GuessIntegerSettings";

    public int MinValue { get; set; } = 0;
    public int MaxValue { get; set; } = 10;
}