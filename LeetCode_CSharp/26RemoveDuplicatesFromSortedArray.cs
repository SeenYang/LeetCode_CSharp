namespace LeetCode.CSharp;

public class RemoveDuplicatesFromSortedArray
{
    public void Test()
    {
        var input = new int[] {0, 0, 1, 1, 2, 2, 3, 3, 4, 4};
        Console.WriteLine($"After remove duplicates, length is {RemoveDuplicates(input)}.");
    }

    private int RemoveDuplicates(int[] nums)
    {
        // two pointers
       var current = int.MinValue;
       var j = 0;
        foreach (var num in nums)
        {
            if (num != current)
            {
                current = num;
                nums[j] = num;
                j++;
            }
        }

        return j;
    }
}