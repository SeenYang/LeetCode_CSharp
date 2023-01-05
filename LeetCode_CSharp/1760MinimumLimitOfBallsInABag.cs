namespace LeetCode.CSharp;

// https://leetcode.com/problems/minimum-limit-of-balls-in-a-bag/
public class MinimumLimitOfBallsInABag
{
    public void Test()
    {
        // var bags = new[] {2, 4, 8, 2};
        // var maxOperation = 4;
        var bags = new[] {7, 17};
        var maxOperation = 2;
        // var bags = new[] {9};
        // var maxOperation = 2;
        Console.WriteLine($"Minimum penalty is {MinimumSize(bags, maxOperation)}");
    }

    /// <summary>
    /// Penalty in this quest is the max number of balls in the bag that within operation.
    /// As other similar quest, it can be converted into `Binary Search` question.
    /// 1. In ideal case, the max capacity (penalty) will be max of current bags.
    /// 2. The minimum capacity (penalty) will be 1.
    ///
    /// --> Start state can be listed like:
    /// 1. cap = Capacity = (min + max) / 2.
    /// 2. count = Operation Count = 0.
    /// 3. For each bag that bag[i] > cap, count += bag[i]/cap.
    /// 4.1 If count <= maxOperations, means there's potential to optimise it. set right = cap.
    /// 4.2 If count > maxOperations, mean the capacity too small. set left = cap + 1.
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="maxOperations"></param>
    /// <returns></returns>
    public int MinimumSize(int[] nums, int maxOperations)
    {
        // General Cases.
        int min = 1, max = 1;
        foreach (var num in nums)
        {
            max = Math.Max(max, num);
        }

        int left = min, right = max;
        while (left < right)
        {
            int cap = (left + right) / 2, count = 0;
            foreach (var num in nums)
                // i.e., cap = 3, num = 9, needs (9-1) / 3 = 2 time split to [3,3,3].
                count += (num - 1) / cap;

            if (count <= maxOperations)
                right = cap;
            else
                left = cap + 1;
        }

        return left;
    }
}