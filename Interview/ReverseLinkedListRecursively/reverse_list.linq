<Query Kind="Program" />

void Main()
{
	Node head = new Node(
				1, new Node(2, 
					new Node(3, 
						new Node(4, 
							new Node(5)))));
	
	//head.Dump();
	
	Node reversed = ListUtils.Reverse(head);
	
	reversed.Dump();
					
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

public class ListUtils
{
	public static Node Reverse(Node head)
	{
		if (head == null || head.Next == null)
		{
			return head;
		}
		
		return ReverseHelper(head, null);
	}
	
	private static Node ReverseHelper(Node currentNode, Node previousNode)
	{
		if (currentNode == null)
		{
			return previousNode;
		}
		
		Node next = currentNode.Next;
		currentNode.Next = previousNode;
		
		return ReverseHelper(next, currentNode);
	}
}

// Define other methods and classes here
