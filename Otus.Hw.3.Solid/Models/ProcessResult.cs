namespace Otus.Hw._3.Solid.Models;

public class ProcessResult
{
    public readonly bool IsCorrect;
    public readonly string Hint;
    public readonly int AttemptsLeft;

    private ProcessResult(bool isCorrect, string hint, int attemptsLeft)
    {
        IsCorrect = isCorrect;
        Hint = hint;
        AttemptsLeft = attemptsLeft;
    }

    public static ProcessResult GetSuccessResult()
    {
        return new ProcessResult(
            true,
            "Correct! Congratulations!",
            0);
    }

    public static ProcessResult GetFailResult(string hint, int attemptsLeft)
    {
        return new ProcessResult(
            false,
            hint,
            attemptsLeft);
    }
}