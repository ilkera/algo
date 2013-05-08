<Query Kind="Program" />

/* Problem: Same Tree

Given two binary trees, write a function to check if they are equal or not.

Two binary trees are considered equal if they are structurally identical and the nodes have the same value.

*/

void Main()
{
	Tree first = new Tree(5, 
					new Tree(6,
						new Tree(11, null, null),
						new Tree(12, null, null)),
					new Tree(8,
						new Tree(3, null, null),
						new Tree(9, null, null)));
						
	Tree second = new Tree(5, 
					new Tree(6,
						new Tree(11, null, null),
						new Tree(12, null, null)),
					new Tree(8,
						new Tree(3, null, null),
						new Tree(9, null, null)));
						
	Tree third = new Tree(5, 
					new Tree(6,
						new Tree(11, null, null),
						new Tree(12, null, null)),
					new Tree(8,
						new Tree(3, null, null),
						new Tree(14, null, null)));
						
	Console.WriteLine("First and Second Same : {0}", TreeUtils.IsSameTree(first, second));
	Console.WriteLine("First and Third Same : {0}", TreeUtils.IsSameTree(first, third));
}

public class TreeUtils
{
	public static bool IsSameTree(Tree first, Tree second)
	{	
		if(first == null || second == null)
		{
			return first == second;
		}
		
		if(first.Value != second.Value)
		{
			return false;
		}
		
		return IsSameTree(first.Left, second.Left) && IsSameTree(first.Right, second.Right);
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
