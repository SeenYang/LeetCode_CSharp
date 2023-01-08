namespace LeetCode.CSharp;

public class MergeTwoSortedLists
{
    public void Test()
    {
        var node3 = new ListNode(4, null);
        var node2 = new ListNode(2, node3);
        var node1 = new ListNode(1, node2);

        var node13 = new ListNode(4, null);
        var node12 = new ListNode(3, node13);
        var node11 = new ListNode(1, node12);

        var result = MergeTwoLists(node1, node11);
    }

    private ListNode _res;

    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        var dummyHead = new ListNode();
        var dummyTail = dummyHead;
        while (list1 != null && list2 != null)
        {
            if (list1.val <= list2.val)
            {
                dummyTail.next = list1;
                list1 = list1.next;
                dummyTail = dummyTail.next;
            }
            else
            {
                dummyTail.next = list2;
                list2 = list2.next;
                dummyTail = dummyTail.next;
            }
        }

        dummyTail.next = (list1 != null) ? list1 : list2;
        return dummyHead.next;
    }
}