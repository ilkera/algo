<Query Kind="Program" />

void Main()
{
	// 		1
	// 	2			5 
	// 3 4			6	7
	// 	 10 11			8	9
	
	// Find the longest path between two nodes
	TreeNode root = new TreeNode(1, 
						new TreeNode(2,
							new TreeNode(3),
							new TreeNode(4,
								new TreeNode(10),
								new TreeNode(11))),
						new TreeNode(5,
							new TreeNode(6),
							new TreeNode(7,
								new TreeNode(8),
								new TreeNode(9))));
								
	TreeUtils.GetDiameter(root).Dump();
	
	int height = 0;
	TreeUtils.GetDiameter_Optimized(root, ref height).Dump();
}

public class TreeUtils
{
	// Time: O(n)
	public static int GetDiameter_Optimized(TreeNode node, ref int height)
	{
		int leftHeight = 0;
		int rightHeight = 0;
		int leftDiameter = 0;
		int rightDiameter = 0;
		
		if (node == null)
		{
			height = 0;
			return 0;
		}
		
		leftDiameter = GetDiameter_Optimized(node.Left, ref leftHeight);
		rightDiameter = GetDiameter_Optimized(node.Right, ref rightHeight);
		
		height = 1 + Math.Max(leftHeight, rightHeight);
		
		return Math.Max(1 + leftHeight + rightHeight, Math.Max(leftDiameter, rightDiameter));
	}
	
	// Time: O(n^2)
	public static int GetDiameter(TreeNode root)
	{	
		if (root == null)
		{	
			return 0;
		}
		
		int leftHeight = GetHeight(root.Left);
		int rightHeight = GetHeight(root.Right);
		int leftDiameter = GetDiameter(root.Left);
		int rightDiameter = GetDiameter(root.Right);
		
		return Math.Max(1 + leftHeight + rightHeight, Math.Max(leftDiameter, rightDiameter));
	}
	
	private static int GetHeight(TreeNode root)
	{
		if (root == null)
		{
			return 0;
		}
		
		return 1 + Math.Max(GetHeight(root.Left), GetHeight(root.Right));
	}
}

public class TreeNode
{
	public TreeNode Left { get; set; }
	public TreeNode Right { get; set; }
	public int Value { get; set; }
	
	public TreeNode(int value, TreeNode left = null, TreeNode right = null)
	{
		this.Value = value;
		this.Left = left;
		this.Right = right;
	}
}

// Define other methods and classes here

