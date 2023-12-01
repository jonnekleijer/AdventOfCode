namespace Day5;

internal static class StringExtensionsClass
{
    internal static Move ToMove(this string line)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            return new Move();
        }

        var parse = line.Split(' ').Skip(1).Where((x, i) => i % 2 == 0).ToList();

        int.TryParse(parse[0], out int count);
        int.TryParse(parse[1], out int from);
        int.TryParse(parse[2], out int to);

        return new Move(count, from - 1, to -1);
    }

    internal static List<char> ToCrates(this string line) => line.Skip(1).Where((x, i) => i % 4 == 0).ToList();
}
