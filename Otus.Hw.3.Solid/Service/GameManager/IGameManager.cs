using Otus.Hw._3.Solid.Models;

namespace Otus.Hw._3.Solid.Service.GameManager;

public interface IGameManager
{
    void Init(GameTypes gameType);
    ProcessResult ProcessInputValue(string userInput);
}