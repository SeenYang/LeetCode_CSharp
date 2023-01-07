namespace LeetCode.CSharp;

public class TwoSum
{
    public void Test()
    {
        var input = new int[] { 7, 2, 11, 15 };
        var target = 9;

        var res = TwoSumM(input, target);
        Console.WriteLine($"Result is {res[0]}, {res[1]}.");
    }

    public int[] TwoSumM(int[] nums, int target)
    {

        for (int i = 0; i < nums.Length; i++)
        {
            var res = helper(nums, target - nums[i], i + 1);
            if (res != null)
                return res;
        }
        return new[] { 0, 0 };
    }

    private int[]? helper(int[] nums, int target, int currentIndex)
    {
        for (var i = currentIndex; i < nums.Length; i++)
        {
            if (nums[i] == target)
                return new[] { currentIndex - 1, i };
        }

        return null;
    }
}