namespace Day8;

internal static class ArrayExtensions
{
    internal static bool[] GreaterThan<T>(this T[] array, T[] otherArray)
        where T : IComparable<T>
    {
        var comparison = Compare(array, otherArray);
        return comparison.Select(value =>
        {
            if (value <= 0)
            {
                return false;
            }
            return true;
        }).ToArray();
    }

    private static int[] Compare<T>(T[] array, T[] otherArray) where T : IComparable<T>
    {
        int[] result = new int[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            result[i] = array[i].CompareTo(otherArray[i]);
        }
        return result;
    }
}
