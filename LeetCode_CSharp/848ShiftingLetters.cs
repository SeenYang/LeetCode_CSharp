namespace LeetCode.CSharp;

public class ShiftingLettersTest
{
    public void Test()
    {
        // var input = new[] { 3, 5, 9 };
        var input = new[]
        {
            505870226, 437526072, 266740649, 224336793, 532917782, 311122363, 567754492, 595798950, 81520022, 684110326,
            137742843, 275267355, 856903962, 148291585, 919054234, 467541837, 622939912, 116899933, 983296461, 536563513
        };
        var src = "mkgfzkkuxownxvfvxasy";

        Console.WriteLine($"Result is {ShiftingLetters(src, input)}");
    }

    public string ShiftingLetters(string s, int[] shifts)
    {
        if (shifts.Length == 0)
            return s;
        // Shifts might excess the int range.
        shifts = shifts.Select(i => i % 26).ToArray();
        var newShifts = ShiftsHelper(shifts);
        
        var chrArr = s.ToCharArray();

        for (int i = 0; i < chrArr.Length; i++)
        {
            chrArr[i] = (char)(((chrArr[i] + newShifts[i] - 'a') % 26) + 'a');
        }

        return string.Join("", chrArr);
    }

    private int[] ShiftsHelper(int[] shifts)
    {
        var len = shifts.Length;
        var res = new int[len];
        
        var sum = 0;
        for (int i = len - 1, j = 0; i >= 0; i--, j++)
        {
            res[i] = (char)(shifts[i] + sum);
            sum += shifts[i];
        }

        return res;
    }

    #region timeout solution

    // public string ShiftingLetters(string s, int[] shifts)
    // {
    //     if (shifts.Length == 0)
    //         return s;
    //     var chrArr = s.ToCharArray();
    //     for (int i = 0; i < shifts.Length; i++)
    //     {
    //         chrArr = ShiftHelper(chrArr, shifts[i], i);
    //     }
    //
    //     return string.Join("", chrArr);
    // }
    //
    // private char[] ShiftHelper(char[] chrArr, int shift, int currentTail)
    // {
    //     // If shifting is 0, or shift % 26 == 0, return origin.
    //     shift %= 26;
    //     if (shift == 0)
    //         return chrArr;
    //
    //     for (int i = 0; i <= currentTail; i++)
    //     {
    //         Console.WriteLine($"Current is {chrArr[i]}, Shift {shift}.");
    //         // Shift the array
    //
    //         chrArr[i] = (chrArr[i] + shift) switch
    //         {
    //             > 'z' => (char)('a' + chrArr[i] + shift - 'z' - 1),
    //             < 'a' => (char)('z' - ('a' - (chrArr[i] + shift))),
    //             _ => (char)(chrArr[i] + shift)
    //         };
    //
    //         Console.WriteLine($"After shifted is {chrArr[i]}.");
    //     }
    //
    //     return chrArr;
    // }

    #endregion
}