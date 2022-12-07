List<ElfGroup> groups = new();
List<RuckSack> ruckSacks= new();
const int ElfGroupSize = 3;

foreach (string line in File.ReadLines("input.txt"))
{
    ruckSacks.Add(line.ToRuckSack());
    if (ruckSacks.Count is ElfGroupSize)
    {
        groups.Add(new ElfGroup(new List<RuckSack>(ruckSacks)));
        ruckSacks.Clear();
    }
}

var group = groups.First();
Console.WriteLine(group.SharedItem);

Console.WriteLine($"Day 3A - {groups.Sum(g => g.RuckSacks.Sum(r => r.Priority))}");
Console.WriteLine($"Day 3B - {groups.Sum(g => g.Priority)}");
