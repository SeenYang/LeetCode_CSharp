using ConsoleApp1.Common;

namespace LeetCode.CSharp;

public class MinimumDepthOfBinaryTree
{
    public void Test()
    {
        var node31 = new TreeNode(15, null, null);
        var node32 = new TreeNode(7, null, null);
        var node21 = new TreeNode(9, null, null);
        var node22 = new TreeNode(20, node31, node32);
        var node11 = new TreeNode(3, node21, node22);
        Console.WriteLine($"Result is: {MinDepth(node11)}");
    }

    private int MinDepth(TreeNode root)
    {
        if (root == null)
            return 0;
        if (root.left == null && root.right == null)
            return 1;

        int min_depth = int.MaxValue;
        if (root.left != null)
            min_depth = Math.Min(MinDepth(root.left), min_depth);

        if (root.right != null)
            min_depth = Math.Min(MinDepth(root.right), min_depth);

        return min_depth + 1;
    }
}