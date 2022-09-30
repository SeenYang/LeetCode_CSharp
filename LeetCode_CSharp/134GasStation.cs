using System.Windows.Markup;

namespace LeetCode.CSharp;

public class GasStation
{
    public void Test()
    {
        var gas = new[] { 1, 2, 3, 4, 5 };
        var cost = new[] { 3, 4, 5, 1, 2 };
        // var gas = new[] { 2, 3, 4 };
        // var cost = new[] { 3, 4, 3 };
        // var gas = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        // var cost = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };


        Console.WriteLine($"Result is {CanCompleteCircuit(gas, cost)}");
    }

    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        int currentTank = 0, totalConsum = 0, startStation = 0;
        for (int i = 0; i < gas.Length; i++)
        {
            totalConsum += gas[i] - cost[i];
            currentTank += gas[i] - cost[i];
            if (currentTank < 0)
            {
                // means we can't get to next station.
                startStation = i + 1;
                // reset the tank.
                currentTank = 0;
            }
        }

        return totalConsum >= 0 ? startStation : -1;
    }
}