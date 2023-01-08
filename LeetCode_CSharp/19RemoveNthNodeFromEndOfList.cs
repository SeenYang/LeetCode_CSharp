using System.Data;

namespace LeetCode.CSharp;

public class RemoveNthNodeFromEndOfList
{
    // input = [1,2,3,4,5] n = 2;
    // Expect to remove the `4` and return [1,2,3,5].
    public void Test()
    {
        // var node4 = new ListNode(5, null);
        // var node3 = new ListNode(4, node4);
        // var node2 = new ListNode(3, node3);
        // var node1 = new ListNode(2, node2);
        // var node = new ListNode(1, node1);
        // var n = 2;

        // var node = new ListNode(1, null);
        // var n = 1;        

        // var node2 = new ListNode(3, null);
        var node1 = new ListNode(2, null);
        var node = new ListNode(1, node1);
        var n = 1;

        var temp = RemoveNthFromEnd(node, n);
        while (true)
        {
            Console.WriteLine(temp.val);
            if (temp.next == null) break;
            temp = temp.next;
        }
    }

    // General idea is reverse the linked list, and remove it, then reverse it back.
    // However, we could do a sliding winder pattern to just go through the linked list once. It's a O(n) solution.
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        // Boundary Cases.
        if (head == null)
            return head;
        
        // Base Case.
        // We need to wire up the previous node to the target's next, thus need extra space for the window.
        var size = n;
        var hp = head;
        var tp = head;
        for (int i = 0; i < size; i++)
        {
            tp = tp.next;
        }

        if (tp == null) return head.next;
        while (tp.next != null)
        {
            hp = hp.next;
            tp = tp.next;
        }

        hp.next = hp.next.next;
        return head;
    }
}