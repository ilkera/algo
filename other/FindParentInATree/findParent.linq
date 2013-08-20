<Query Kind="Program" />

void Main(string[] args)
{
}

public class TreeUtils
{
	public static Tree FindParentInBST(Tree root, Tree targetNode)
	{
		if (targetNode == root)
		{
			return null;
		}
		
		return FindParentInBSTHelper(root, null, targetNode);
	}
	
	public static Tree FindParent(Tree root, Tree targetNode)
	{
		if (targetNode == root)	
		{
			return null;
		}
		
		return FindParentHelper(root, null, targetNode);
	}
	
	private static Tree FindParentInBSTHelper(Tree currentNode, Tree currentParent, Tree targetNode)
	{
		if (currentNode == targetNode)
		{
			return currentParent;
		}
		
		if (currentNode.Value < targetNode.Value)
		{
			return FindParentInBSTHelper(currentNode.Right, currentNode, targetNode);
		}
		else
		{
			return FindParentInBSTHelper(currentNode.Left, currentNode, targetNode);
		}
	}
	
	private static Tree FindParentHelper(Tree currentNode, Tree currentParent, Tree targetNode)
	{
		if (currentNode == targetNode)
		{
			return currentParent;
		}
		
		Tree result = FindParentHelper(currentNode.Left, currentNode, targetNode);
		
		if (result == null)
		{
			result = FindParentHelper(currentNode.Right, currentNode, targetNode);
		}
		
		return result;
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