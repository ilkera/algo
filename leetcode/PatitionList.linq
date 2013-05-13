<Query Kind="Program" />

/* Problem: Partition List

Given a linked list and a value x, partition it such that all nodes less than x come before nodes greater than or equal to x.

You should preserve the original relative order of the nodes in each of the two partitions.

For example,
Given 1->4->3->2->5->2 and x = 3,
return 1->2->2->4->3->5.

*/

void Main()
{
	Node head = new Node(1, 
					new Node(4, 
						new Node(3, 
							new Node(2,
								new Node(5,
									new Node(2, null))))));
									
	ListUtils.Print(head);	
	
	head = ListUtils.Partition(head, 3);
	
	ListUtils.Print(head);
								
}

public class ListUtils
{
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
	
	public static Node Partition(Node head, int target)
	{
		if(head == null)
		{
			return null;
		}
		
		Node curNode = head;
		Node leftHead = null;
		Node leftNode = null;
		Node rightHead = null;
		Node righNode = null;
		
		while(curNode != null)
		{
			if(curNode.Value < target)
			{
				if(leftHead == null)
				{
					leftHead = curNode;
					leftNode = curNode;
				}
				else
				{
					leftNode.Next = curNode;
					leftNode = leftNode.Next;
				}
			}
			else
			{
				if(rightHead == null)
				{
					rightHead = curNode;
					righNode = curNode;
				}
				else
				{
					righNode.Next = curNode;
					righNode = righNode.Next;
				}
			}
			
			curNode = curNode.Next;
		}
		
		if(leftNode != null)
		{
			leftNode.Next = rightHead;
		}
		
		if(righNode != null)
		{
			righNode.Next = null;
		}
		
		if(leftHead == null)
		{
			return rightHead;
		}
		return leftHead;
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
