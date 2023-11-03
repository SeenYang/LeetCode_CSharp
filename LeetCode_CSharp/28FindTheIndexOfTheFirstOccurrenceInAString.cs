namespace LeetCode.CSharp;

public class FindTheIndexOfTheFirstOccurrenceInAString
{
    public void Test()
    {
        var haystack = "mississippi";
        var needle = "issip";

        Console.WriteLine(
            $"The index of \"{needle}\" first occurrence in string \"{haystack}\" is {strStr(haystack, needle)}.");
    }

    public int strStr(String haystack, String needle)
    {
        String newString = needle + "$" + haystack;
        int[] z = ZAlog(newString);
        var tar = needle.Length;
        //System.out.println(Arrays.toString(z));
        for (int i = 0; i < z.Length; i++)
        {
            if (z[i] == tar)
            {
                return i - (tar + 1);
            }
        }

        return -1;
    }

    public static int[] ZAlog(String st)
    {
        int left = 0, right = 0;
        int[] arr = new int[st.Length];

        for (int k = 0; k < arr.Length; k++)
        {
            if (k > right)
            {
                left = k;
                right = k;

                while (right < arr.Length && st[right] == st[right - left])
                {
                    right++;
                }

                arr[k] = right - left;
                right--;
            }
            else
            {
                int k1 = k - left;
                if (arr[k1] < right - k + 1)
                {
                    arr[k] = arr[k1];
                }
                else
                {
                    left = k;
                    while (right < arr.Length && st[right] == st[right - left])
                    {
                        right++;
                    }

                    arr[k] = right - left;
                    right--;
                }
            }
        }

        return arr;
    }
}