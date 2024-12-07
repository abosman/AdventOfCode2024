var input = File.ReadAllLines(@"Input.txt");
var rules = new Dictionary<int, List<int>>();
var updates = new List<List<int>>();
var sectionOneProcessed = false;

foreach (var line in input)
{
    if (string.IsNullOrWhiteSpace(line))
    {
        sectionOneProcessed = true;
        continue;
    }

    if (!sectionOneProcessed)
    {
        var parts = line.Split('|');
        var item1 = int.Parse(parts[0]);
        var item2 = int.Parse(parts[1]);

        if (!rules.TryGetValue(item1, out var values))
        {
            values = new List<int>();
            rules[item1] = values;
        }
        values.Add(item2);
    }
    else
    {
        var update = line.Split(',').Select(int.Parse).ToList();
        updates.Add(update);
    }
}

Part1();
Part2();

void Part1()
{
    Console.WriteLine("Part 1");
    var middlePagesCount = 0;

    foreach (var update in updates)
    {
        var valid = true;

        for (int i = 0; i < update.Count - 1 && valid; i++)
        {
            for (int j = i + 1; j < update.Count; j++)
            {
                if (!ValidRule(update[i], update[j]))
                {
                    valid = false;
                    break;
                }
            }
        }

        if (valid)
        {
            var middlePageNumber = update[update.Count / 2];
            middlePagesCount += middlePageNumber;
        }
    }

    Console.WriteLine($"Total of middle page numbers: {middlePagesCount}"); // 4578
}

bool ValidRule(int item1, int item2)
{
    return rules.TryGetValue(item1, out var values) && values.Contains(item2);
}

void Part2()
{
    Console.WriteLine("Part 2");
    var middlePagesCount = 0;

    foreach (var update in updates)
    {
        var valid = true;

        for (int i = 0; i < update.Count - 1 && valid; i++)
        {
            for (int j = i + 1; j < update.Count; j++)
            {
                if (!ValidRule(update[i], update[j]))
                {
                    valid = false;
                    break;
                }
            }
        }

        if (!valid)
        {
            update.Sort(new SortUpdates(rules));
            var middlePageNumber = update[update.Count / 2];
            middlePagesCount += middlePageNumber;
        }
    }

    Console.WriteLine($"Total of middle page numbers: {middlePagesCount}"); // 6179
}

class SortUpdates(Dictionary<int, List<int>> rules) : IComparer<int>
{
    public int Compare(int x, int y)
    {
        if (rules.TryGetValue(x, out var values) && values.Contains(y))
        {
            return -1;
        }

        if (rules.TryGetValue(y, out values) && values.Contains(x))
        {
            return 1;
        }

        return 0;
    }
}