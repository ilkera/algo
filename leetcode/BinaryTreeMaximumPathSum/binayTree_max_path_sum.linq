<Query Kind="Program" />

/* Problem : Binary Tree Max Path Sum

Given a binary tree, find the maximum path sum.

The path may start and end at any node in the tree.

For example:
Given the below binary tree,

       1
      / \
     2   3
Return 6.

		1
	2		5
			
3 	-4 		7  -6

*/
void Main()
{
	Tree tree = new Tree(1,
					new Tree(2,
						new Tree(3),
						new Tree(-4)),
					new Tree(5,
						new Tree(7),
						new Tree(-6)));
						
	int maxSum = TreeUtils.FindMaxPathSum(tree);
	
	maxSum.Dump();
}

public class TreeUtils
{
	public static int FindMaxPathSum(Tree tree)
	{
		if(tree == null)
		{
			return 0;
		}
		
		int maxSoFar = 0;
		FindMaxPathSum(tree, ref maxSoFar);
		
		return maxSoFar;
	}
	
	public static int FindMaxPathSum(Tree tree, ref int maxSoFar)
	{
		if(tree == null)
		{
			return 0;
		}
		
		int leftSum = FindMaxPathSum(tree.Left, ref maxSoFar);
		int rightSum = FindMaxPathSum(tree.Right, ref maxSoFar);
		
		int maxPath = tree.Value;
		
		if(leftSum > 0)
		{
			maxPath +=leftSum;
		}
		
		if(rightSum > 0)
		{
			maxPath +=rightSum;
		}
		
		maxSoFar = Math.Max(maxPath, maxSoFar);
		
		return Math.Max(tree.Value, tree.Value + Math.Max(leftSum, rightSum));
		
	}
}

public class Tree
{
	public Tree Left { get; set; }
	public Tree Right { get; set; }
	public int Value { get; set; }
	
	public Tree(int value, Tree left = null, Tree right = null)
	{
		this.Value = value;
		this.Left = left;
		this.Right = right;
	}
}

// Define other methods and classes here
