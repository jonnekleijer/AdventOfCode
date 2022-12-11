namespace Day8;

class Forest
{
    private readonly bool[][] visibleTrees;
    private readonly int[][] scenicTrees;

    public Forest(int[][] trees)
    {
        Trees = trees;
        visibleTrees = GetNewJaggedArray(false);
        scenicTrees = GetNewJaggedArray(0);
    }

    public int[][] Trees { get; }
    public int RowCount { get => Trees.GetLength(0); }
    public int ColCount { get => GetTreesRow(0).GetLength(0); }
    public int Count() => RowCount * ColCount;

    public int[] GetTreesCol(int columnNumber)
        => Trees.Select(row => row[columnNumber]).ToArray();

    public int[] GetTreesRow(int rowNumber)
        => Trees[rowNumber];

    public bool[] GetVisibleTreesCol(int columnNumber)
        => visibleTrees.Select(row => row[columnNumber]).ToArray();

    public bool[] GetVisibleTreesRow(int rowNumber)
        => visibleTrees[rowNumber];

    public (int, int) Size() => (RowCount, ColCount);

    public override string ToString() => $"Forest({RowCount}, {ColCount})";

    public bool[][] GetVisibleTrees()
    {
        IsVisibileNorth();
        IsVisibileEast();
        IsVisibileSouth();
        IsVisibileWest();
        return visibleTrees;
    }

    private void IsVisibileNorth()
    {
        UpdateRowValues(0, Enumerable.Repeat(true, ColCount).ToArray());
        var treeReferenceRow = GetTreesRow(0).ToArray();
        
        for (int i = 0; i < RowCount; i++)
        {
            var treeRow = GetTreesRow(i);
            var largerTrees = treeRow.GreaterThan(treeReferenceRow);
            for (int j = 0; j < ColCount; j++)
            {
                if (largerTrees[j])
                {
                    treeReferenceRow[j] = treeRow[j];
                }
            }
            UpdateRowValues(i, largerTrees);
        }
    }

    private void IsVisibileEast()
    {
        UpdateColValues(0, Enumerable.Repeat(true, ColCount).ToArray());
        var treeReferenceCol = GetTreesCol(0).ToArray();
        for (int i = 0; i < ColCount; i++)
        {
            var treeCol = GetTreesCol(i);
            var largerTrees = treeCol.GreaterThan(treeReferenceCol);
            for (int j = 0; j < RowCount; j++)
            {
                if (largerTrees[j])
                {
                    treeReferenceCol[j] = treeCol[j];
                }

                UpdateColValues(i, largerTrees);
            }
        }
    }

    private void IsVisibileSouth()
    {
        UpdateRowValues(RowCount - 1, Enumerable.Repeat(true, ColCount).ToArray());
        var treeReferenceRow = GetTreesRow(RowCount - 1).ToArray();
        for (int i = RowCount - 1; i >= 0; i--)
        {
            var treeRow = GetTreesRow(i);
            var largerTrees = treeRow.GreaterThan(treeReferenceRow);
            for (int j = 0; j < ColCount; j++)
            {
                if (largerTrees[j])
                {
                    treeReferenceRow[j] = treeRow[j];
                }
            }
                UpdateRowValues(i, largerTrees);
        }
    }

    private void IsVisibileWest()
    {
        UpdateColValues(ColCount - 1, Enumerable.Repeat(true, ColCount).ToArray());
        var treeReferenceCol = GetTreesCol(ColCount - 1).ToArray();
        for (int i = ColCount - 1; i >= 0; i--)
        {
            var treeCol = GetTreesCol(i);
            var largerTrees = treeCol.GreaterThan(treeReferenceCol);
            for (int j = 0; j < RowCount; j++)
            {
                if (largerTrees[j])
                {
                    treeReferenceCol[j] = treeCol[j];
                }

                UpdateColValues(i, largerTrees);
            }
            UpdateColValues(i, largerTrees);
        }
    }

    private void UpdateRowValues(int i, bool[] largerTrees)
    {
        for (int j = 0; j < ColCount; j++)
        {
            var currentValue = visibleTrees[i][j];
            if (currentValue)
            {
                continue;
            }
            else
            {
                visibleTrees[i][j] = largerTrees[j];
            }
        }
    }

    private void UpdateColValues(int i, bool[] largerTrees)
    {
        for (int j = 0; j < RowCount; j++)
        {
            var currentValue = visibleTrees[j][i];
            if (currentValue)
            {
                continue;
            }
            else
            {
                visibleTrees[j][i] = largerTrees[j];
            }
        }
    }

    private T[][] GetNewJaggedArray<T>(T value)
    {
        T[][] array = new T[RowCount][];
        for (int i = 0; i < RowCount; i++)
        {
            array[i] = Enumerable.Repeat(value, ColCount).ToArray();
        }
        return array;
    }

    internal int GetHighestScenicScore()
    {
        for (int i = 0; i < RowCount; i++)
        {
            for (int j = 0; j < ColCount; j++)
            {
                var treeHeight = Trees[i][j];
                var leftScore = GetLeftScore(treeHeight, i, j);
                var rightScore = GetRightScore(treeHeight, i, j);
                var downScore = GetDownScore(treeHeight, i, j);
                var upScore = GetUpScore(treeHeight, i, j);
                scenicTrees[i][j] = leftScore * rightScore * upScore * downScore;
            }
        }
        return scenicTrees.Max(i => i.Max());
    }

    private int GetLeftScore(int treeHeight, int i, int j)
    {
        var score = 0;
        var isLarger = true;
        var k = j - 1;
        
        while (isLarger && k >= 0 )
        {
            if (Trees[i][k] >= treeHeight)
            {
                isLarger = false;
            }
            k--;
            score++;
        }
        return score;
    }

    private int GetRightScore(int treeHeight, int i, int j)
    {
        var score = 0;
        var isLarger = true;
        var k = j + 1;

        while (isLarger && k < ColCount)
        {
            if (Trees[i][k] >= treeHeight)
            {
                isLarger = false;
            }
            k++;
            score++;
        }
        return score;
    }

    private int GetDownScore(int treeHeight, int i, int j)
    {
        var score = 0;
        var isLarger = true;
        var k = i + 1;

        while (isLarger && k < RowCount)
        {
            if (Trees[k][j] >= treeHeight)
            {
                isLarger = false;
            }
            k++;
            score++;
        }
        return score;
    }

    private int GetUpScore(int treeHeight, int i, int j)
    {
        var score = 0;
        var isLarger = true;
        var k = i - 1;

        while (isLarger && k >= 0)
        {
            if (Trees[k][j] >= treeHeight)
            {
                isLarger = false;
            }
            k--;
            score++;
        }
        return score;
    }
}