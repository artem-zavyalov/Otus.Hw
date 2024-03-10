using System;
using Otus.Hw._3.Solid.Models;
using Otus.Hw._3.Solid.Service.GameManager;

namespace Otus.Hw._3.Solid.Service;

public class Game
{
    private readonly IGameManager _gameManager;

    public Game(IGameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void Start()
    {
        while (true)
        {
            _gameManager.Init(GameTypes.GuessInteger);

            Console.WriteLine("Game started");
            Console.WriteLine("Try to guess:");

            while (true)
            {
                var userInput = Console.ReadLine();

                try
                {
                    var result = _gameManager.ProcessInputValue(userInput);

                    if (result.IsCorrect)
                    {
                        Console.WriteLine(result.Hint);

                        break;
                    }

                    Console.WriteLine($"Wrong! Hint: {result.Hint}.");

                    if (result.AttemptsLeft < 1)
                    {
                        Console.WriteLine("No more attempts. Try another game");

                        break;
                    }

                    Console.WriteLine($"Try {result.AttemptsLeft} more time(s):");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"{e.Message}. Try one more time:");
                }
            }

            Console.WriteLine("One more game? (y/n)");

            if (Console.ReadLine()!.ToLower() != "y")
            {
                break;
            }
        }
    }
}