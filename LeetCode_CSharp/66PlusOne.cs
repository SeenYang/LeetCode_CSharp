namespace LeetCode.CSharp;

public class PlusOne {
    public void Test()
    {
        // var input = new[] { 1, 2, 3 };
        var input = new[] {9, 9};
        PlusOneM(input);
    }

    public int[] PlusOneM(int[] nums)
    {
        var res = new List<int>();
        if (nums[^1] < 9)
        {
            // case 1, if nums[^0] < 9, just increase the last one and return.
            nums[^1] += 1;
            res = nums.ToList();
        }
        else
        {
            // case 2, if num[^1] == 9, means we need to push to next digit.
            // 1. reverse the ints.
            nums = nums.Reverse().ToArray();
            nums[0] = 0;
            
            // 2. loop through from 0 till end, and plus one.
            for (int i = 1; i < nums.Length; i++)
            {
                nums[i] = (nums[i] + 1) % 10;
                if(nums[i] != 0)
                    break;
            }

            // For cases that all 9s, we need to add extra 1 at the end.
            if (nums[^1] == 0)
                // need to add extra 1 to the first element.
                nums = nums.Concat(new[] { 1 }).ToArray();

            res = nums.Reverse().ToList();
        }
        
       
        res.ForEach(Console.WriteLine);
        return res.ToArray();
    }
}