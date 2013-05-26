<Query Kind="Program" />

/* Problem: Tree Traversals (Iterative)

*/
void Main()
{
	Tree tree = new Tree(10, 
					new Tree(6, 
						new Tree(4),
						new Tree(8)),
					new Tree(14,
						new Tree(12),
						new Tree(16)));
						
	TreeTraversals.PreOrder(tree);
	
	TreeTraversals.InOrder(tree);
	

}

public class TreeTraversals
{
	public static void PostOrder(Tree node)
	{
		if (node == null)
		{
			return;
		}
		
		
	}
	
	public static void InOrder(Tree node)
	{
		if (node == null)
		{
			return;
		}
		
		Stack<Tree> nodes = new Stack<Tree>();
		Tree current = node;
		
		while(nodes.Count != 0 || current != null)
		{
			if(current != null)
			{
				nodes.Push(current);
				current = current.Left;
			}
			else
			{
				current = nodes.Pop();
				Console.Write("{0} -", current.Value);
				current = current.Right;
			}
		}
		Console.WriteLine("");
	}
	
	public static void PreOrder(Tree node)
	{
		if (node == null)
		{
			return;
		}
		
		Stack<Tree> nodes = new Stack<Tree>();
		nodes.Push(node);
		
		while (nodes.Count != 0)
		{
			Tree current = nodes.Pop();
			Console.Write("{0} -", current.Value);
			
			if(current.Right != null)
			{
				nodes.Push(current.Right);
			}
			
			if(current.Left != null)
			{
				nodes.Push(current.Left);
			}
		}
		Console.WriteLine("");
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
	public Tree Left { get; set; }
	public Tree Right { get; set; }
	public int Value { get; set; }
}

	

// Define other methods and classes here
