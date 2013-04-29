<Query Kind="Program" />

/*

Problem: Sum root to leaf numbers

Given a binary tree containing digits from 0-9 only, each root-to-leaf path could represent a number.

An example is the root-to-leaf path 1->2->3 which represents the number 123.

Find the total sum of all root-to-leaf numbers.

For example,

    1
   / \
  2   3
The root-to-leaf path 1->2 represents the number 12.
The root-to-leaf path 1->3 represents the number 13.

Return the sum = 12 + 13 = 25.

*/
void Main()
{
	Tree tree = new Tree(1, 
			new Tree(2, 
				new Tree(3,null,null),
				new Tree(4,null,null)),
			new Tree(3, 
				null, 
				new Tree(5,null,null)));
	
	Console.WriteLine("Sum is: " + SumToLeafNumber.GetSum(tree));
}

public class SumToLeafNumber
{
	public static int GetSum(Tree node)
	{
		if(node == null)
		{
			return 0;
		}
		
		if(node.Left == null && node.Right == null)
		{
			return node.Value;
		}
		
		List<int> numbers = new List<int>();
		GetSum(node, 0, numbers);
		
		return numbers.Sum();
	}
	
	private static void GetSum(Tree current, int numberSoFar, List<int> numbers)
	{
		if(current == null)
		{
			return;
		}
		
		int currentNumber = numberSoFar * 10 + current.Value;
		
		if(current.Left == null && current.Right == null)
		{
			numbers.Add(currentNumber);
			return;
		}
		
		GetSum(current.Left, currentNumber, numbers);
		GetSum(current.Right, currentNumber, numbers);
	}
	
}

public class Tree
{
	public Tree(int value, Tree left, Tree right)
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
