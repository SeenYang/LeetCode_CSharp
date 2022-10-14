namespace LeetCode.CSharp;

public class ReverseWordsInAStringIII
{
    public void Test()
    {
        var s = "Let's take LeetCode contest";
        Console.WriteLine($"Result is {ReverseWords(s)}.");
    }

    public string ReverseWords(string s)
    {
        var words = s.Split(" ").ToList();

        var res = ReverseWordsHelper(words);
        return string.Join(" ", res);
    }

    private static IEnumerable<string> ReverseWordsHelper(List<string> words)
    {
        for (var index = 0; index < words.Count; index++)
            words[index] = string.Join("", words[index].ToCharArray().Reverse());

        return words;
    }
}