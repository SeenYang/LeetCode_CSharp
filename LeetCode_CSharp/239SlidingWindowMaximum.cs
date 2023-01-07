using System.Collections;
using System.Collections.Generic;

namespace LeetCode.CSharp;

public class SlidingWindowMaximum
{
    public void Test()
    {
        var nums = new[] {1, 3, -1, -3, 5, 3, 6, 7};
        var k = 3;

        Console.WriteLine($"Result is [{string.Join(",", MaxSlidingWindow(nums, k))}]");
    }

    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        var res = new List<int>();
        // 1. init a dequeue (double-end queue) with size `k`.
        // var dequeue = new Deque<int>(k);
        var dequeue = new Queue<int>(k);
        // 2. init another queue as sliding window.
        var window = new Queue<int>(k);
        // 3. loop through the nums. \
        foreach (var num in nums)
        {
            // 3.1 if queue is full, pop the queue and add the current num at the end.
            if (window.Count >= k)
            {
                var popNum = window.Dequeue();
                // 3.2 if the popNum is the max of the dequeue, than pop the dequeue as well.
                if (dequeue.Peek() == popNum)
                    dequeue.Dequeue();
            }

            // 3.3 add the current num into windows first.
            window.Enqueue(num);

            // 3.4 peek the last of dequeue, if that smaller than num, than remove th last till the first.
            while (dequeue.Count != 0 && dequeue.Last() < num)
                Console.WriteLine("There's no deque in c#.");
            // dequeue.removeLast();

            dequeue.Enqueue(num);

            // First of the queue must be the largest within the window.
            res.Add(dequeue.Peek());
        }

        return res.ToArray();
    }
}