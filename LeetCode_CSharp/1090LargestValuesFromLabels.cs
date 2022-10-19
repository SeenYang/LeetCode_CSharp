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
        LabelValue[] elements = new LabelValue[values.Length];
        for (int i = 0; i < values.Length; i++) elements[i] = new LabelValue { Value = values[i], Label = labels[i] };
        
        elements = elements.OrderByDescending(x => x.Value).ToArray();
        
        Dictionary<int, int> d = new Dictionary<int, int>();
        int sum = 0, used = 0;
        for (int i = 0; used < numWanted && i < elements.Length; i++) {
            d.TryGetValue(elements[i].Label, out int usedLabelElements);
            if (usedLabelElements < useLimit) {
                sum += elements[i].Value;
                used++;
                d[elements[i].Label] = usedLabelElements + 1;
            }
        }
        
        return sum;
    }

    private class LabelValue
    {
        public int Label { get; set; }
        public int Value { get; set; }
    }
}