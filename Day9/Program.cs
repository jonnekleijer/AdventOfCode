namespace Day9;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Hello, World!");
        var simulation = new Simulation("input.txt");
        simulation.Run();
    }
}

class Simulation
{
    public Simulation(string file)
    {
        File = file;
    }

    public string File { get; }

    public void Run()
    {
        // Read file
        // Intialize objects
        // Take actions
        // Calculate result
    }
}

class Head
{
    public Head()
    {
        Position = new Position(0, 0);
    }

    public Position Position { get; set; }
}

class Tail
{
    public Tail()
    {
        Position = new Position(0, 0);
    }

    public Position Position { get; set; }
}

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