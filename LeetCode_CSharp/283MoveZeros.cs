namespace LeetCode.CSharp;

public class MoveZeros
{
    public void Test()
    {
        // var nums = new[] { 0, 1, 0, 3, 12 };
        // var nums = new[] { 0, 1, 4, 3, 12 };
        var nums = new[] { 2, 1 };
        MoveZeroesM(nums);
    }

    public void MoveZeroesM(int[] nums)
    {
        for (int i = 0, j = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0) continue;

            (nums[i], nums[j]) = (nums[j], nums[i]);
            j++;
        }

        nums.ToList().ForEach(Console.WriteLine);
    }
}