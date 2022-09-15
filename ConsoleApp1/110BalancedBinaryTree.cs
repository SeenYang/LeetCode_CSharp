namespace ConsoleApp1;

public class BalancedBinaryTree
{
    void Test()
    {
        var node41 = new TreeNode { val = 4, left = null, right = null };
        var node42 = new TreeNode { val = 4, left = null, right = null };
        var node31 = new TreeNode { val = 3, left = node41, right = node42 };
        var node32 = new TreeNode { val = 3, left = null, right = null };
        var node21 = new TreeNode { val = 2, left = node31, right = node32 };
        var node22 = new TreeNode { val = 2, left = null, right = null };
        var node1 = new TreeNode { val = 1, left = node21, right = node22 };
// case 2
        var node2_21 = new TreeNode { val = 2, left = null, right = null };

        var node2_11 = new TreeNode { val = 1, left = node2_21, right = null };

// case 3
        var node3_31 = new TreeNode { val = 3, left = null, right = null };
        var node3_21 = new TreeNode { val = 2, left = null, right = node3_31 };
        var node3_11 = new TreeNode { val = 1, left = null, right = node3_21 };
        Console.WriteLine($"is it balanced? {IsBalanced(node1)}");
        Console.WriteLine($"is it balanced? {IsBalanced(node2_11)}");
        Console.WriteLine($"is it balanced? {IsBalanced(node3_11)}");
    }

    #region bottom up

// For each node, it's the root of it's own sub-tree.
// Thus we can tell by whether the left is balanced.
    bool IsBalanced(TreeNode root)
    {
        if (root == null)
        {
            return true;
        }

        if (root.left == null && root.right == null)
            return true;

        return IsBalancedHelper(root).IsBalanced;
    }

    TreeInfo IsBalancedHelper(TreeNode root)
    {
        if (root == null)
        {
            return new TreeInfo(-1, true);
        }

        var leftInfo = IsBalancedHelper(root.left);
        if (!leftInfo.IsBalanced)
        {
            return new TreeInfo(-1, false);
        }

        var rightInfo = IsBalancedHelper(root.right);
        if (!rightInfo.IsBalanced)
        {
            return new TreeInfo(-1, false);
        }

        return Math.Abs(leftInfo.Height - rightInfo.Height) < 2
            ? new TreeInfo(Math.Max(leftInfo.Height, rightInfo.Height) + 1, true)
            : new TreeInfo(-1, false);
    }

    class TreeInfo
    {
        public int Height { get; set; }
        public bool IsBalanced { get; set; }

        public TreeInfo(int height, bool isBalanced)
        {
            Height = height;
            IsBalanced = isBalanced;
        }
    }

    #endregion

    #region Top-Down

// For each node, it's the root of it's own sub-tree.
// Thus we can tell by whether the left is balanced.
// static bool IsBalanced(TreeNode root)
// {
//     if (root == null)
//     {
//         return true;
//     }
//
//     if (root.left == null && root.right == null)
//         return true;
//
//     var leftDepth = GetDepth(root.left);
//     var rightDepth = GetDepth(root.right);
//     if (Math.Abs(leftDepth - rightDepth) > 1)
//     {
//         return false;
//     }
//
//     return IsBalanced(root.left) && IsBalanced(root.right);
// }
//
// static int GetDepth(TreeNode node)
// {
//     if (node == null)
//     {
//         return 0;
//     }
//
//     if (node.left == null && node.right == null)
//     {
//         return 1;
//     }
//
//     var leftDepth = node.left == null ? 0 : GetDepth(node.left);
//     var rightDept = node.right == null ? 0 : GetDepth(node.right);
//     return 1 + Math.Max(leftDepth, rightDept);
// }

    #endregion

    class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}