using Day3;

internal class ElfGroup
{
    public ElfGroup(List<RuckSack> ruckSacks)
    {
        RuckSacks = ruckSacks;
    }

    public List<RuckSack> RuckSacks { get; }
    public char SharedItem
    {
        get
        {
            List<char> sharedItems = RuckSacks[0].Items.Where(item => RuckSacks[1].Items.Contains(item, StringComparison.Ordinal)).Distinct().ToList();
            for (int i = 1; i < RuckSacks.Count - 1; i++)
            {
                sharedItems = RuckSacks[i].Items
                    .Where(item =>
                        RuckSacks[i + 1].Items.Contains(item, StringComparison.Ordinal) &&
                        sharedItems.Contains(item))
                    .Distinct()
                    .ToList();
            }

            return sharedItems.First();
        }
    }

    public int Priority => char.IsUpper(SharedItem) ? SharedItem - 38 : SharedItem % 32;
}