namespace Day4;

public class ElfPair
{
    public ElfPair(Elf first, Elf second)
    {
        First = first;
        Second = second;
    }

    public Elf First { get; }
    public Elf Second { get; }
    public bool Contains =>
        First.Start >= Second.Start && First.End <= Second.End ||
        Second.Start >= First.Start && Second.End <= First.End;

    public bool Overlap =>
        First.Start >= Second.Start && First.Start <= Second.End ||
        First.End >= Second.Start && First.End <= Second.End ||
        Contains;
}