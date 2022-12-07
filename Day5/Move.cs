namespace Day5;

internal class Move
{
    public int Count { get; }
    public int From { get; }
    public int To { get; }

    public Move()
    {
        Count = 0;
        From = 0;
        To = 0;
    }

    public Move(int count, int from, int to)
    {
        Count = count;
        From = from;
        To = to;
    }
}