namespace Day9;

class Simulation
{
    public Simulation(string fileName)
    {
        FileName = fileName;
    }

    public string FileName { get; }
    public ICollection<Position> TailTrace { get; } = new List<Position>();
    public ICollection<HeadAction> HeadActions { get; } = new List<HeadAction>();

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
            HeadActions.Add(new HeadAction(direction, steps));
        }

        // Move head and trailing tail.
        foreach (var action in HeadActions)
        {
            for (int i = 0; i < action.Steps; i++)
            {
                Console.WriteLine($"{action.Direction} {action.Steps}");
                head.Move(action.Direction);
                var tailMove = head.Position.TailMove(tail.Position);
                if (tailMove is not null)
                {
                    tail.Move((Direction)tailMove);
                    TailTrace.Add(tail.Position);
                }
            }
        }

        // Calculate result
    }
}
