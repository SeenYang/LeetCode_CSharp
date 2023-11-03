namespace LeetCode.CSharp;

public class MissingNumberC
{
    public void Test()
    {
        var input = new int[] { 0, 1, 3 };
        Console.WriteLine($"The missing number is {MissingNumber(input)}.");
    }

    public int MissingNumber(int[] nums)
    {
        var resultArr = Enumerable.Repeat(false, nums.Length + 1).ToArray();
        foreach (var num in nums)
        {
            resultArr[num] = true;
        }

        var temp = resultArr
            .Select((val, i) => new { Index = i, Value = val })
            .FirstOrDefault(t => !t.Value);
        return temp?.Index ?? -1;
    }
}