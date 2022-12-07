internal class RuckSack
{
    public RuckSack(string firstCompartment, string secondCompartment)
    {
        FirstCompartmentItems = firstCompartment;
        SecondCompartmentItems = secondCompartment;
    }

    public string FirstCompartmentItems { get; }
    public string SecondCompartmentItems { get; }
    public string Items { get => FirstCompartmentItems + SecondCompartmentItems; }
    public char SharedItem { get => FirstCompartmentItems.First(i => SecondCompartmentItems.Contains(i, StringComparison.Ordinal)); }
    public int Priority => char.IsUpper(SharedItem) ? SharedItem - 38 : SharedItem % 32;
}