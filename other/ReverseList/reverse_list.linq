<Query Kind="Program" />

/* Problem: Reverse a linked list via Iterative and Recursion */
void Main()
{
	Node list = new Node(1, 
					new Node(2, 
						new Node(3,
							new Node(4, 
								new Node(5)))));
	ListUtils.Reverse(ref list);
	
	list.Dump();
	
	//ListUtils.Reverse_Recursive(ref list);
	
	//list.Dump();
	
//	Node reversed = ListUtils.Reverse(list);
	
//	list.Dump();
	
//	reversed.Dump();
	
}

public class ListUtils
{	
	public static Node Reverse(Node list)
	{
		Node cloneCopy = Clone(list);
		
		Reverse(ref cloneCopy);
		
		return cloneCopy;	
	}
	
	public static Node Clone(Node list)
	{
		if (list == null)
		{
			return null;
		}
		
		Node newHead = new Node(list.Value);
		Node curNode = list.Next;
		Node copyNode = newHead;
		
		while (curNode != null)
		{
			copyNode.Next = new Node(curNode.Value);
			curNode = curNode.Next;
			copyNode = copyNode.Next;
		}
		
		return newHead;
		
	}
	
	public static void Reverse(ref Node list)
	{
		if (list == null || list.Next == null)
		{
			return;
		}
		
		Node curNode = list;
		Node preNode = null;
		Node nextNode = null;
		
		while (curNode != null)
		{
			nextNode = curNode.Next;
			curNode.Next = preNode;
			preNode = curNode;
			curNode = nextNode;
		}
		
		list = preNode;
	}
	
	public static void Reverse_Recursive(ref Node list)
	{
		if (list == null || list.Next == null)
		{
			return;
		}
		
		Node preNode = null;		
		list = Reverse(ref list, ref preNode);
	}
	
	private static Node Reverse(ref Node curNode, ref Node preNode)
	{
		if (curNode == null)
		{ 
			return preNode;
		}
		
		Node nextNode = curNode.Next;
		curNode.Next = preNode;
		
		return Reverse(ref nextNode, ref curNode);
	}
}

public class Node
{
	public int Value { get; set; }
	public Node Next { get; set; }
	
	public Node(int value, Node next = null)
	{
		this.Value = value;
		this.Next = next;
	}
}

// Define other methods and classes here
