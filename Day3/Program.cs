using System.Text.RegularExpressions;

var input = File.ReadAllText(@"Input.txt");

Part1();
Part2();

void Part1()
{
    Console.WriteLine("Part 1");
    var matches = Regex.Matches(input, @"mul\((\d+),(\d+)\)");
    int result = 0;
    foreach (Match match in matches)
    {
        result += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
    }
    Console.WriteLine($"Sum of multiplications: {result}"); // 196826776
}

void Part2()
{
    Console.WriteLine("Part 2");
    var matches = Regex.Matches(input, @"(mul\((\d+),(\d+)\))|(do\(\))|(don't\(\))");
    int result = 0;
    var enabled = true;
    foreach (Match match in matches)
    {
        if (match.Value.StartsWith("mul"))
        {
            if (enabled)
            {
                result += int.Parse(match.Groups[2].Value) * int.Parse(match.Groups[3].Value);
            }
        }
        else
            enabled = match.Value switch
            {
                "do()" => true,
                "don't()" => false,
                _ => enabled
            };
    }
    Console.WriteLine($"Sum of multiplications: {result}"); // 106780429
}


