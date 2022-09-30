namespace LeetCode.CSharp;

public class ReverseStringII
{
    public void Test()
    {
        var s = "abcdefg";
        var k = 2;
        Console.WriteLine($"{ReverseStr(s, k)}");
    }

    public string ReverseStr(string s, int k)
    {
        // 1. convert string s to array chrArr.
        var chrArr = s.ToCharArray();
        var resArr = new List<char>();
        // 2. Basic cases:
        if (s.Length <= k)
        {
            resArr.AddRange(reverseCharArr(chrArr));
            return string.Join("", resArr);
        }

        for (int i = 0; i * k < chrArr.Length; i++)
        {
            switch (i % 2)
            {
                case 0: // reverse
                    var temp1 = reverseCharArr(chrArr.Skip(i * k).Take(k));
                    resArr.AddRange(temp1);
                    break;
                case 1: // skip reserve
                    var temp2 = chrArr.Skip(i * k).Take(k);
                    resArr.AddRange(temp2);
                    break;
            }
        }

        return string.Join("", resArr);
    }

    private IEnumerable<char> reverseCharArr(IEnumerable<char> chrArr)
    {
        var stack = new Stack<char>();
        foreach (var c in chrArr)
            stack.Push(c);
        var res = new List<char>();
        while (stack.TryPop(out var c))
        {
            res.Add(c);
        }

        return res;
    }
}