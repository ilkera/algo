<Query Kind="Program" />

void Main()
{
	int[] array = {1, 2, 3, 4, 5, 6, 7};
	Tree tree = TreeUtils.ConvertToBST(array);
	
	tree.Dump();
}

public class TreeUtils
{
	public static Tree ConvertToBST(int[] sortedArray)
	{
		if (sortedArray == null || sortedArray.Length < 1)
		{	
			return null;
		}
		
		return ConvertToBST(sortedArray, 0, sortedArray.Length -1);
	}
	
	private static Tree ConvertToBST(int[] sortedArray, int left, int right)
	{
		if(left > right)
		{
			return null;
		}
		
		int rootIndex = (left + right) / 2;
		
		Tree root = new Tree(sortedArray[rootIndex]);
		root.Left = ConvertToBST(sortedArray, left, rootIndex -1);
		root.Right = ConvertToBST(sortedArray, rootIndex + 1, right);
		
		return root;
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
