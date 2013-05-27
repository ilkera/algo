<Query Kind="Program" />

/* Problem: Node Traversals (Iterative)

Given a binary tree, print the elements in post-order iteratively without using recursion.

*/
void Main()
{
	Node tree = new Node(10, 
					new Node(6, 
						new Node(4),
						new Node(8)),
					new Node(14,
						new Node(12),
						new Node(16)));
						
	TreeTraversals.PreOrder(tree);
	
	TreeTraversals.InOrder(tree);
	
	TreeTraversals.PostOrder_UsingTwoStacks(tree);
	
	TreeTraversals.PostOrder(tree);
}

public class TreeTraversals
{
	public static void PostOrder(Node node)
	{
		if (node == null)
		{
			return;
		}
		
		Stack<Node> nodes = new Stack<Node>();
		nodes.Push(node);
		Node previous = null;
		
		while (nodes.Count != 0)
		{
			Node current = nodes.Peek();
			
			if (previous == null || previous.Left == current || previous.Right == current)
			{
				if(current.Left != null)
				{
					nodes.Push(current.Left);
				}
				else if(current.Right != null)
				{
					nodes.Push(current.Right);
				}
			}
			else if (previous == current.Left)
			{
				if(current.Right != null)
				{
					nodes.Push(current.Right);
				}
			}
			else
			{
				Console.Write("{0} -", current.Value);
				nodes.Pop();
			}
			
			previous = current;
		}
		Console.WriteLine("");
		
	}
	public static void PostOrder_UsingTwoStacks(Node node)
	{
		if (node == null)
		{
			return;
		}
		
		Stack<Node> nodes = new Stack<Node>();
		Stack<Node> output = new Stack<Node>();
		nodes.Push(node);
		
		while(nodes.Count != 0)
		{
			Node current = nodes.Pop();
			output.Push(current);
			
			if(current.Left != null)
			{
				nodes.Push(current.Left);
			}
			
			if(current.Right != null)
			{
				nodes.Push(current.Right);
			}
		}
		
		while(output.Count != 0)
		{
			Node current = output.Pop();
			Console.Write("{0} - ", current.Value);
		}
		Console.WriteLine("");
	}
	
	public static void InOrder(Node node)
	{
		if (node == null)
		{
			return;
		}
		
		Stack<Node> nodes = new Stack<Node>();
		Node current = node;
		
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
	
	public static void PreOrder(Node node)
	{
		if (node == null)
		{
			return;
		}
		
		Stack<Node> nodes = new Stack<Node>();
		nodes.Push(node);
		
		while (nodes.Count != 0)
		{
			Node current = nodes.Pop();
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

public class Node
{
	public Node(int value, Node left = null, Node right = null)
	{
		this.Value = value;
		this.Left = left;
		this.Right = right;
	}
	public Node Left { get; set; }
	public Node Right { get; set; }
	public int Value { get; set; }
}

	

// Define other methods and classes here
