<Query Kind="Program" />

/* Problem: Max Depth of Binary Tree

Given a binary tree, find its maximum depth.

The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

*/
void Main()
{
	Tree tree = new Tree(1,
			new Tree(4, 
					new Tree(3),
					new Tree(5)),
			new Tree(7));
			
	Console.WriteLine("Max depth: {0}", TreeUtils.FindMaxDepth(tree));
}


public class TreeUtils
{
	public static int FindMaxDepth(Tree node)
	{
		return FindMaxDepthOfTree(node);
	}
	
	private static int FindMaxDepthOfTree(Tree node)
	{
		if(node == null)
		{
			return 0;
		}
		
		return 1 + Math.Max(FindMaxDepthOfTree(node.Left), FindMaxDepthOfTree(node.Right));
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
