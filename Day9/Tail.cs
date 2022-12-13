namespace Day9;

class Tail
{
    public Tail()
    {
        Position = new Position(0, 0);
    }

    public Position Position { get; set; }

    public void Move(Direction direction)
    {
        switch (direction)
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

            case Direction.UR:
                Move(Direction.R);
                Move(Direction.U);
                break;
            case Direction.UL:
                Move(Direction.L);
                Move(Direction.U);
                break;
            case Direction.DR:
                Move(Direction.L);
                Move(Direction.D);
                break;
            case Direction.DL:
                Move(Direction.L);
                Move(Direction.D);
                break;
            default:
                throw new NotImplementedException($"Unknown direction {direction}");
        }
    }
}
