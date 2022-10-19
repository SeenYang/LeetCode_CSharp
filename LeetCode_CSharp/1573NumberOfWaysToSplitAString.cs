namespace LeetCode.CSharp;

public class NumberOfWaysToSplitAString
{
    public void Test()
    {
        var input = "10101";
        Console.WriteLine($"Result: {NumWays(input)}.");
    }

    public int NumWays(string s)
    {
        var num = s.ToCharArray().Select(c => int.Parse(s)).Sum();
        // If input string is all 0s, then no matter how to split, it is valid.
        if (num == 0)
        {
            var n = s.Length;
            return (n - 2) * (n - 1) / 2;
        }
        
        // Count 1s in the string, if it's not able to be divided by 3, then that's not valid input.
        if (num % 3 != 0)
            return 0;
        
        // General Case:
        // Get to know how many 1s need to be in one block.
        // Loop through the char list. once we reach to the number of 1s in the block, start accumulate the 0s.
        // Repeat the same for next block.
        // result would be (0s in block 1 after the last 1) * (0s in block 2 after the last 1).
        
        
        return 0;
    }
}