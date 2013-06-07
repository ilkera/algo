<Query Kind="Program" />

void Main()
{
		Tree tree = new Tree(1,
					new Tree(2,
						new Tree(8),
						new Tree(4)),
					new Tree(5,
						null,
						new Tree(6)));
						
		Console.WriteLine(TreeUtils.HasPathSum(tree, 7));
		Console.WriteLine(TreeUtils.HasPathSum(tree, 12));
		Console.WriteLine(TreeUtils.HasPathSum(tree, 6));
		Console.WriteLine(TreeUtils.HasPathSum(tree, 3));
}

public class TreeUtils
{
	public static bool HasPathSum(Tree tree, int target)
	{
		if (tree == null)
		{
			return false;
		}
		
		return HasPathSum(tree, 0, target);
	}
	
	private static bool HasPathSum(Tree tree, int currentSum, int target)
	{
		if (tree == null && currentSum == target)
		{
			return true;
		}
		
		if(tree == null)
		{
			return false;
		}
		
		if(currentSum > target)
		{
			return false;
		}
		
		return HasPathSum(tree.Left, currentSum + tree.Value, target) || HasPathSum(tree.Right, currentSum + tree.Value, target);
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
	
	public int Value { get; set; }
	public Tree Left { get; set; }
	public Tree Right { get; set; }
}

// Define other methods and classes here
