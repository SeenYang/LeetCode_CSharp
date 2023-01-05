namespace LeetCode.CSharp;

public class IntersectionOfTwoArrays
{
    public void Test()
    {
        // var num1 = new[] { 1, 2, 2, 1 };
        // // var num2 = new[] { 2, 2, };
        // var num1 = new[] { 4, 9, 5 };
        // var num2 = new[] { 9, 4, 9, 8, 4 };
        var num1 = new[] { 3, 1, 2 };
        var num2 = new[] { 1, 1 };
        Console.WriteLine($"result is: [{string.Join(",", Intersect(num1, num2))}]");
    }

    // Case1: What if num1 and num2 are sorted?
    // Case2: What if num2 is sorted, and limited memory available?

    public int[] Intersect(int[] num1, int[] num2)
    {
        var res = new List<int>();
        num1 = num1.OrderBy(n => n).ToArray();
        num2 = num2.OrderBy(n => n).ToArray();
        
        // Sorted and no overlapping.
        if (num1[^1] < num2[0] || num2[^1] < num1[0])
            return res.ToArray();
        
        // Always loop through the shorter array.
        if (num1.Length > num2.Length)
            (num1, num2) = (num2, num1);
        
        var index2 = 0;
        foreach(var n1 in num1) {
            for(var i = index2; i < num2.Length; i++){
                if(num2[i] != n1)
                    continue;
                index2 = i + 1;
                res.Add(n1);
                break;
            }
        }
        return res.ToArray();
    }
}