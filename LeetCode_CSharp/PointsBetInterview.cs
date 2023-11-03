using System.Text;

namespace LeetCode.CSharp;

public class PointsBetInterview
{
    public void GivenValidItemsAndQuote()
    {
        Console.WriteLine("Given Valid Items and Quote.");
        var items = new[]
        {
            "one",
            "two",
            "three",
            "four",
        };
        var quote = "\"";
        Console.WriteLine($"Origin: {ToCommaSeperatedList(items, quote)}\n");
        Console.WriteLine($"Improved: {Improve(items, quote)}\n");
    }

    public void GivenEmptyItemListWithValidQuote()
    {
        var items = new List<string>().ToArray();
        var quote = "\"";
        // Original not handle this case.
        // Console.WriteLine($"Origin: {ToCommaSeperatedList(items, quote)}\n");
        Console.WriteLine($"Improved: {Improve(items, quote)}\n");
    }

    public void GivenEmptyQuoteWithValidItems()
    {
        Console.WriteLine("Given empty Items with valid Quote.");
        var items = new[]
        {
            "one",
            "two",
            "three",
            "four",
        };
        var quote = string.Empty;
        Console.WriteLine($"Origin: {ToCommaSeperatedList(items, quote)}\n");
        Console.WriteLine($"Improved: {Improve(items, quote)}\n");
    }

    public void GivenEmptyItemsAndEmptyQuote()
    {
        Console.WriteLine("Given empty items and empty quote.");
        var items = new List<string>().ToArray();
        var quote = string.Empty;
        // Original not handle this case.
        // Console.WriteLine($"Origin: {ToCommaSeperatedList(items, quote)}\n");
        Console.WriteLine($"Improved: {Improve(items, quote)}\n");
    }

    public void GivenAbnormalQuoteWithValidItems()
    {
        Console.WriteLine("Given abnormal Quote with valid Items");
        var items = new[]
        {
            "one",
            "two",
            "three",
            "four",
        };
        var quote = "'\"'";
        Console.WriteLine($"Origin: {ToCommaSeperatedList(items, quote)}\n");
        Console.WriteLine($"Improved: {Improve(items, quote)}\n");
    }

    //Code to improve
    public static string ToCommaSeperatedList(string[] items, string quote)
    {
        StringBuilder qry = new StringBuilder(string.Format("{0}{1}{0}", quote, items[0]));

        if (items.Length > 1)
        {
            for (int i = 1; i < items.Length; i++)
            {
                qry.Append(string.Format(", {0}{1}{0}", quote, items[i]));
            }
        }

        return qry.ToString();
    }

    /// <summary>
    /// Assumptions:
    /// 1. If no `items` provided, will return string.Empty.
    /// 2. `quote` is customisable char/string.
    /// </summary>
    /// <param name="items"></param>
    /// <param name="quote"></param>
    /// <returns></returns>
    public static string Improve(string[] items, string quote)
    {
        if (items.Length == 0) return string.Empty;

        var res = string.Join(", ", items.ToList().Select(i => $"{quote}{i}{quote}"));

        return res;
    }
}