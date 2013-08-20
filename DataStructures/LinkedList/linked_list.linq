<Query Kind="Program" />


#region Tests

// InsertBeginning Test
static void Test_InsertBeginning()
{
	List<int> input = new List<int> {1, 2, 3, 4, 5 };
	ListNode head = ListUtils.CreateList(input);
	ListUtils.Display(head);
	ListUtils.InsertBeginning(ref head, 0);
	ListUtils.Display(head);
}

// InsertAfter Test
static void Test_InsertAfter()
{
	List<int> input = new List<int> {1, 2, 3, 4, 5 };
	ListNode head = ListUtils.CreateList(input);
	ListUtils.Display(head);
	ListUtils.InsertAfter(ref head, 10);
	ListUtils.Display(head);
}

// Delete test
static void Test_Delete()
{
	List<int> input = new List<int> {4, 3, 2, 1, 5 };
	ListNode head = ListUtils.CreateList(input);
	ListUtils.Display(head);
	
	input.Sort();
	foreach (var item in input.Where( i => i % 2 == 1))
	{
		ListUtils.Delete(ref head, item);	
	}
	Console.WriteLine("List after deletion:");
	ListUtils.Display(head);
}

// FindNode test
static void Test_FindNode()
{
	List<int> input = new List<int> {1, 2, 3, 4, 5 };
	ListNode head = ListUtils.CreateList(input);
	ListUtils.Display(head);
	
	ListNode targetNode = ListUtils.FindNode(head, 5);
	Console.WriteLine("Target: " + targetNode.Value);
	
	targetNode = ListUtils.FindNode(head, 1);
	Console.WriteLine("Target: " + targetNode.Value);
	
	targetNode = ListUtils.FindNode(head, 3);
	Console.WriteLine("Target: " + targetNode.Value);
	
	targetNode = ListUtils.FindNode(head, 10);
	targetNode.Dump();
}

// Insert Sorted test
static void Test_InsertSorted()
{
	ListNode head = null;
	
	ListUtils.InsertSorted(ref head, 5);
	ListUtils.Display(head);
	
	ListUtils.InsertSorted(ref head, 6);
	ListUtils.Display(head);
	
	ListUtils.InsertSorted(ref head, 6);
	ListUtils.Display(head);
	
	ListUtils.InsertSorted(ref head, 3);
	ListUtils.Display(head);
	
	ListUtils.InsertSorted(ref head, 12);
	ListUtils.Display(head);
	
	ListUtils.InsertSorted(ref head, 8);
	ListUtils.Display(head);
}

// Copy list test
static void Test_Copy()
{
	List<int> input = new List<int> {1, 2, 3, 4, 5 };
	ListNode head = ListUtils.CreateList(input);
	ListNode copy = ListUtils.Copy(head);
	ListUtils.Display(copy);
}

#endregion


void Main()
{
	Test_Copy();
}

public static class ListUtils
{
	public static ListNode CreateList(List<int> input)
	{
		ListNode head = null;
		if (input == null || input.Count < 1)
		{
			return head;
		}
		
		input.Reverse();
		
		foreach (var item in input)
		{
			InsertBeginning(ref head, item);
		}
		
		input.Reverse();
		
		return head;
	}
	
	public static void InsertBeginning(ref ListNode node, int newNodeValue)
	{
		ListNode newNode = new ListNode(newNodeValue, node);
		node = newNode;
	}
	
	public static void InsertAfter(ref ListNode node, int newNodeValue)
	{
		ListNode newNode = new ListNode(newNodeValue, node.Next);
		node.Next = newNode;
	}
	
	public static void InsertSorted(ref ListNode head, int newNodeValue)
	{
		ListNode newNode = new ListNode(newNodeValue);
		
		if (head == null)
		{
			head = newNode;
			return;
		}
		
		// Case 1: newNode < head
		if (head.Value > newNode.Value)
		{
			InsertBeginning(ref head, newNodeValue);
			return;
		}
		
		// Case 2: newNode > head
		ListNode currentNode = head;
		
		while (currentNode.Next != null && currentNode.Next.Value < newNode.Value)
		{
			currentNode = currentNode.Next;
		}
		
		newNode.Next = currentNode.Next;
		currentNode.Next = newNode;
	}
	
	public static ListNode Copy(ListNode head)
	{	
		if (head == null)
		{
			return null;
		}
		
		ListNode copyHead = new ListNode(head.Value);
		ListNode currentNode = head.Next;
		ListNode copyCurrent = copyHead;
		
		while (currentNode != null)
		{
			copyCurrent.Next = new ListNode(currentNode.Value);
			copyCurrent = copyCurrent.Next;
			currentNode = currentNode.Next;
		}
		
		return copyHead;
	}
	
	public static void Delete(ref ListNode head, int nodeValueToBeDeleted)
	{
		if (head == null)
		{
			return;
		}
		
		if (head.Value == nodeValueToBeDeleted)
		{
			head = head.Next;
			return;
		}
		
		ListNode currentNode = head;
		
		while (currentNode.Next != null && currentNode.Next.Value != nodeValueToBeDeleted)
		{
			currentNode = currentNode.Next;
		}
		
		if (currentNode.Next == null)
		{
			return; // node doesn't exist
		}
		
		currentNode.Next = currentNode.Next.Next;
	}
	
	public static ListNode FindNode(ListNode head, int target)
	{
		if (head == null)
		{
			return null;
		}
		
		ListNode currentNode = head;
		
		while (currentNode != null && currentNode.Value != target)
		{
			currentNode = currentNode.Next;
		}
		
		return currentNode ?? null;
	}
	
	public static void Display(ListNode head)
	{
		if (head == null)
		{
			return;
		}
		
		ListNode currentNode = head;
		
		while (currentNode != null)
		{
			Console.Write("{0} -> ", currentNode.Value);
			currentNode = currentNode.Next;
		}
		Console.WriteLine("");
	}
}

// Linked List Node
public class ListNode
{
	public int Value { get; set; }
	public ListNode Next { get; set; }
	
	public ListNode(int value, ListNode next = null)
	{
		this.Value = value;
		this.Next = next;
	}
}

// Define other methods and classes here