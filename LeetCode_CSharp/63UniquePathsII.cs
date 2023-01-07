namespace LeetCode.CSharp;

public class UniquePathsII
{
    private int?[,] memo;

    public void Test()
    {
        var map = new[]
        {
            new[] { 0, 0, 0 },
            new[] { 0, 1, 0 },
            new[] { 0, 0, 0 }
        };

        var res = UniquePathsWithObstacles(map);
        Console.WriteLine($"UniquePath count is: {res}.");
    }

    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        var m = obstacleGrid.Length;
        var n = obstacleGrid[0].Length;
        memo = new int?[m, n];

        return dfs(obstacleGrid, m - 1, n - 1);
    }

    private int dfs(int[][] matrix, int i, int j)
    {
        Console.WriteLine($"looking for {i}, {j}.");
        // three base cases:
        // 1. if i,j = 0,0 --> return 1.
        // 2. if i,j out of boundary --> return 0.
        // 3. if i,j obstacle --> return 0.
        if (i < 0 || i >= matrix.Length ||
            j < 0 || j >= matrix[0].Length ||
            matrix[i][j] == 1)
            return 0;
        
        if (i == 0 && j == 0)
            return 1;
        
        if (memo[i, j] != null)
        {
            Console.WriteLine($"looking for memo value {i}, {j}.");
            return memo[i, j].Value;
        }

        var res = 0;
        res += dfs(matrix, i - 1, j);
        res += dfs(matrix, i, j - 1);

        return (int)(memo[i, j] = res);
    }
}