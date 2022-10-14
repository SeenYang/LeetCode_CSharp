namespace LeetCode.CSharp;

public class FlowerPlantingWithNoAdjacent
{
    public void Test()
    {
    }

    /// <summary>
    /// Because there's no node that with more than 3 connections, there's always be one flower can be planted.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="paths"></param>
    /// <returns></returns>
    public int[] GardenNoAdj(int n, int[][] paths)
    {
        // Initial dic for garden.
        var gardens = new Dictionary<int, List<int>>();
        for (var i = 0; i < n; i++)
            gardens[i] = new List<int>();
        foreach (var path in paths)
        {
            gardens[path[0] - 1].Add(path[1] - 1);
            gardens[path[1] - 1].Add(path[0] - 1);
        }

        var res = new int[n];

        for (var i = 0; i < n; i++)
        {
            var colours = new int[5];
            foreach (var neighbour in gardens[i])
                colours[res[neighbour]] = 1; // for garden i, mark colour it's neighbours already used.

            for (var c = 4; c >= 1; c--)
                if (colours[c] != 1)
                    res[i] = c;
        }

        return res;
    }
}