<Query Kind="Program" />

/* Problem: Symetric Tree

Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).

For example, this binary tree is symmetric:

    1
   / \
  2   2
 / \ / \
3  4 4  3
But the following is not:

    1
   / \
  2   2
   \   \
   3    3
Note:
Bonus points if you could solve it both recursively and iteratively.

*/

void Main()
{
	Tree validTree = new Tree(1,
						new Tree(2, 
							new Tree(3),
							new Tree(4)),
						new Tree(2,
							new Tree(4),
							new Tree(3)));
							
	Console.WriteLine("Valid? : {0}", TreeUtils.IsSymetric(validTree));
	
	Tree invalidTree = new Tree(1,
							new Tree(2, null, new Tree(3)),
							new Tree(2, null, new Tree(3)));
							
	Console.WriteLine("Valid? : {0}", TreeUtils.IsSymetric(invalidTree));
						
}

public class TreeUtils
{
	public static bool IsSymetric(Tree tree)
	{
		if (tree == null)
		{
			return true;
		}
		
		return IsSymetricTree(tree.Left, tree.Right);
	}
	
	private static bool IsSymetricTree(Tree first, Tree second)
	{		
		if(first == null || second == null)
		{
			return first == second;
		}
		
		if(first.Value == second.Value)
		{
			return IsSymetricTree(first.Left, second.Right) && IsSymetricTree(first.Right, second.Left);
		}
		
		return false;
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
