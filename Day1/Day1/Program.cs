var input = File.ReadAllLines(@"Input.txt");

Part1();
Part2();

void Part1()
{
    Console.WriteLine("Part 1");
    var list1 = new List<int>();
    var list2 = new List<int>();
    
    foreach (var line in input)
    {
        var parts = line.Split("   ");
        list1.Add(int.Parse(parts[0]));
        list2.Add(int.Parse(parts[1]));
    }
    list1.Sort();
    list2.Sort();
    var totalDistance = 0;
    for (var i = 0; i < list1.Count; i++)
    {
        // calculate the distance between the two values
        var distance = Math.Max(list1[i], list2[i]) - Math.Min(list1[i], list2[i]);
        Console.WriteLine($"Distance between {list1[i]} and {list2[i]} is {distance}");
        totalDistance += distance;
    }
    
    Console.WriteLine($"Total distance: {totalDistance}"); // 3574690
}

void Part2()
{
    Console.WriteLine("Part 2");
    var list1 = new List<int>();
    var list2 = new List<int>();

    foreach (var line in input)
    {
        var parts = line.Split("   ");
        list1.Add(int.Parse(parts[0]));
        list2.Add(int.Parse(parts[1]));
    }
    var totalSimilarityScore = 0;
    foreach (var similarityScore in list1.Select(t => t * list2.Count(l => l == t)))
    {
        Console.WriteLine($"Similarity score is {similarityScore}");
        totalSimilarityScore += similarityScore;
    }
    Console.WriteLine($"Total similarity score: {totalSimilarityScore}"); // 22565391
}
