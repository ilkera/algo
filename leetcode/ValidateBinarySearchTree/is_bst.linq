<Query Kind="Program" />

/* Problem: Validate Binary Search Tree

Given a binary tree, determine if it is a valid binary search tree (BST).

Assume a BST is defined as follows:

The left subtree of a node contains only nodes with keys less than the node's key.
The right subtree of a node contains only nodes with keys greater than the node's key.
Both the left and right subtrees must also be binary search trees.

*/

void Main()
{
	Tree valid = new Tree(5, 
					new Tree(3,
						new Tree(2, null, null),
						new Tree(4, null, null)),
					new Tree(9,
						new Tree(7, null, null),
						new Tree(11, null, null)));
						
	Tree invalid = new Tree(5, 
					new Tree(6,
						new Tree(11, null, null),
						new Tree(12, null, null)),
					new Tree(8,
						new Tree(3, null, null),
						new Tree(9, null, null)));
						
	Tree invalid2 = new Tree(5, 
					new Tree(3,
						new Tree(2, null, null),
						new Tree(4, null, null)),
					new Tree(9,
						new Tree(7, null, null),
						new Tree(8, null, null)));
	
	Console.WriteLine(TreeUtils.IsBST(valid));
	Console.WriteLine(TreeUtils.IsBST(invalid));
	Console.WriteLine(TreeUtils.IsBST(invalid2));
	
}

public class TreeUtils
{
	public static bool IsBST(Tree tree)
	{
		if(tree == null)
		{
			return true;
		}
		
		return IsBST(tree, int.MinValue, int.MaxValue);
	}
	
	public static bool IsBST(Tree tree, int minValue, int maxValue)
	{
		if(tree == null)
		{
			return true;
		}
		
		if(tree.Value < minValue || tree.Value > maxValue)
		{
			return false;
		}
		
		return IsBST(tree.Left, minValue, tree.Value) && IsBST(tree.Right, tree.Value, maxValue);
	}
}

public class Tree
{
	public Tree(int nodeValue, Tree left = null, Tree right = null)
	{
		this.Value = nodeValue;
		this.Left = left;
		this.Right = right;
	}
	
	public Tree Left { get; set; }
	public Tree Right { get; set; }
	public int Value { get; set; }
}


// Define other methods and classes here
