namespace Day1;

class Elf
{
    private readonly List<int> food;

    public Elf(List<int> food)
    {
        this.food = new List<int>(food);
    }

    public int TotalFood { get { return food.Sum(); } }
}