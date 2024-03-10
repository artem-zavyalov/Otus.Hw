using Microsoft.Extensions.Options;
using Otus.Hw._3.Solid.Models;
using Otus.Hw._3.Solid.Models.Options;
using Otus.Hw._3.Solid.Service.Games;

namespace Otus.Hw._3.Solid.Service.GameManager;

public class GameManager : IGameManager
{
    private IGuessGame _guessGame;
    private int _attemptsLeftCount;

    private readonly int _attemptsTotalCount;
    private readonly GameFactory _gameFactory;

    public GameManager(IOptions<GuessGameSettings> options,
        GameFactory gameFactory)
    {
        _gameFactory = gameFactory;
        _attemptsTotalCount = options.Value.Count;
    }

    public void Init(GameTypes gameType)
    {
        _guessGame = _gameFactory.CreateGame(gameType);
        _attemptsLeftCount =_attemptsTotalCount;
    }

    public ProcessResult ProcessInputValue(string userInput)
    {
        if (_guessGame.IsCorrect(userInput))
        {
            return ProcessResult.GetSuccessResult();
        }

        _attemptsLeftCount--;

        return ProcessResult.GetFailResult(_guessGame.GetHint(userInput), _attemptsLeftCount);
    }
}