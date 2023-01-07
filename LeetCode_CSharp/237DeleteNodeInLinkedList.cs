namespace LeetCode.CSharp;

public class DeleteNodeInLinkedList
{
    public void Test()
    {
        var node3 = new ListNode(9)
        {
            next = null
        };
        var node2 = new ListNode(1)
        {
            next = node3
        };
        var node1 = new ListNode(5)
        {
            next = node2
        };
        var node0 = new ListNode(4)
        {
            next = node1
        };

        DeleteNode(node1);

        var temp = node0;
        do
        {
            Console.WriteLine(temp.val);
            temp = temp.next;
        } while (temp != null);
    }

    public void DeleteNode(ListNode node)
    {
        // Since we know input node is not last node, so nextNode will not be null
        ListNode nextNode = node.next;
        // Step 2
        node.val = nextNode.val;
        // Step 3
        node.next = nextNode.next;
        nextNode.next = null;
    }
}