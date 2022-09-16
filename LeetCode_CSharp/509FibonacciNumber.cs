namespace LeetCode.CSharp;

public class FibonacciNumber {
    int Fib(int n)
    {
        return n switch
        {
            <= 1 => n,
            _ => Fib(n - 1) + Fib(n - 2)
        };
    }
}