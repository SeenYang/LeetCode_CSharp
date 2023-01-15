namespace LeetCode.CSharp;

public class PerfectSquares
{
    public void Test()
    {
        var input = 4;
        Console.WriteLine($"Num Squares is {NumSquares(input)}.");
    }

    private readonly List<int> _squares = new List<int>();

    public int NumSquares(int n)
    {
        if (n == 1) return 1;
        
        // Get a list of squares of number that i^2 <= n
        for (var i = 1; i <= Math.Sqrt(n); i++)
        {
            _squares.Add(i * i);
        }
        
        #region Recursive Solution.
        
        // return minNumSquares(n);

        #endregion

        #region Greedy Enumeration

        var count = 0;
        while (count <= n)
        {
            if (IsDevidedBy(n, ++count))
                return count;
        }
        
        return count;

        #endregion
    }

    /// <summary>
    /// The worst case, count = target (divided by 1)
    /// 5 = 4 + 1 = 2^2 + 1
    /// 10 = 3^2 + 1
    /// Consider here's the cases:
    /// target:             1   2   3   4   5   6   7   8   9   10
    /// num of perfect sqr: 1   2   3   1   2   3   4   2   1   2
    ///
    ///
    /// The idea of this approach is, we assume we can divided by 1 sqrs, if no, increase 1 and try again.
    /// The steps would be:
    /// 1. check whether the remain is some number's sqr.
    /// 2. if no, set temp target as target - 1 (always be the minimum sqr) and repeat the approach.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="count"></param>
    /// <returns></returns>
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