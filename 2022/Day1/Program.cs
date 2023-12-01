using Day1;

List<int> food = new();
List<Elf> elves = new();

foreach (var line in File.ReadLines("input.txt"))
{
    var i = int.TryParse(line, out int value);
    if (i)
    {
        food.Add(value);
    }
    else
    {
        elves.Add(new Elf(food));
        food.Clear();
    }
}

var highElf = elves.OrderByDescending(e => e.TotalFood).First();
Console.WriteLine($"Day 1A - {highElf.TotalFood}");

var highestThreeElves = elves.OrderByDescending(e => e.TotalFood).Take(3);
Console.WriteLine($"Day 1B - {highestThreeElves.Sum(e => e.TotalFood)}");
