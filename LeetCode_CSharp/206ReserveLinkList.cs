namespace LeetCode.CSharp;

public class ReserveLinkList
{
    public void Test()
    {
        var node5 = new ListNode(5, null);
        var node4 = new ListNode(4, node5);
        var node3 = new ListNode(3, node4);
        var node2 = new ListNode(2, node3);
        var node1 = new ListNode(1, node2);
        var res = ReverseList(node1);
        Console.WriteLine("Result:");
        while (res.next != null)
        {
            Console.WriteLine(res.val);
            res = res.next;
        }
        Console.WriteLine(res.val);
    }

    public ListNode? ReverseList(ListNode? head)
    {
        // Base Case
        if (head == null || head.next == null)
            return head;
        
        // Find the new head.
        var res = head;
        while (res.next != null)
            res = res.next;
        
        reverse(head, head.next);
        
        return res;
    }

    /// <summary>
    /// input: [1,2] from [1,2,3,4]
    /// 1. [2, 1, 3, 4] --> [2, 3]
    /// 2. [3, 2, 1, 4] --> [3, 4]
    /// 3. [4, 3, 2, 1] --> [4, null]
    /// </summary>
    /// <param name="node1"></param>
    /// <param name="node2"></param>
    /// <returns></returns>
    private void reverse(ListNode? node1, ListNode? node2)
    {
        if (node2.next != null)
        {
            reverse(node2, node2.next);
        }
        
        node1.next = node2.next;
        node2.next = node1;
    }
}