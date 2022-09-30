namespace LeetCode.CSharp;

public class PerfectSquares
{
    public void Test()
    {
        var input = 12;
        Console.WriteLine($"Num Squares is {NumSquares(input)}.");
    }

    private readonly List<int> _squares = new List<int>();

    public int NumSquares(int n)
    {
        #region Recursive Solution.

        // Get a list of squares of number that i^2 <= n
        // for (var i = 1; i < Math.Sqrt(n); i++)
        // {
        //     _squares.Add(i * i);
        // }
        //
        // return minNumSquares(n);

        #endregion

        #region Greedy Enumeration

        for (int i = 1; i * i <= n; i++)
            _squares.Add(i * i);

        var count = 1;
        while (count <= n)
        {
            if (IsDevidedBy(n, ++count))
                return count;
        }

        return count;

        #endregion
    }

    private bool IsDevidedBy(int n, int count)
    {
        if (count == 1)
            return _squares.Contains(n);

        foreach (var square in _squares)
        {
            if (IsDevidedBy(n - square, count - 1))
                return true;
        }

        return false;
    }
    private int minNumSquares(int i)
    {
        // Basic Cases:
        if (_squares.Contains(i))
            return 1;


        var minNum = int.MaxValue;
        foreach (var square in _squares)
        {
            if (i < square)
                break;
            var newMin = minNumSquares(i - square) + 1;
            minNum = Math.Min(minNum, newMin);
        }

        return minNum;
    }
}