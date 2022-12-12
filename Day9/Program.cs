namespace Day9;

internal class Program
{
    private static void Main()
    {
        var simulation = new Simulation("input.txt");
        simulation.Run();
        Console.WriteLine($"{simulation.head.Position.X}, {simulation.head.Position.Y}");
    }
}
