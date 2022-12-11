namespace Day8;

internal static class StringExtentions
{
    internal static int[] ToTreeLine(this string line) 
        => line.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray();
}
