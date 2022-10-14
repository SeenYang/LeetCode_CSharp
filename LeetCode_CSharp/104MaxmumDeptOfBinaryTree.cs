using ConsoleApp1.Common;

namespace LeetCode.CSharp;

public class MaximumDeptOfBinaryTree {
    public void Test()
    {
        var node1 = new TreeNode(15, null, null);
        var node2 = new TreeNode(7, null, null);
        var node3 = new TreeNode(20, node1, node2);
        var node4 = new TreeNode(9, null, null);
        var root = new TreeNode(3, node4, node3);
        Console.WriteLine($"Max dept of this tree is {MaxDepth(root)}");
    }
    
    public int MaxDepth(TreeNode root) {
        if (root == null)
            return 0;   // invalid case.

        if (root.left == null & root.right == null)
            return 1;   // this is leaf.

        return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
    }
}