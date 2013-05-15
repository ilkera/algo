<Query Kind="Program" />

/* Problem : Tree Isomorphism Problem

Write a function to detect if two trees are isomorphic.
Two trees are called isomorphic if one of them can be obtained from other by a series of flips,
i.e. by swapping left and right children of a number of nodes. 

Any number of nodes at any level can have their children swapped. Two empty trees are isomorphic.

http://www.geeksforgeeks.org/tree-isomorphism-problem/

*/
void Main()
{
	Tree t1 = new Tree(1,
				new Tree(2,
					new Tree(4),
					new Tree(5,
						new Tree(7),
						new Tree(8))),
				new Tree(3,
					new Tree(6)));
					
	Tree t2 = new Tree(1,
				new Tree(3, null, new Tree(6)),
				new Tree(2, 
					new Tree(4),
					new Tree(5, 
						new Tree(8),
						new Tree(7))));
						
	Console.WriteLine(TreeUtils.IsIsomorphic(t1, t2));
					
		
}

public class TreeUtils
{
	public static bool IsIsomorphic(Tree t1, Tree t2)
	{
		if(t1 == null || t2 == null)
		{
			return t1 == t2;
		}
		
		if (t1.Value != t2.Value)
		{
			return false;
		}
		
		return (IsIsomorphic(t1.Left, t2.Left) && IsIsomorphic(t1.Right, t2.Right)) ||
		(IsIsomorphic(t1.Left, t2.Right) && IsIsomorphic(t1.Right, t2.Left));
		
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
