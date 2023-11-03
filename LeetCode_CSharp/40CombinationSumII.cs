using System.Runtime.InteropServices;

namespace LeetCode.CSharp;

public class CombinationSumII
{
    public void Test()
    {
        var input = new[] { 10, 1, 2, 7, 6, 1, 5 };
        var res = CombinationSum2(input, 8);
        foreach (var set in res)
            Console.WriteLine($"[{string.Join(",", set)}]");
    }

    public IEnumerable<IEnumerable<int>> CombinationSum2(int[] candidates, int target)
    {
        IList<IList<int>> res = new List<IList<int>>();
        candidates = candidates.Where(c => c <= target).OrderBy(c => c).ToArray();
        CombinationHelper(candidates, new List<int>(), 0, target, res);
        return res;
    }

    private void CombinationHelper(int[] candidates, List<int> currentSet, int currentIndex, int remain,
        IList<IList<int>> res)
    {
        Console.WriteLine($"Current remain(target) is {remain}, CurrentSet is {string.Join(",", currentSet)}.");

        if (remain == 0)
        {
            res.Add(new List<int>(currentSet));
            return;
        }

        for (int i = currentIndex; i < candidates.Length; i++)
        {
            if (i > currentIndex && candidates[i] == candidates[i - 1])
                continue;

            if (candidates[i] > remain)
                // Next candidate already bigger than remain. this path is not available. 
                return;

            currentSet.Add(candidates[i]);
            CombinationHelper(candidates, currentSet, i + 1, remain - candidates[i], res);
            // Reset state.
            currentSet.RemoveAt(currentSet.Count - 1);
        }
    }
}