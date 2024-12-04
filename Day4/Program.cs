var input = File.ReadAllLines(@"Input.txt");


Part1();
Part2();

void Part1()
{
    Console.WriteLine("Part 1");

    char[,] map = new char[input.Length, input[0].Length];
    for (int i = 0; i < input.Length; i++)
    {
        for (int j = 0; j < input[i].Length; j++)
        {
            map[i, j] = input[i][j];
        }
    }

    var searchString = "XMAS";
    var wordCount = 0;
    for (int i = 0; i <= map.GetUpperBound(0); i++)
    {
        for (int j = 0; j <= map.GetUpperBound(1) ; j++)
        {
            wordCount = CheckWord(map,i,j,searchString,Direction.Right) ? wordCount + 1: wordCount;
            wordCount = CheckWord(map, i, j, searchString, Direction.Left) ? wordCount + 1 : wordCount;
            wordCount = CheckWord(map, i, j, searchString, Direction.Up) ? wordCount + 1 : wordCount;
            wordCount = CheckWord(map, i, j, searchString, Direction.Down) ? wordCount + 1 : wordCount;
            wordCount = CheckWord(map, i, j, searchString, Direction.DiagonalLeftDown) ? wordCount + 1 : wordCount;
            wordCount = CheckWord(map, i, j, searchString, Direction.DiagonalRightUp) ? wordCount + 1 : wordCount;
            wordCount = CheckWord(map, i, j, searchString, Direction.DiagonalLeftUp) ? wordCount + 1 : wordCount;
            wordCount = CheckWord(map, i, j, searchString, Direction.DiagonalRightDown) ? wordCount + 1 : wordCount;
        }
    }
    Console.WriteLine($"{searchString} appears {wordCount} times"); // 2358
}


bool CheckWord(char[,] map, int row, int column, string searchString, Direction direction)
{
    for (int i = 0; i < searchString.Length; i++)
    {
        if (i > 0)
        {
            switch (direction)
            {
                case Direction.Right:
                    column++;
                    break;
                case Direction.Left:
                    column--;
                    break;
                case Direction.Up:
                    row--;
                    break;
                case Direction.Down:
                    row++;
                    break;
                case Direction.DiagonalLeftDown:
                    column--;
                    row++;
                    break;
                case Direction.DiagonalLeftUp:
                    column--;
                    row--;
                    break;
                case Direction.DiagonalRightDown:
                    row++;
                    column++;
                    break;
                case Direction.DiagonalRightUp:
                    row--;
                    column++;
                    break;
            }
        }
        
        if (row <= map.GetUpperBound(0) &&
            row >= 0 &&
            column <= map.GetUpperBound(1) &&
            column >= 0)
        {
            if (map[row, column] != searchString[i])
            {
                return false;
            }

            if (i == searchString.Length - 1)
            {
                //Console.WriteLine($"{searchString} found at {row}, {column}");
                return true;
            }
        }
    }
    return false;
}

bool CheckXmas(char[,] map, int row, int column)
{
    var xmas = new List<List<char>>
    {
        new(){ 'M', 'M', 'S', 'S' },
        new(){ 'S', 'S', 'M', 'M' },
        new(){ 'S', 'M', 'S', 'M' },
        new(){ 'M', 'S', 'M', 'S' }
    };

    if (map[row, column] == 'A')
    {

        if (row + 1 <= map.GetUpperBound(0) &&
            row - 1 >= 0 &&
            column + 1 <= map.GetUpperBound(1) &&
            column - 1>= 0)
        {
            for (int i = 0; i < 4; i++)
            {
                if (map[row - 1, column - 1] != xmas[i][0])
                {
                    continue;
                }
                if (map[row - 1, column + 1] != xmas[i][1])
                {
                    continue;
                }
                if (map[row + 1, column - 1] != xmas[i][2])
                {
                    continue;
                }
                if (map[row + 1, column + 1] != xmas[i][3])
                {
                    continue;
                }
                //Console.WriteLine($"X-mas found: {row}-{column}");
                return true;
            }
        }
    }
    return false;
}


void Part2()
{
    Console.WriteLine("Part 2");
    char[,] map = new char[input.Length, input[0].Length];
    for (int i = 0; i < input.Length; i++)
    {
        for (int j = 0; j < input[i].Length; j++)
        {
            map[i, j] = input[i][j];
        }
    }
    var xmasCount = 0;
    for (int i = 0; i <= map.GetUpperBound(0); i++)
    {
        for (int j = 0; j <= map.GetUpperBound(1); j++)
        {
            if (CheckXmas(map, i, j))
            {
                xmasCount++;
            }
        }
    }

    Console.WriteLine($"X-MAS found: {xmasCount}"); // 1737

}


enum Direction
{
    Up,
    Down,
    Left,
    Right,
    DiagonalLeftUp,
    DiagonalRightUp,
    DiagonalLeftDown,
    DiagonalRightDown
}