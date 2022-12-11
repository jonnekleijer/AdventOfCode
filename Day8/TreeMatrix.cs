namespace Day8;

class Forest
{
    public Forest(int[,] threes)
    {
        Trees = threes;
    }

    public int[,] Trees { get; }
    public int RowsCount { get => Trees.GetLength(0); }
    public int ColCount { get => Trees.GetLength(1); }

    public int[] GetCol(int columnNumber)
        => Enumerable.Range(0, RowsCount)
            .Select(x => Trees[x, columnNumber])
            .ToArray();

    public int[] GetRow(int rowNumber)
        => Enumerable.Range(0, ColCount)
            .Select(x => Trees[rowNumber, x])
            .ToArray();

    internal (int, int) Size()
    {
        return (RowsCount, ColCount);
    }

    internal int Count()
    {
        return GetRow(0).Count() * GetCol(0).Count();
    }

    public override string ToString()
    {
        return $"Forest({RowsCount}, {ColCount})";
    }
}