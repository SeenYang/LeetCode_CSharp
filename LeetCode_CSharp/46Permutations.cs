namespace LeetCode.CSharp;

public class Permutations
{
    public void Test()
    {
        // var input = new int[] { 1, 2, 3 };
        var input = new int[] { 1, 1, 2 };
        var result = Permute(input);
        foreach (var list in result)
        {
            Console.WriteLine($"[{string.Join(",", list)}]");
        }
    }

    private IList<IList<int>> Permute(int[] nums)
    {
        IList<IList<int>> res = new List<IList<int>>();
        res = dfs(res, nums, 0);
        return res ;
    }


    private IList<IList<int>> dfs(IList<IList<int>> res, int[] nums, int index)
    {
        if (index >= nums.Length)
        {
            res.Add(nums.ToList());
            return res;
        }

        var visited = new HashSet<int>();
        for (int i = index; i < nums.Length; i++)
        {
            Console.WriteLine($"Swap {nums[index]} with {nums[i]}. index:{index} , i:{i}");
            nums = swap(nums, index, i);
            if (visited.Add(nums[index]))
            {
                res = dfs(res, nums, index + 1);
            }
            Console.WriteLine($"Swap back {nums[index]} with {nums[i]}. index:{index} , i:{i}");
            nums = swap(nums, index, i);
        }

        return res;
    }

    private int[] swap(int[] nums, int i1, int i2)
    { 
        (nums[i1], nums[i2]) = (nums[i2], nums[i1]);
        return nums;
    }
}