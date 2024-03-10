using System;
using Microsoft.Extensions.Options;
using Otus.Hw._3.Solid.Models;
using Otus.Hw._3.Solid.Models.Options;

namespace Otus.Hw._3.Solid.Service.Games;

public class GameFactory
{
    private readonly GuessIntegerSettings _options;

    public GameFactory(IOptions<GuessIntegerSettings> options)
    {
        _options = options.Value;
    }

    public IGuessGame CreateGame(GameTypes gameType)
    {
        return gameType switch
        {
            GameTypes.GuessInteger => new GuessIntegerGame(_options.MinValue, _options.MaxValue),
            _ => throw new ArgumentOutOfRangeException(nameof(gameType), gameType, null)
        };
    }
}