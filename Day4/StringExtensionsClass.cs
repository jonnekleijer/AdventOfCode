using Day4;

internal static class StringExtensionsClass
{
    public static ElfPair ToElfPair(this string s)
    {
        var elfPairRanges = s.Split(",");
        var first = elfPairRanges[0].ToElf();
        var second = elfPairRanges[1].ToElf();
        return new ElfPair(first, second);
    }

    public static Elf ToElf(this string s)
    {
        return new Elf(s);
    }
}
