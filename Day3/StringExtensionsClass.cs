using Day3;

internal static class StringExtensionsClass
{
    public static RuckSack ToRuckSack(this string s)
    {
        var middle = s.Length / 2;
        var firstRuckSack = s[..middle];
        var secondRuckSack = s[middle..];
        return new RuckSack(firstRuckSack, secondRuckSack);
    }
}
