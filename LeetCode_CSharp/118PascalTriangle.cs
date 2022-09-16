namespace LeetCode.CSharp;

public class PascalTriangle
{
    public void Test()
    {
        var n = 10;
        Console.WriteLine($"Pascal Triangle with {n} is:");
        var result = Generate(n);
        foreach (var list in result)
        {
            Console.WriteLine($"[{string.Join(", ", list)}]");
        }
    }

    private IList<IList<int>> Generate(int numRows)
    {
        var seed = new List<int> { 1 };
        IList<IList<int>> result = new List<IList<int>> { seed };
        for (int i = 1; i < numRows; i++)
        {
            result.Add(Helper(result[i - 1].ToList()));
        }

        return result;
    }

    private List<int> Helper(List<int> input)
    {
        // Base Case:
        if (input.Count == 1)
            return new List<int> { 1, 1 };

        // General Case;
        var res = new List<int> { 1 };
        for (int i = 1; i < input.Count; i++)
        {
            res.Add(input[i - 1] + input[i]);
        }

        res.Add(1);

        return res;
    }
}