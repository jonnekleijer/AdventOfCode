internal static class StringExtensionsClass
{
    internal static Choice ToChoice(this string s)
    {
        return s switch
        {
            "A" or "X" => Choice.Rock,
            "B" or "Y" => Choice.Paper,
            "C" or "Z" => Choice.Scissors,
            _ => throw new NotImplementedException($"Choice {s} is not supported"),
        };
    }

    internal static Result ToResult(this string s)
    {
        return s switch
        {
            "X" => Result.Lose,
            "Y" => Result.Draw,
            "Z" => Result.Win,
            _ => throw new NotImplementedException($"Result {s} is not supported"),
        };
    }
}

