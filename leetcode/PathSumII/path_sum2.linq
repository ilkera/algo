<Query Kind="Program" />

/* Problem: Path Sum II

Given a binary tree and a sum, find all root-to-leaf paths where each path's sum equals the given sum.

For example:
Given the below binary tree and sum = 22,
              5
             / \
            4   8
           /   / \
          11  13  4
         /  \    / \
        7    2  5   1
return

[
   [5,4,11,2],
   [5,8,4,5]
]

*/
void Main()
{
		Tree tree = new Tree(1,
					new Tree(2,
						new Tree(9),
						new Tree(4)),
					new Tree(5,
						null,
						new Tree(6)));
						
		List<List<int>> paths = TreeUtils.GetPathSum(tree, 12);
		
		foreach (var path in paths)
		{
			path.Dump();
		}
}

public class TreeUtils
{
	public static List<List<int>> GetPathSum(Tree tree, int target)
	{
		List<List<int>> paths = new List<List<int>>();
		
		if (tree == null)
		{
			return paths;
		}
		
		List<int> currentPath = new List<int>();
		
		GetPathSum(tree, 0, target, currentPath, paths);
		
		return paths;
	}
	
	private static void GetPathSum(Tree tree, int currentSum, int target, List<int> currentPath, List<List<int>> paths)
	{
		if (tree == null || currentSum + tree.Value > target)
		{
			return;
		}
		
		currentSum += tree.Value;
		currentPath.Add(tree.Value);
		
		if (tree.Left == null && tree.Right == null)
		{
			if (currentSum == target)
			{
				paths.Add(new List<int>(currentPath));
				currentPath.Clear();
			}
			return;
		}
	
		List<int> leftPath = new List<int>(currentPath);
		List<int> rightPath = new List<int>(currentPath);
		
		GetPathSum(tree.Left, currentSum, target, leftPath, paths);
		GetPathSum(tree.Right, currentSum, target, rightPath, paths);
	}
}



public class Tree
{
	public Tree(int value, Tree left = null, Tree right = null)
	{
		this.Value = value;
		this.Left = left;
		this.Right = right;
	}
	
	public int Value { get; set; }
	public Tree Left { get; set; }
	public Tree Right { get; set; }
}


// Define other methods and classes here
