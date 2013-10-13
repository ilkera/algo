<Query Kind="Program" />

void Main()
{
	TreeNode tree = new TreeNode(6,
						new TreeNode(3,
							new TreeNode(2),
							new TreeNode(5)),
						new TreeNode(12,
							new TreeNode(10),
							new TreeNode(14)));
							
	for (int i = 1; i <= tree.Size; i++)
	{
		Console.WriteLine("Select({0}) = {1}", i, TreeUtils.Select(tree, i).Value);
	}
	
}

public class TreeNode
{
	public int Value { get; set; }
	public TreeNode Left { get; set; }
	public TreeNode Right { get; set; }
	
	public int Size 
	{
		get
		{
			int leftSize = this.Left != null ? this.Left.Size : 0;
			int rightSize = this.Right != null ? this.Right.Size : 0;
			
			return 1 + leftSize + rightSize;
		}
	}
	
	public TreeNode(int value, TreeNode left = null, TreeNode right = null)
	{
		this.Value = value;
		this.Left = left;
		this.Right = right;
	}
}

public class TreeUtils
{
	public static TreeNode Select(TreeNode root, int kThItem)
	{
		if (root == null)
		{
			throw new ArgumentNullException("root is null");
		}
		
		if (root.Size < kThItem)
		{
			throw new ArgumentOutOfRangeException("out of range");
		}
		
		int leftSize = root.Left != null ? root.Left.Size : 0;
		
		if (leftSize == kThItem - 1)
		{
			return root;
		}
		else if (leftSize >= kThItem)
		{
			return Select(root.Left, kThItem);
		}
		else
		{
			return Select(root.Right, kThItem - leftSize - 1);
		}
	}
}

// Define other methods and classes here
