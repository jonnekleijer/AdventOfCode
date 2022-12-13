namespace Day9;

class Simulation
{
    public Simulation(string fileName, int knotCount = 2)
    {
        FileName = fileName;
        KnotCount = knotCount;
    }

    public string FileName { get; }
    public int KnotCount { get; }
    public ICollection<Position> TailTrace { get; } = new List<Position>();
    public ICollection<HeadAction> HeadActions { get; } = new List<HeadAction>();

    public readonly Head head = new();
    public readonly Tail tail = new();

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
            ApplyAction(action);
        }
    }

    private void ApplyAction(HeadAction action)
    {
        for (int i = 0; i < action.Steps; i++)
        {
            head.Move(action.Direction);
            var tailMove = head.Position.TailMove(tail.Position);
            if (tailMove is not null)
            {
                tail.Move((Direction)tailMove);
                TailTrace.Add(new Position(tail.Position.X, tail.Position.Y));
            }
        }
    }
}
