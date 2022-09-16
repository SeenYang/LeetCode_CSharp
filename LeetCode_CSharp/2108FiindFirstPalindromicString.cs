namespace LeetCode.CSharp;

public class FindFirstPalindromicString
{
    void test()
    {
        var words = new string[] { "abc", "car", "ada", "racecar", "cool" };
        var result = FirstPalindrome(words);
        Console.WriteLine($"result {result}");
    }

    string FirstPalindrome(string[] words)
    {
        foreach (var word in words)
        {
            var chrStack = StringToCharStack(word);
            var tempStack = new Stack<char>();

            var len = chrStack.Count / 2;
            for (int i = 0; i < len; i++)
            {
                tempStack.Push(chrStack.Pop());
            }

            if (word.Length % 2 == 1)
            {
                chrStack.Pop();
            }

            if (CompareStacks(chrStack, tempStack))
            {
                return word;
            }
        }

        return "";
    }

    Stack<char> StringToCharStack(string input)
    {
        var charArr = input.ToCharArray();
        var stack = new Stack<char>();
        foreach (var c in charArr)
        {
            stack.Push(c);
        }

        return stack;
    }

    bool CompareStacks(Stack<char> stack1, Stack<char> stack2)
    {
        if (stack1.Count != stack2.Count)
            return false;

        while (stack1.Count > 0)
        {
            if (stack1.Pop() != stack2.Pop())
                return false;
        }

        return true;
    }
}