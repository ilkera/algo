<Query Kind="Program" />

// Tests

// Test Loop Marking Nodes
static void Test_Loop_MarkingNodes()
{
	List<int> input = new List<int> { 1, 2, 3, 4, 5};
	ListNode head = ListUtils.CreateListWithLoop(input);
	
	bool hasLoop = ListUtils.HasLoop_MarkingNodes(head);
	Console.WriteLine("Has loop - marking nodes: " + hasLoop.ToString());
}

// Test Loop HashTable
static void Test_Loop_HashTable()
{
	List<int> input = new List<int> { 1, 2, 3, 4, 5};
	ListNode head = ListUtils.CreateListWithLoop(input);
	
	bool hasLoop = ListUtils.HasLoop_HashTable(head);
	Console.WriteLine("Has loop - Hashtable: " + hasLoop.ToString());
}

// Test Loop retracing
static void Test_Loop_Retracing()
{
	List<int> input = new List<int> { 1, 2, 3, 4, 5};
	ListNode head = ListUtils.CreateListWithLoop(input);
	
	bool hasLoop = ListUtils.HasLoop_Retracing(head);
	Console.WriteLine("Has loop - retracing: " + hasLoop.ToString());
}

// Test Loop reversal
static void Test_Loop_Reversal()
{
	List<int> input = new List<int> { 1, 2, 3, 4, 5};
	ListNode head = ListUtils.CreateListWithLoop(input);
	
	bool hasLoop = ListUtils.HasLoop_Reversal(head);
	Console.WriteLine("Has loop - reversal: " + hasLoop.ToString());
}

void Main()
{
	Test_Loop_Reversal();
}

public static class ListUtils
{
	public static ListNode CreateListWithLoop(List<int> input)
	{
		ListNode head = null; 
		
		if (input == null || input.Count < 1)
		{
			return head;
		}
		
		foreach (var item in input)
		{
			InsertEnd(ref head, item);
		}
		
		ListNode lastNode = GetLastNode(head);
		lastNode.Next = head;
		
		return head;
	}
	
	public static ListNode GetLastNode(ListNode head)
	{
		if (head == null || head.Next == null)
		{
			return head;
		}
		
		ListNode currentLast = head;
		
		while (currentLast.Next != null)
		{
			currentLast = currentLast.Next;
		}
		
		return currentLast;
	}
	
	public static void InsertEnd(ref ListNode head, int newNodeValue)
	{
		if (head == null)
		{
			head = new ListNode(newNodeValue);
			return;
		}
		
		ListNode currentNode = head;
		
		while (currentNode.Next != null)
		{
			currentNode = currentNode.Next;
		}
		
		currentNode.Next = new ListNode(newNodeValue);
	}
	
	public static ListNode ReverseList(ref ListNode head)
	{
		if (head == null || head.Next == null)
		{
			return head;
		}
		
		ListNode currentNode = head;
		ListNode previous = null;
		
		while (currentNode != null)
		{
			ListNode next = currentNode.Next;
			currentNode.Next = previous;
			previous = currentNode;
			currentNode = next;
		}
		
		return previous;
	}
	
	public static bool HasLoop_MarkingNodes(ListNode head)
	{
		if (head == null)
		{
			return false;
		}
		
		ListNode currentNode = head;
		
		while (currentNode != null && currentNode.IsVisited == false)
		{
			currentNode.IsVisited = true;
			currentNode = currentNode.Next;
		}
		
		if (currentNode == null)
		{
			return false;
		}
		
		// we have loop! unmark the entire list.
		currentNode = head;
		
		while (currentNode != null && currentNode.IsVisited == true)
		{
			currentNode.IsVisited = false;
			currentNode = currentNode.Next;
		}
		
		return true;
	}
	
	public static bool HasLoop_HashTable(ListNode head)
	{
		if (head == null)
		{
			return false;
		}
		
		HashSet<ListNode> visited = new HashSet<ListNode>();
		ListNode currentNode = head;
		
		bool hasLoop = false;
		while (currentNode != null)
		{
			if (visited.Contains(currentNode) == true)
			{
				hasLoop = true;
				break;
			}
			visited.Add(currentNode);
			currentNode = currentNode.Next;
		}
		
		return hasLoop;
	}
	
	public static bool HasLoop_Retracing(ListNode head)
	{
		if (head == null)
		{
			return false;
		}
		
		ListNode currentNode = head;
		bool hasLoop = true;
		
		while (currentNode != null)
		{
			ListNode tracer = currentNode.Next;
			
			while (tracer != null)
			{
				if (tracer == currentNode)
				{
					hasLoop = true;
					break;
				}
				tracer = tracer.Next;
			}
			
			if (hasLoop)
			{
				break;
			}
			
			currentNode = currentNode.Next;
		}
		
		return hasLoop;
	}
	
	public static bool HasLoop_Reversal(ListNode head)
	{
		if (head == null)
		{
			return false;
		}
		
		// Reverse the list
		ListNode reversed = ReverseList(ref head);
		
		// Reverse again to restore the original links
		ReverseList(ref reversed);

		return head == reversed;
	}
}

// Define other methods and classes here

// Linked List Node
public class ListNode
{
	public int Value { get; set; }
	public ListNode Next { get; set; }
	public bool IsVisited { get; set; } // used with marking algorithm
	
	public ListNode(int value, ListNode next = null)
	{
		this.Value = value;
		this.Next = next;
	}
}