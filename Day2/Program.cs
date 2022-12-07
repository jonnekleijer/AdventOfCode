List<Round> strategy = new();
foreach (string line in File.ReadLines("input.txt"))
{
    var choices = line.Split(" ");
    var theirChoice = choices[0].ToChoice();
    var myChoice = choices[1].ToChoice();
    strategy.Add(new Round(theirChoice, myChoice));
}
Console.WriteLine($"Day 1A - {strategy.Sum(r => r.Score)}");

strategy.Clear();
foreach (string line in File.ReadLines("input.txt"))
{
    var choices = line.Split(" ");
    var theirChoice = choices[0].ToChoice();
    var result = choices[1].ToResult();
    strategy.Add(new Round(theirChoice, result));
}

Console.WriteLine($"Day 1B - {strategy.Sum(r => r.Score)}");
