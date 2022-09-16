namespace LeetCode.CSharp;
// https://leetcode.com/problems/can-make-arithmetic-progression-from-sequence/

public class CanMakeArithmeticProgressionFromSequence
{
    public void Test()
    {
        var input = new List<int> { 3, 5, 1, 7 };
        Console.WriteLine(
            $"[{string.Join(", ", input)}] is Arithmetic Progression? {CanMakeArithmeticProgression(input.ToArray())}");
    }

    private bool CanMakeArithmeticProgression(int[] arr)
    {
        if (arr.Length < 3)
            return true;
        arr = arr.OrderBy(n => n).ToArray();
        var dif = arr[1] - arr[0];

        for (int i = 2; i < arr.Length; i++)
        {
            if (arr[i] - arr[i - 1] != dif)
                return false;
        }

        return true;
    }
}