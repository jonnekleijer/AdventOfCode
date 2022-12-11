namespace Day8;

internal class Program
{
    private static void Main()
    {
        List<int[]> treeLines = new();
        foreach (var line in File.ReadLines("input.txt"))
        {
            treeLines.Add(line.ToTreeLine());
        }

        var forest = new Forest(treeLines.ToArray());
        var potentialTrees = forest.GetVisibleTrees();
        var result = potentialTrees.Sum(i => i.Where(j => !j).Count());
        Console.WriteLine($"Day 8A - {result}");

        result = forest.GetHighestScenicScore();
        Console.WriteLine($"Day 8A - {result}");
    }
}
