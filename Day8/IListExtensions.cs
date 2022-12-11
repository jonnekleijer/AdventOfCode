namespace Day8;

internal static class IListExtensions
{
    internal static T[,] ToMatrix<T>(this IList<T[]> arrays)
    {
        int length = arrays[0].Length;
        T[,] matrix = new T[arrays.Count, length];
        for (int i = 0; i < arrays.Count; i++)
        {
            var array = arrays[i];
            if (array.Length != length)
            {
                throw new ArgumentException("All arrays must be the same length");
            }
            for (int j = 0; j < length; j++)
            {
                matrix[i, j] = array[j];
            }
        }
        return matrix;
    }
}
