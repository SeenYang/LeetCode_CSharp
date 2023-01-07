namespace LeetCode.CSharp;

public class BestTimeToBuyAndSellStockII
{
    public void Test()
    {
        var input = new int[] {7, 1, 5, 3, 6, 4};
        Console.WriteLine($"(method 1) Max profit of input prices is: {MaxProfit(input)}");
        Console.WriteLine($"(method 2) Max profit of input prices is: {MaxProfit2(input)}");
    }

    // in short, total potential max profit = Sum(Peaks) - Sum(Valleys)
    public int MaxProfit(int[] prices)
    {
        // Solution 1.
        int i = 0, valley = prices[0], peak = prices[0], maxProfit = 0;

        while (i < prices.Length - 1)
        {
            // declining
            while (i < prices.Length - 1 && prices[i] >= prices[i + 1])
                i++;
            valley = prices[i];
            // increasing
            while (i < prices.Length - 1 && prices[i] <= prices[i + 1])
                i++;
            peak = prices[i];
            maxProfit += peak - valley;
        }

        return maxProfit;
    }

    // Further more, we could just sum each diff between every `valley -> peak`.
    public int MaxProfit2(int[] prices)
    {
        var maxProfit = 0;
        for (var i = 1; i < prices.Length; i++)
            if (prices[i] > prices[i - 1])
                maxProfit += prices[i] - prices[i - 1];

        return maxProfit;
    }
}