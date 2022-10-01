using ConsoleApp1.Common;

namespace LeetCode.CSharp;

public class NumberOfGoodLeaf
{
    private int _count;

    public NumberOfGoodLeaf()
    {
        _count = 0;
    }

    public void Test()
    {
        var node4 = new TreeNode(4, null, null);
        var node2 = new TreeNode(2, null, node4);
        var node3 = new TreeNode(3, null, null);
        var node1 = new TreeNode(1, node2, node3);

        Console.WriteLine($"Count pairs of good leaf for Node1 is {CountPairs(node1, 3)}.");
    }

    public int CountPairs(TreeNode root, int distance)
    {
        GetDistances(root, distance);
        return _count;
    }


    public List<int> GetDistances(TreeNode root, int disctance)
    {
        if (root == null)
            return new List<int>();

        // This is leaf node.
        // If this is leaf node, it's distance 1 to above root.
        if (root.left == null && root.right == null)
            return new List<int> {1};

        // below is getting distances from leaves to current node.
        var leftDisList = GetDistances(root.left, disctance);
        var rightDisList = GetDistances(root.right, disctance);
        // double for-loop will skip if any one leaf is null.
        // i.e. for [1,2,3], node [1] has two leaves. 
        // if distance target is 2, and two leaves distance = 1 + 1 <= 2,
        // there's pair of good leaves.
        foreach (var ld in leftDisList)
        {
            foreach (var rd in rightDisList)
            {
                if (ld + rd <= disctance)
                    _count++;
            }
        }

        // After that, we need to return the list of distances between all leaves of current node.
        // Return list is as leaf's value, we need to add 1 to all distances from current leaves.
        var resultList = new List<int>();
        resultList.AddRange(leftDisList.Select(d => d + 1));
        resultList.AddRange(rightDisList.Select(d => d + 1));
        return resultList;
    }
}