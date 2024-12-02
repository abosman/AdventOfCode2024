var input = File.ReadAllLines(@"Input.txt");

Part1();
Part2();

void Part1()
{
    Console.WriteLine("Part 1");
    var safeReportsCount = 0;
    foreach (var line in input)
    {
        var parts = line.Split(" ");
        var levels = parts.Select(int.Parse).ToList();
        if (ValidReport(levels))
        {
            Console.WriteLine($"Line: {line} is a valid report");
            safeReportsCount++;
        }
        else
        {
            Console.WriteLine($"Line: {line} is not a valid report");
        }
    }
    Console.WriteLine($"Number of safe reports: {safeReportsCount}"); // 534
}

void Part2()
{
    Console.WriteLine("Part 2");
    var safeReportsCount = 0;
    foreach (var line in input)
    {
        var parts = line.Split(" ");
        var levels = parts.Select(int.Parse).ToList();
        if (ValidReport(levels))
        {
            Console.WriteLine($"Line: {line} is a valid report");
            safeReportsCount++;
        }
        else
        {
            var combinations = GenerateCombinations(levels);
            if (combinations.Any(ValidReport))
            {
                Console.WriteLine($"Line: {line} is a valid report with a single bad level");
                safeReportsCount++;
            }
            else
            {
                Console.WriteLine($"Line: {line} is not a valid report");
            }
        }
    }
    Console.WriteLine($"Number of safe reports: {safeReportsCount}"); // 577
}

bool ValidReport(List<int> levels)
{
    var sortOrder = 0;
    for (int i = 0; i < levels.Count-1; i++)
    {
        var result = CheckTwoNumbers(levels[i], levels[i+1]);
        if (i == 0)
        {
            sortOrder = result.Item1;
        }
        
        if (result.Item1 != sortOrder || result.Item1 == 0)
        {
            return false;
        }

        if (result.Item2 is < 1 or > 3)
        {
            return false;
        }
    }
    return true;
}

(int,int) CheckTwoNumbers(int number1, int number2)
{
    var distance = Math.Abs(number1 - number2);
    if (number1 > number2)
    {
        return (1, distance);
    }
    return number1 < number2 ? (-1, distance) : (0, 0);
}

List<List<int>> GenerateCombinations(List<int> levels)
{
    List<List<int>> combinations = new List<List<int>>();
    for (int i = 0; i < levels.Count; i++)
    {
        var newLevels = new List<int>(levels);
        newLevels.RemoveAt(i);
        combinations.Add(newLevels);
    }
    return combinations;
}