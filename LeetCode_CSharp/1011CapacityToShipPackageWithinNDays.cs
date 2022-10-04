namespace LeetCode.CSharp;

public class CapacityToShipPackageWithinNDays
{
    private void Test()
    {
        var weights = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        var days = 5;
        Console.WriteLine(
            $"Above weights need to be shipped in {days} days with capacity {ShipWithinDays(weights, days)}");
    }


    /// <summary>
    /// Given list of package weights weights[], and deadline days,
    /// we need to return `minimum` capacity of the conveyor that can ship all packages.
    ///
    /// The minimum capacity is the Max weight.
    /// The maximum capacity is the sum of weights.
    /// --> We just need to find out the minimum capacity that can ship all the packages.
    ///
    /// --> that's binary search problem to find the minimum number now.
    /// start:
    /// * mid = (left + right) /2
    /// * need = needed days to ship == 1
    /// * cur = current cargo in the ship == 0.
    ///
    /// start putting packages to the ship.
    /// if need > days, means the `mid` is too small --> left = mid.
    /// if need <= days, then we might have chance to shorten the `need` --> right = mid.
    /// if left == right --> that's the minimum.
    /// 
    /// </summary>
    /// <param name="weights"></param>
    /// <param name="days"></param>
    public int ShipWithinDays(int[] weights, int days)
    {
        int left = 0, right = 0;
        foreach (var w in weights)
        {
            left = Math.Max(left, w);
            right += w;
        }

        while (left < right)
        {
            int mid = (left + right) / 2, need = 1, cur = 0;
            foreach (var w in weights)
            {
                // can do check whether there's left in weights but need already >= days as break condition.
                if (cur + w > mid)
                {
                    need += 1;
                    cur = 0;
                }

                cur += w;
            }

            if (need > days)
                left = mid + 1;
            else
                right = mid;
        }

        return left;
    }
}