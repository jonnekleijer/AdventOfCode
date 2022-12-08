using Day5;

internal class Program
{
    private static void Main()
    {
        int lineCounter = 0;
        var isCrates = true;
        var stacks = new Stack<char>[9];
        for (int i = 0; i < stacks.Length; i++)
        {
            stacks[i] = new Stack<char>();
        }

        var initialStacks = new List<char>[9];
        for (int i = 0; i < initialStacks.Length; i++)
        {
            initialStacks[i] = new List<char>();
        }

        List<Move> moves = new();

        foreach (var line in File.ReadLines("input.txt"))
        {
            if (!string.IsNullOrWhiteSpace(line) && line[1] == '1')
            {
                isCrates = false;
                for (int i = 0; i < initialStacks.Count(); i++)
                {
                    initialStacks[i].Reverse();
                    initialStacks[i].ForEach(crate =>
                    {
                        if (crate == ' ')
                        {
                            return;
                        }
                        stacks[i].Push(crate);
                    });
                }
                continue;
            }

            if (isCrates)
            {
                var crates = line.ToCrates();
                for (int i = 0; i < crates.Count; i++)
                {
                    initialStacks[i].Add(crates[i]);
                }
                lineCounter += 1;
                continue;
            }

            moves.Add(line.ToMove());
        }

        ApplyMoves(stacks, moves);
        string result = string.Empty;
        foreach (var stack in stacks)
        {
            result += stack.Pop().ToString();
        }

        Console.WriteLine($"Day 5A - {result}");
    }

    private static void ApplyMoves(Stack<char>[] stacks, List<Move> moves, bool inOrder = true)
    {
        var tempStack = new Stack<char>();
        foreach (var move in moves)
        {
            if (inOrder)
            {
                for (int i = 0; i < move.Count; i++)
                {
                    tempStack.Push(stacks[move.From].Pop());
                }
                for (int i = 0; i < move.Count; i++)
                {
                    stacks[move.To].Push(tempStack.Pop());
                }
            }
            else
            {
                for (int i = 0; i < move.Count; i++)
                {
                    stacks[move.To].Push(stacks[move.From].Pop());
                }
            }
        }
    }
}