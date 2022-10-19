namespace LeetCode.CSharp;

public class LargestOddNumberInString
{
    public void Test()
    {
        Console.WriteLine($"Largest Odd Number is: {LargestOddNumber("52")}");
        Console.WriteLine($"Largest Odd Number is: {LargestOddNumber("7542351161")}");
        Console.WriteLine($"Largest Odd Number is: {LargestOddNumber("35427")}");
    }

    string LargestOddNumber(string num)
    {
        var chrArr = num.ToArray();
        for (var i = chrArr.Length - 1; i >= 0; i--)
        {
            if (int.Parse(chrArr[i].ToString()) % 2 != 1) continue;
            var seg = new ArraySegment<char>(chrArr, 0, i + 1);
            return new string(seg);
        }

        return "";
    }
}