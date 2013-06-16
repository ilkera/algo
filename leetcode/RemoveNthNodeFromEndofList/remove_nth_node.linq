<Query Kind="Program" />

/* Problem: 

Given a linked list, remove the nth node from the end of list and return its head.

For example,

   Given linked list: 1->2->3->4->5, and n = 2.

   After removing the second node from the end, the linked list becomes 1->2->3->5.
Note:
Given n will always be valid.
Try to do this in one pass.

*/

void Main()
{
	Node list = new Node(1, 
					new Node(2, 
						new Node(3, 
							new Node(4, 
								new Node(5, null)))));
	
	ListUtil.RemoveNthFromEnd(ref list, 2);
	list.Dump();
}

public class ListUtil
{
	public static void RemoveNthFromEnd(ref Node list, int nValue)
	{
		if (list == null || nValue < 1)
		{
			return;
		}
		
		Node fast = list;
		Node slow = list;
		int current = 0;
		
		while (fast != null && current < nValue)
		{
			fast = fast.Next;
			current++;
		}
		
		if (fast == null)
		{
			list = list.Next;
			return;
		}
		
		while (fast.Next != null)
		{
			fast = fast.Next;
			slow = slow.Next;
		}
		
		slow.Next = slow.Next.Next;
	}
}

public class Node
{
	public int Data { get; set; }
	public Node Next { get; set; }
	
	public Node (int data, Node next = null)
	{
		this.Data = data;
		this.Next = next;
	}
}

// Define other methods and classes here
