<Query Kind="Program" />

void Main()
{
	
	Tree tree = new Tree(0);
	Tree one = new Tree(1);
	Tree two = new Tree(2);
	Tree three = new Tree(3);
	Tree four = new Tree(4);
	Tree five = new Tree(5);
	Tree six = 	new Tree(6);
	Tree seven = new Tree(7);
	Tree eight = new Tree(8);
	Tree nine = new Tree(9);
	Tree ten = new Tree(10);
	
	tree.Left = one;
	tree.Right = two;
	tree.Parent = null;
	
	one.Left = three;
	one.Right = four;
	one.Parent = tree;
	
	two.Left = five;
	two.Right = six;
	two.Parent = tree;
	
	three.Left = seven;
	three.Right = nine;
	three.Parent = one;
	
	four.Parent = one;
	
	five.Right = eight;
	five.Parent = two;
	
	six.Parent = two;
	seven.Parent = three;
	eight.Parent = five;
	
	nine.Left = ten;
	nine.Parent = three;
	ten.Parent = nine;
	
	Console.WriteLine("LCA v1 of {0} and {1} is {2}", 2, 5, TreeUtils.FindLCA_v1(tree, 2, 5).Value);

	Console.WriteLine("LCA v1 of {0} and {1} is {2}", 6, 4, TreeUtils.FindLCA_v1(tree, 6, 4).Value);
	
	Console.WriteLine("LCA v1 of {0} and {1} is {2}", 10, 8, TreeUtils.FindLCA_v1(tree, 10, 8).Value);
	
	// Version 2
	Console.WriteLine("LCA v2 of {0} and {1} is {2}", five.Value, four.Value, TreeUtils.FindLCA_v2(tree, five, four).Value);
	Console.WriteLine("LCA v2 of {0} and {1} is {2}", eight.Value, three.Value, TreeUtils.FindLCA_v2(tree, eight, three).Value);
	Console.WriteLine("LCA v2 of {0} and {1} is {2}", seven.Value, three.Value, TreeUtils.FindLCA_v2(tree, seven, three).Value);
	Console.WriteLine("LCA v2 of {0} and {1} is {2}", seven.Value, ten.Value, TreeUtils.FindLCA_v2(tree, seven, ten).Value);
	Console.WriteLine("LCA v2 of {0} and {1} is {2}", two.Value, five.Value, TreeUtils.FindLCA_v2(tree, two, five).Value);
	
}

// Define other methods and classes here

public class TreeUtils
{
	// This one will fail because what if first present, and second does not present in the tree.
	public static Tree FindLCA_v1(Tree root, int first, int second)
	{
		if (root == null)
		{
			return null;
		}
		
		if(root.Value == first || root.Value == second)
		{
			return root;
		}
		else
		{
			Tree left = FindLCA_v1(root.Left, first, second);
			Tree right = FindLCA_v1(root.Right, first, second);
			
			if(left != null && right != null)
			{
				return root;
			}
			else if (left != null)
			{
				return left;
			}
			else
			{
				return right;
			}
		}	
	}
	
	public static Tree FindLCA_v2(Tree root, Tree firstNode, Tree secondNode)
	{
		if (root == null)
		{	
			return null;
		}
		
		int depthFirst = TreeUtils.FindDepth(root, firstNode);
		int depthSecond = TreeUtils.FindDepth(root, secondNode);
		
		Tree firstIterator = firstNode;
		Tree secondIterator = secondNode;
		
		while (depthFirst != depthSecond)
		{
			if (depthFirst > depthSecond)
			{
				firstIterator = firstIterator.Parent;
				depthFirst--;
			}
			else
			{
				secondIterator = secondIterator.Parent;
				depthSecond--;
			}
		}
		
		while (firstIterator != secondIterator)
		{
			firstIterator = firstIterator.Parent;
			secondIterator = secondIterator.Parent;
		}
		
		return firstIterator;
	}
	
	public static int FindDepth(Tree root, Tree node)
	{
		int depth = 0;
		Tree current = node;
		
		while (root != current)
		{
			depth++;
			current = current.Parent;
		}
		return depth;
	}
}
	

public class Tree
{
	public Tree(int value, Tree left = null, Tree right = null, Tree parent = null)
	{
		this.Value = value;
		this.Left = left;
		this.Right = right;
		this.Parent = parent;
	}
	
	public int Value { get; set; }
	public Tree Left { get; set; }
	public Tree Right { get; set; }
	public Tree Parent { get; set; }
}
