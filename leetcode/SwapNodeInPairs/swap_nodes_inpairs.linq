<Query Kind="Program" />

/* Problem: Swap Nodes in Pairs

Given a linked list, swap every two adjacent nodes and return its head.

For example,
Given 1->2->3->4, you should return the list as 2->1->4->3.

Your algorithm should use only constant space. You may not modify the values in the list, only nodes itself can be changed.

*/

void Main()
{
	Node head = new Node(1, 
					new Node(2, 
						new Node(3, 
							new Node(4,
								new Node(5, null)))));
	ListUtils.Print(head);
	
	head = ListUtils.SwapNodeInPairs(head);
	
	ListUtils.Print(head);
}

public class ListUtils
{
	public static Node SwapNodeInPairs(Node head)
	{
		if(head == null)
		{
			return null;
		}
		
		Node preNode = null;
		Node curNode = head;
		
		while (curNode != null)
		{
			Node nextNode = curNode.Next;
			
			if(nextNode == null)
			{
				return head;
			}
			
			if(preNode == null)
			{
				head = nextNode;
			}
			else
			{
				preNode.Next = nextNode;
			}
			
			curNode.Next = nextNode.Next;
			nextNode.Next = curNode;
			preNode = curNode;
			curNode = curNode.Next;
		}
		
		return head;
	}
	
	public static void Print(Node head)
	{
		Node curNode = head;
		
		while(curNode != null)
		{
			Console.Write("{0} - ", curNode.Value);
			curNode = curNode.Next;
		}
		Console.WriteLine("");
	}
}

public class Node
{
	public Node Next { get; set; }
	public int Value { get; set; }
	
	public Node(int value, Node next = null)
	{
		this.Value = value;
		this.Next = next;
	}
}

// Define other methods and classes here
