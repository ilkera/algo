<Query Kind="Program" />

/* Problem: Flatten Binary Tree to Linked List 

Given a binary tree, flatten it to a linked list in-place.

For example,
Given

         1
        / \
       2   5
      / \   \
     3   4   6
The flattened tree should look like:
   1
    \
     2
      \
       3
        \
         4
          \
           5
            \
             6

*/
void Main()
{
	Tree tree = new Tree(1,
					new Tree(2,
						new Tree(3),
						new Tree(4)),
					new Tree(5,
						null,
						new Tree(6)));
						
//	TreeUtils.Flatten(tree);
	TreeUtils.FlattenRecursive(tree);
	
	tree.Dump();
						
}

public class TreeUtils
{
	public static void FlattenRecursive(Tree tree)
	{
		if (tree == null)
		{
			return;
		}
		
		Tree result = null;
		FlattenRecursive(tree, ref result);
	}
	
	private static void FlattenRecursive(Tree tree, ref Tree result)
	{
		if (tree == null)
		{
			return;
		}
		
		Tree left = tree.Left;
		tree.Left = null;
		
		Tree right = tree.Right;
		tree.Right = null;
		
		if (result == null)
		{
			result = tree;
		}
		else
		{
			result.Right = tree;
			result = result.Right;
		}
		
		FlattenRecursive(left, ref result);
		FlattenRecursive(right, ref result);
	}
	
	public static void Flatten(Tree tree)
	{
		if (tree == null)
		{
			return;
		}
		
		Tree result = null;
		Stack<Tree> stack = new Stack<Tree>();
		stack.Push(tree);
		
		while(stack.Count != 0)
		{
			Tree current = stack.Pop();
			
			if (current.Right != null)
			{
				stack.Push(current.Right);
				current.Right = null;
			}
			
			if(current.Left != null)
			{
				stack.Push(current.Left);
				current.Left = null;
			}
			
			if (result == null)
			{
				result = current;
			}
			else
			{
				result.Right = current;
				result = result.Right;
			}	
		}
	}
}


public class Tree
{
	public int Value { get; set; }
	public Tree Left { get; set; }
	public Tree Right { get; set; }
	
	public Tree(int value, Tree left = null, Tree right = null)
	{
		this.Value = value;
		this.Left = left;
		this.Right = right;
	}
}
// Define other methods and classes here
