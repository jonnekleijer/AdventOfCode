namespace Day9;

class HeadAction
{
    public HeadAction(Direction direction, int steps)
    {
        Direction = direction;
        Steps = steps;
    }

    public Direction Direction { get; }
    public int Steps { get; }
}
