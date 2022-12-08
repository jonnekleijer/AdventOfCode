internal class Program
{
    const int STARTOFPACKETSIZE = 14;

    private static void Main()
    {
        string stream = File.ReadLines("input.txt").First();
        var result = GetStartOfPacket(stream);

        Console.WriteLine($"Day 5A - {result.End}");
    }

    static StartOfPackage GetStartOfPacket(string stream)
    {
        for (int i = 0; i < stream.Length; i++)
        {
            var code = stream.Substring(i, STARTOFPACKETSIZE);
            if (code.Distinct().Count() == STARTOFPACKETSIZE)
            {
                return new StartOfPackage(i, code);
            }
        }
        throw new KeyNotFoundException("Not found start of packet.");
    }

    record StartOfPackage(int Start, string Code)
    {
        public int End { get => Start + STARTOFPACKETSIZE; }
    };
}
