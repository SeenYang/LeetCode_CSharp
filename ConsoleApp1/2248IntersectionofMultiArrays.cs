namespace ConsoleApp1;

public class IntersectionofMultiArrays
{
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
}