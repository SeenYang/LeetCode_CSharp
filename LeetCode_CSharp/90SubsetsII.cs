namespace LeetCode.CSharp;

public class SubsetsII
{
    public void Test()
    {
        // var input = new int[] { 1, 2, 2, 3 };
        // var input = new int[] { 0 };
        var input = new int[] { 4, 4, 4, 1, 4 };
        Console.WriteLine("All possible sub set of the input is:");
        var res = SubsetsWithDup(input);
        foreach (var set in res)
        {
            Console.WriteLine($"[{string.Join("", set)}]");
        }
    }

    // by default empty array always valid res.
    private readonly IList<IList<int>> _res = new List<IList<int>>();

    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        nums = nums.OrderBy(n => n).ToArray();
        var current = new List<int> { };
        Helper(nums, current, 0);

        return _res;
    }

    private void Helper(int[] nums, List<int> currentSubSet, int currentStart)
    {
        // Add current sub set;
         _res.Add(new List<int>(currentSubSet));

        for (var i = currentStart; i < nums.Length; i++)
        {
            // If current num same as previous one, it won't generate new sub-sets set
            if (i != currentStart && nums[i] == nums[i - 1])
                continue;

            currentSubSet.Add(nums[i]);
            // Iterate to next number combination from current index.
            Helper(nums, currentSubSet, i + 1);

            // back track to previous status.
            currentSubSet.RemoveAt(currentSubSet.Count - 1);
        }
    }
}