using System;

namespace Otus.Hw._3.Solid.Service.Games;

public class GuessIntegerGame : IGuessGame
{
    private int _targetValue;

    private readonly int _minValue;
    private readonly int _maxValue;
    private readonly Random _random = new();


    public GuessIntegerGame(int minValue, int maxValue)
    {
        _minValue = minValue;
        _maxValue = maxValue;
        InitGame();
    }

    public bool IsCorrect(string userInput)
    {
        var value = ParseValue(userInput);

        return _targetValue.Equals(value);
    }

    public string GetHint(string userInput)
    {
        var value = ParseValue(userInput);

        return _targetValue > value
            ? $"Target value is higher than {value}"
            : $"Target value is less than {value}";
    }

    private static int ParseValue(string userValue)
    {
        if (int.TryParse(userValue, out var parsed))
        {
            return parsed;
        }

        throw new ArgumentException("Wrong input format");
    }

    private void InitGame()
    {
        _targetValue = _random.Next(_minValue, _maxValue);
        Console.WriteLine($"DEBUG: {_targetValue}");
    }
}