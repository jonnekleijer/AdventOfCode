namespace Day9;

class Head
{
    public Head()
    {
        Position = new Position(0, 0);
    }

    public Position Position { get; set; }

    public void ApplyAction(HeadAction action)
    {
        for (int i = 0; i < action.Steps; i++)
        {
            switch (action.Direction)
            {
                case Direction.U:
                    Position.Y++;
                    break;
                case Direction.R:
                    Position.X++;
                    break;
                case Direction.D:
                    Position.Y--;
                    break;
                case Direction.L:
                    Position.X--;
                    break;
                default:
                    throw new NotImplementedException($"Unknown direction {action.Direction}");
            }
        }
    }
}
