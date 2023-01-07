using ConsoleApp1.Common;

namespace LeetCode.CSharp;

public class LowestCommonAncestorOfABinarySearchTree
{
    public void Test()
    {
        var node41 = new TreeNode(3, null, null);
        var node42 = new TreeNode(5, null, null);
        var node31 = new TreeNode(0, null, null);
        var node32 = new TreeNode(4, node41, node42);
        var node33 = new TreeNode(7, null, null);
        var node34 = new TreeNode(9, null, null);
        var node21 = new TreeNode(2, node31, node32);
        var node22 = new TreeNode(8, node33, node34);
        var node11 = new TreeNode(6, node21, node22);
        Console.WriteLine($"Result is {LowestCommonAncestor(node11, node21, node22).val}.");
        Console.WriteLine($"Result is {LowestCommonAncestor(node11, node21, node32).val}.");
    }

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root.val > p.val && root.val > q.val)
        {
            return LowestCommonAncestor(root.left, p, q);
        }

        if (root.val < p.val && root.val < q.val)
            return LowestCommonAncestor(root.right, p, q);

        return root;
    }
}