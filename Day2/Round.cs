using Day2;

internal class Round
{
    internal Round(Choice theirChoise, Choice myChoice)
    {
        TheirChoice = theirChoise;
        MyChoice = myChoice;

        Outcome = GetOutcome();
    }

    internal Round(Choice theirChoice, Result outcome)
    {
        TheirChoice = theirChoice;
        Outcome = outcome;

        MyChoice = GetMyChoice();
    }

    public Choice TheirChoice { get; }
    public Choice MyChoice { get; set; }
    public Result Outcome { get; set; }
    public int Score { get => (int)MyChoice + (int)Outcome; }

    private Result GetOutcome()
    {
        switch ((TheirChoice, MyChoice))
        {
            case (Choice.Rock, Choice.Scissors):
            case (Choice.Scissors, Choice.Paper):
            case (Choice.Paper, Choice.Rock):
                return Result.Lose;
            case (Choice.Scissors, Choice.Rock):
            case (Choice.Paper, Choice.Scissors):
            case (Choice.Rock, Choice.Paper):
                return Result.Win;
            case (Choice.Rock, Choice.Rock):
            case (Choice.Paper, Choice.Paper):
            case (Choice.Scissors, Choice.Scissors):
                return Result.Draw;
            default:
                throw new NotImplementedException($"Round with combination of choices {TheirChoice}, {MyChoice} is not supported.");
        }
    }

    private Choice GetMyChoice()
    {
        switch ((TheirChoice, Outcome))
        {
            case (Choice.Rock, Result.Draw):
            case (Choice.Scissors, Result.Win):
            case (Choice.Paper, Result.Lose):
                return Choice.Rock;
            case (Choice.Scissors, Result.Lose):
            case (Choice.Paper, Result.Draw):
            case (Choice.Rock, Result.Win):
                return Choice.Paper;
            case (Choice.Rock, Result.Lose):
            case (Choice.Paper, Result.Win):
            case (Choice.Scissors, Result.Draw):
                return Choice.Scissors;
            default:
                throw new NotImplementedException($"Round with combination of choice {TheirChoice} and outcome {Outcome} is not supported.");
        }
    }

}

