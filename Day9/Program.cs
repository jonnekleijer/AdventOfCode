namespace Day9;

internal class Program
{
    private static void Main()
    {
        var simulation = new Simulation("input.txt");
        simulation.Run();
        var result = simulation.LastKnotTrace.DistinctBy(p => new { p.X, p.Y }).Count();
        Console.WriteLine($"Day 9A - {result}");

        simulation = new Simulation("input.txt", 10);
        simulation.Run();
        result = simulation.LastKnotTrace.DistinctBy(p => new { p.X, p.Y }).Count();
        Console.WriteLine($"Day 9B - {result}");
    }
}
