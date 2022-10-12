namespace LeetCode.CSharp;

public class RemoveDuplicatesFromSortedArrayII
{
    public void Test()
    {
    }

    public int RemoveDuplicates(int[] nums)
    {
        int i = 0;
        foreach (var num in nums)
        {
            if (i < 2 || num > nums[i - 2])
                nums[i++] = num;
        }

        return i;
    }
}