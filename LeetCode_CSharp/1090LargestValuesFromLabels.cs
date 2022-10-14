namespace LeetCode.CSharp;

public class LargestValuesFromLabels {
    public void Test()
    {
        
    }

    /// <summary>
    /// `values` and `labels` are match respectively.
    /// `numWanted` is the num of desired.
    /// `useLimit` is the max numbers of each label that can be used.
    ///
    /// Ideas:
    /// Opt1: Setup queues by label and keep popping up the largest number.
    /// Opt2: Unify labels and values, and skip the label.
    ///
    /// * Cuz we only need to return the sum of numbers, thus it doesn't matter which label it is.
    /// </summary>
    /// <param name="values"></param>
    /// <param name="labels"></param>
    /// <param name="numWanted"></param>
    /// <param name="useLimit"></param>
    /// <returns></returns>
    public int LargestValsFromLabels(int[] values, int[] labels, int numWanted, int useLimit)
    {
        var list = new List<LabelValue>();
        foreach (var value in values)
        {
            list.Add(new LabelValue
            {
                
            });
        }
        
        return 0;
    }

    private class LabelValue
    {
        public int Label { get; set; }
        public int Value { get; set; }
    }
}