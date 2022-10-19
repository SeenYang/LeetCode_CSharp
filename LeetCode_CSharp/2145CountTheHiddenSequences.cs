namespace LeetCode.CSharp;

public class CountTheHiddenSequences
{
    public void Test()
    {
        // var diff = new[] {1, -3, 4};
        // int lower = 1, upper = 6;       
        var diff = new[] {-40};
        int lower = -46, upper = 53;
        Console.WriteLine($"Result is {NumberOfArrays(diff, lower, upper)}");
    }


    /**
     * start with 0.
     * if upper - lower < max - min --> no possible hidden sequences.
     * if upper - lower == max - min --> there's one hidden sequence.
     * if upper - lower == max - min + k, we have k + 1 hidden sequences.
     */
    public int NumberOfArrays(int[] differences, int lower, int upper)
    {
        long a = 0, max = 0, min = 0;
        foreach (var difference in differences)
        {
            a += difference;
            max = Math.Max(max, a);
            min = Math.Min(min, a);
        }

        return (int) Math.Max(0, (upper - lower) - (max - min) + 1);
    }
    #region timeout solution
    // public int NumberOfArrays(int[] differences, int lower, int upper) {
    //     // base cases
    //     if (differences.Length == 0)
    //         return 0;
    //     // if differences only contains 1 diff, then the arrays will be:
    //     // [lower, lower + diff[0]], [lower+1, lower+1+diff[0]] ... [upper - diff[0], upper].
    //     if (differences.Length == 1)
    //         return upper - lower - Math.Abs(differences[0]) + 1;
    //     var res = 0;
    //     for (int i = lower; i < upper; i++)
    //     {
    //         var start = i;
    //         var count = 0;
    //         foreach (var d in differences)
    //         {
    //             if (start + d >= lower && start + d <= upper)
    //             {
    //                 start += d;
    //                 count++;
    //             }
    //             else
    //                 break;
    //         }
    //
    //         if (count == differences.Length)
    //             res++;
    //     }
    //
    //     return res;
    // }
    #endregion
}