namespace Day8;

internal class Program
{
    private static void Main(string[] args)
    {
        List<int[]> treeLines = new List<int[]>();
        foreach (var line in File.ReadLines("input.txt"))
        {
            treeLines.Add(line.ToTreeLine());
        }

        var trees = treeLines.ToMatrix();
        var forest = new Forest(trees);
        Console.WriteLine(forest);
    }
}
