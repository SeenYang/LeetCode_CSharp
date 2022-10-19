namespace LeetCode.CSharp;

//https://leetcode.com/problems/implement-queue-using-stacks/
public class ImplementQueueUsingStacks232
{
    void Test()
    {
        Console.WriteLine("232 Implement Queue Using Stacks");
    
        var queue = new MyQueue();
        queue.Push(1);
        queue.Push(2);
        Console.WriteLine($"peek: {queue.Peek()}"); // 1
        Console.WriteLine($"pop: {queue.Pop()}");   // 1
        Console.WriteLine($"empty: {queue.Empty()}");   // false
    }
    
    class MyQueue
    {
        private readonly Stack<int> _stack;
    
        public MyQueue()
        {
            _stack = new Stack<int>();
        }
    
        public void Push(int x)
        {
            var tempStack = new Stack<int>();
            while (_stack.TryPop(out var num))
            {
                tempStack.Push(num);
            }
    
            _stack.Push(x);
    
            while (tempStack.TryPop(out var num))
            {
                _stack.Push(num);
            }
        }
    
    
        // return the first object within the queue.
        public int Pop()
        {
            _stack.TryPop(out var result);
            return result;
        }
    
        public int Peek()
        {
            _stack.TryPeek(out var result);
            return result;
        }
    
        public bool Empty()
        {
            return !_stack.TryPeek(out _);
        }
    }
}