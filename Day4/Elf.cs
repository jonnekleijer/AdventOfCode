namespace Day4;

public class Elf
{
    public Elf(string range)
    {
        Range = range.Split("-");
    }

    public string[] Range { get; }
    public int Start => int.Parse(Range.First());
    public int End => int.Parse(Range.Last());
}