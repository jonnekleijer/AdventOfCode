namespace Day9;

class Simulation
{
    public Simulation(string fileName)
    {
        FileName = fileName;
    }

    public string FileName { get; }
    public ICollection<Position> TailTrace { get; } = new List<Position>();
    public ICollection<HeadAction> HeadTrace { get; } = new List<HeadAction>();

    public readonly Head head = new Head();
    public readonly Tail tail = new Tail();

    public void Run()
    {
        // Read file
        var lines = File.ReadLines("input.txt");
        foreach (var line in lines)
        {
            var arguments = line.Split(" ");
            var direction = Enum.Parse<Direction>(arguments[0]);
            var steps = int.Parse(arguments[1]);
            HeadTrace.Add(new HeadAction(direction, steps));
        }

        // Move head
        foreach (var action in HeadTrace)
        {
            head.ApplyAction(action);
        }
        // Take actions and update trail(s)
        // Calculate result
    }
}
