namespace LeetCode.CSharp;

public class MinMaxGameC
{
    public void Test()
    {
        // var input = new[] { 1, 3, 5, 2, 4, 8, 2, 2 };
        // var input = new[] {70, 38, 21, 22 };
        var input = new[] { 999, 939, 892, 175, 114, 464, 850, 107 };
        Console.WriteLine($"Result is {MinMaxGame(input)}");
    }

    int MinMaxGame(int[] candidates)
    {
        if (candidates.Length == 1)
        {
            return candidates[0];
        }

        var newArr = new List<int>();
        for (int i = 0; i < candidates.Length; i += 2)
        {
            newArr.Add((i / 2) % 2 == 1
                ? MaxGame(candidates[i], candidates[i + 1])
                : MinGame(candidates[i], candidates[i + 1]));
        }

        return MinMaxGame(newArr.ToArray());
    }

    int MinGame(int a, int b) => Math.Min(a, b);
    int MaxGame(int a, int b) => Math.Max(a, b);
}