namespace Day9;

class Simulation
{
    public Simulation(string fileName, int knotCount = 2)
    {
        FileName = fileName;
        KnotCount = knotCount;

        InitializeKnots(knotCount);
    }

    public string FileName { get; }
    public int KnotCount { get; }
    public Knot LastKnot { get => knots.Last(); }
    public ICollection<Position> LastKnotTrace { get; } = new List<Position>();
    public ICollection<HeadAction> HeadActions { get; } = new List<HeadAction>();

    public readonly Head head = new();
    private readonly List<Knot> knots = new();

    private void InitializeKnots(int knotCount)
    {
        for (int i = 0; i < knotCount - 1; i++)
        {
            knots.Add(new Knot());
        }
    }

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

        // Move head and trailing knot.
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
            for (int knotIndex = 0; knotIndex < knots.Count(); knotIndex++)
            {
                var reference = FindReference(knotIndex);
                MoveNextKnot(knotIndex, reference);
            }
            LastKnotTrace.Add(new Position(LastKnot.Position.X, LastKnot.Position.Y));
        }
    }

    private void MoveNextKnot(int knotIndex, Position reference)
    {
        var knotMove = reference.KnotMove(knots[knotIndex].Position);
        if (knotMove is not null)
        {
            knots[knotIndex].Move((Direction)knotMove);
        }
    }

    private Position FindReference(int knotIndex)
    {
        Position reference;
        if (knotIndex == 0)
        {
            reference = head.Position;

        }
        else
        {
            reference = knots[knotIndex - 1].Position;
        }

        return reference;
    }
}
