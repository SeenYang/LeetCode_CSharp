namespace LeetCode.CSharp;

public class PalindromeLinkedList
{
    public void Test()
    {
        var node3 = new ListNode(3, null);
        var node2 = new ListNode(2, node3);
        var node1 = new ListNode(2, node2);
        var node = new ListNode(1, node1);

        Console.WriteLine($"Is it Palindrome? : {IsPalindrome(node)}");
    }

    public bool IsPalindrome(ListNode head)
    {
        var stack = new Stack<int>();
        var temp = head;
        while (true)
        {
            stack.Push(temp.val);
            if (temp.next == null) break;
            temp = temp.next;
        }

        var count = stack.Count / 2;
        while (count >= 0)
        {
            if (head.val != stack.Pop()) return false;
            head = head.next;
            count--;
        }

        return true;
    }
}