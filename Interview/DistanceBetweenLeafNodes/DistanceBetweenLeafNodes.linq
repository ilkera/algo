<Query Kind="Program" />

void Main()
{	
	//	 	   5
	// 	  3        	  7
	// 2  1  0    10  11  12
	Node rightSub1 = null;
	Node leftSub = null;
	Node root = null;
	
	leftSub = new Node
	{
		Value = 3,
		Parent = null,
		Children = null
	};
	
	Node leftSubLeaf1 = new Node
	{
		Value = 2,
		Parent = leftSub,
		Children = null
	};
	
	Node leftSubLeaf2 = new Node
	{
		Value = 1,
		Parent = leftSub,
		Children = null
	};
	
	Node leftSubLeaf3 = new Node
	{
		Value = 0,
		Parent = leftSub,
		Children = null
	};
	
	List<Node> leftSubCollection = new List<Node>();
	leftSubCollection.Add(leftSubLeaf1);
	leftSubCollection.Add(leftSubLeaf2);
	leftSubCollection.Add(leftSubLeaf3);
	
	leftSub.Children = leftSubCollection;
	
	rightSub1 = new Node
	{
		Value = 7,
		Parent = null,
		Children = null
	};
	
	Node rightSubLeaf1 = new Node
	{
		Value = 10,
		Parent = rightSub1,
		Children = null
	};
	
	Node rightSubLeaf2 = new Node
	{
		Value = 11,
		Parent = rightSub1,
		Children = null
	};
	
	Node rightSubLeaf3 = new Node
	{
		Value = 12,
		Parent = rightSub1,
		Children = null
	};
	
	List<Node> rightSubCollection = new List<Node>();
	rightSubCollection.Add(rightSubLeaf1);
	rightSubCollection.Add(rightSubLeaf2);
	rightSubCollection.Add(rightSubLeaf3);
	
	rightSub1.Children = rightSubCollection;
	
	List<Node> treeCollection = new List<Node>();
	treeCollection.Add(leftSub);
	treeCollection.Add(rightSub1);
	
	root = new Node
	{
		 Value = 5,
		 Parent = null,
		 Children = treeCollection
	};
	
	leftSub.Parent = root;
	rightSub1.Parent = root;
	
	int count = TreeUtils.GetLeafCountBetween(leftSubLeaf2, rightSubLeaf2);
	
	count.Dump();
	
}

public class Node
{
	public Node Parent { get; set; }
	public List<Node> Children { get; set; }
	public int Value { get; set; }
	
	public Node()
	{
	}
	public Node(int value, Node parent, List<Node> children = null)
	{
		this.Value = value;
		this.Parent = parent;
		this.Children = children;
	}
}

public class TreeUtils
{
	public static int GetLeafCountBetween(Node leftLeaf, Node rightLeaf)
	{
		Node currentNode = leftLeaf;
		int count = 0;
		
		while (currentNode != null)
		{
			if (currentNode.Parent == null)
			{
				break;
			}
			
			int nodeIndex = currentNode.Parent.Children.IndexOf(currentNode);
			count += FindLeafNodeCount(currentNode.Parent, nodeIndex + 1, rightLeaf);
			
			currentNode = currentNode.Parent;
		}
		
		return count;
	}
	
	private static int FindLeafNodeCount(Node currentNode, int currentIndex, Node targetNode)
	{
		int currentCount = 0;
		
		FindLeafNodeCountHelper(currentNode, currentIndex, targetNode, ref currentCount);
		
		return currentCount;
	}
	
	private static void FindLeafNodeCountHelper(Node currentNode, int currentIndex, Node targetNode, ref int currentCount)
	{
		if (currentIndex == currentNode.Children.Count || currentNode.Children[currentIndex] == targetNode)
		{
			return;
		}
		
		if (currentNode.Children[currentIndex].Children == null)
		{
			currentCount += 1;
		}
		else
		{
			FindLeafNodeCountHelper(currentNode.Children[currentIndex], 0, targetNode, ref currentCount);
		}
		
		FindLeafNodeCountHelper(currentNode, currentIndex + 1, targetNode, ref currentCount);
	}
}

// Define other methods and classes here
