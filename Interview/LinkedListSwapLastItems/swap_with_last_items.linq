<Query Kind="Program" />

void Main()
{
	Node list = new Node(1, new Node(2, new Node(3, new Node(4, new Node(5)))));
	
	ListUtils.Print(list);
	
	ListUtils.SwapWithLastItems(list);
	
	ListUtils.Print(list);
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

public class ListUtils
{
	public static void Print(Node list)
	{
		if (list == null)
		{
			return;
		}
		
		Node current = list;		
		while (current != null)
		{
			Console.Write("{0} -> ", current.Value);
			current = current.Next;
		}
		Console.WriteLine("");
	}

	public static void SwapWithLastItems(Node list)
	{
		if (list == null || list.Next == null)
		{
			return;
		}
		
		Node midNode = FindMidNode(list);
		Node reversed = Reverse(midNode, midNode.Next);
		
		Node left = list; 
		Node right = reversed;
		
		Merge(left, midNode, right);	
	}
	
	private static Node FindMidNode(Node list)
	{
		Node slow = list;
		Node fast = list;
		Node previous = null;
		
		while (fast != null && fast.Next != null)
		{
			fast = fast.Next.Next;
			previous = slow;
			slow = slow.Next;
		}
		
		return fast == null ? previous : slow;
	}
	
	private static Node Reverse(Node head, Node start)
	{
		Node current = start;
		Node previous = null;
		
		while (current != null)
		{
			Node next = current.Next;
			current.Next = previous;
			previous = current;
			current = next;			
		}
		
		head.Next = previous;
		
		return previous;
	}
	
	private static void Merge(Node left, Node mid, Node right)
	{
		Node currentLeft = left;
		Node currentRight = right;
		Node currentMerged = left;
		
		bool takeFromLeft = false;
		currentLeft = currentLeft.Next;

		while (currentLeft != mid && currentRight != null)
		{
			if (takeFromLeft == true)
			{
				currentMerged.Next = currentLeft;
				currentLeft = currentLeft.Next;
				takeFromLeft = false;
			}
			else
			{
				currentMerged.Next = currentRight;
				currentRight = currentRight.Next;
				takeFromLeft = true;
			}
			
			currentMerged = currentMerged.Next;
		}
		
		// Link the right node (remaining if any)
		if (currentRight != null)
		{
			currentMerged.Next = currentRight;
			currentMerged = currentMerged.Next;
		}
		
		// Link with the mid node which will be at the end.
		if (currentLeft == mid)
		{
			currentMerged.Next = currentLeft;
			currentMerged = currentMerged.Next;
		}
		
		// End link
		currentMerged.Next = null;
	}
}

// Define other methods and classes here