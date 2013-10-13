<Query Kind="Program" />

void Main()
{
	Node head = new Node(1, 
					new Node(2,
						new Node(3,
							new Node(4,
								new Node(5)))));
								
//	head.Dump();	
	
	foreach (var item in new int[] {1, 2, 3, 4, 5})
	{
		ListUtils.GetNodeFromEnd(head, item).Value.Dump();
	}
}

public class ListUtils
{
	public static Node GetNodeFromEnd(Node head, int n)
	{
		if (n < 1)
		{
			throw new ArgumentException("invalid number " + n);
		}
		
		if (head == null)
		{
			throw new ArgumentNullException("linked list is null");
		}
		
		Node faster = head;
		Node slower = head;
		
		int currentNodeIndex = 0; 
		
		while (faster != null)
		{	
			if (currentNodeIndex >= n)
			{
				slower = slower.Next;
			}
			else
			{
				currentNodeIndex++;
			}
			
			faster = faster.Next;
		}
		
		return slower;
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
