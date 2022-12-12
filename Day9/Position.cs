namespace Day9;

class Position
{
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }

    public int Distance(Position other)
    {
        var dX = other.X - X;
        var dY = other.Y - Y;
        return dX;
    }
}
