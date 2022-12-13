namespace Day9;

internal class Program
{
    private static void Main()
    {
        var simulation = new Simulation("input.txt");
        simulation.Run();
        var result = simulation.TailTrace.DistinctBy(p => new { p.X, p.Y }).Count();
        Console.WriteLine($"{simulation.head.Position.X}, {simulation.head.Position.Y}");
        Console.WriteLine($"Day 9A - {result}");

    }
}
