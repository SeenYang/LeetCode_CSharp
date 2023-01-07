namespace LeetCode.CSharp;

public class SingleNumberC
{
    public void Test()
    {
        // var input = new[] {2, 2, 1};
        var input = new[] {4, 1, 2, 1, 2};

        Console.WriteLine($"Single number is {SingleNumber(input)}");
    }

    public int SingleNumber(int[] nums)
    {
        nums = nums.OrderBy(n => n).ToArray();
        int count = 0, current = int.MinValue;
        foreach (var num in nums)
        {
            if (num != current)
            {
                if (count % 2 != 0)
                {
                    return current;
                }

                current = num;
            }
            count++;
        }

        return current;
    }
}