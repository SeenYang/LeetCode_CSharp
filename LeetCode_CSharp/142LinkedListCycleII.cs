namespace LeetCode.CSharp;

// Detail explanation can be found here: https://blog.csdn.net/Julse/article/details/118809257
public class LinkedListCycleII {
    public void Test()
    {
        var node3 = new ListNode(-4);
        var node2 = new ListNode(0, node3);
        var node1 = new ListNode(2, node2);
        var node0 = new ListNode(3,node1);
        // entry is 1.
        node3.next = node1;
        
        Console.WriteLine($"Entry is node with value: {DetectCycle(node0).val}.");
    }
    
    
    /// <summary>
    /// From head to entry is O -> A, length is S.
    /// From entry to point two pointers meet is A -> M, length is L.
    /// Length of the ring is P.
    /// Thus:
    /// When we found out the meeting point, M, we can conclude this:
    /// S1 = T * 1 = S + L.
    /// S2 = T * 2 = S + L + P.
    /// ==> 
    /// T = P = S + L.
    /// ==> S = P - L.
    /// Which means, from meeting point clockwise to entry always equals to the length from head to entry.
    /// M -> A == O -> A.
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public ListNode DetectCycle(ListNode head)
    {
        if (head == null) return head;
        ListNode slow = head, fast = head.next, temp = head;
        while (slow.next != null &&  fast.next?.next != null)
        {
            Console.WriteLine($"slow {slow.val}, fast {fast.val}, temp {temp.val}");
            if (slow.val == fast.val)
            {
                while (temp != slow.next)
                {
                    temp = temp.next;
                    slow = slow.next;
                }

                return slow.next;
            }

            slow = slow.next;
            fast = fast.next.next;
        }

        return null;
    }
}