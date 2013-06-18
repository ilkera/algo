<Query Kind="Program" />

/* Problem: Insert into sorted cyclic list

Given a node from a cyclic linked list which has been sorted, 
write a function to insert a value into the list such that it remains a cyclic sorted list. 

The given node can be any single node in the list.

*/
void Main()
{
	Node list = null;
	
	ListUtil.Insert(ref list, 5);
	
	ListUtil.Insert(ref list, 3);
	
	ListUtil.Insert(ref list, 4);
	
	list.Dump();
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

public class ListUtil
{
	public static void Insert(ref Node aNode, int valueToBeInserted)
	{
		// Case 1 : List is empty
		if (aNode == null)
		{
			aNode = new Node(valueToBeInserted);
			aNode.Next = aNode;
			return;
		}
		
		Node curNode = aNode;
		Node preNode = null;
		
		do
		{
			preNode = curNode;
			curNode = curNode.Next;
			
			// Case 2: Value to be inserted is in the middle, or duplicate
			if (curNode.Data >= valueToBeInserted && valueToBeInserted >= preNode.Data)
			{
				break;
			}
			
			// Case 3: Value to be inserted is minimum/maximum
			if ((preNode.Data > curNode.Data) && (valueToBeInserted < curNode.Data || valueToBeInserted > preNode.Data))
			{
				break;
			}
			
		} while (curNode != aNode);
		
		Node newNode = new Node(valueToBeInserted);
		newNode.Next = curNode;
		preNode.Next = newNode;
	}
}

// Define other methods and classes here
