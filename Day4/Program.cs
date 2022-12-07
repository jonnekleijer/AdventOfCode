using Day4;
using System.Text.RegularExpressions;

List<ElfPair> pairs = new();
foreach (var line in File.ReadLines("input.txt"))
{
    pairs.Add(line.ToElfPair());
}

Console.WriteLine($"Day 4A - {pairs.Count(p => p.Contains)}");
Console.WriteLine($"Day 4B - {pairs.Count(p => p.Overlap)}");