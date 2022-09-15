Test();

void Test()
{
    var input = new int[][]
    {
        new int[] { 3, 1, 2, 4, 5 },
        new int[] { 1, 2, 3, 4 },
        new int[] { 3, 4, 5, 6 },
    };
    var result = Intersection(input);
    Console.WriteLine($"Common set length is{result.Count}");
    foreach (var num in result)
    {
        Console.WriteLine($"{num}");
    }
}


IList<int> Intersection(int[][] nums)
{
    var targert = nums.Length;

    var dic = new Dictionary<int, int>();
    foreach (var numList in nums)
    {
        foreach (var num in numList)
        {
            if (dic.TryGetValue(num, out var count))
            {
                dic[num] = ++count;
            }
            else
            {
                dic[num] = 1;
            }
        }
    }

    return dic.Where(d => d.Value == targert)
        .Select(d => d.Key)
        .OrderBy(d => d)
        .ToArray();
}