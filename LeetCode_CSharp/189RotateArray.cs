namespace LeetCode.CSharp;

public class RotateArray
{
    public void Test()
    {
        var input = new int[] {1, 2, 3, 4, 5, 6, 7};
        var k = 3;
        Rotate(input, k, out input);
        input.ToList().ForEach(Console.WriteLine);
        var expectResult = new[] {5, 6, 7, 1, 2, 3, 4};
    }

    /// <summary>
    /// Try to come up as much solution as you can.
    /// Try to get solution with O(1).
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// <param name="result"></param>
    public void Rotate(int[] nums, int k, out int[] result)
    {
        // linq skip take.
        // nums = nums.Skip(nums.Length - k).Concat(nums.Take(nums.Length - k)).ToArray();

        // c# 8+
        result = nums[^k..].Concat(nums.Take(nums.Length - k)).ToArray();
    }
}