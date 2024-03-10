namespace Otus.Hw._3.Solid.Service.Games;

public interface IGuessGame
{
    bool IsCorrect(string userInput);
    string GetHint(string userInput);
}