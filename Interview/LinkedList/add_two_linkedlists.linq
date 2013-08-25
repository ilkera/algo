<Query Kind="Program" />

void Test()
{
	List<List<int>> firstInput = new List<List<int>>{ 
	new List<int>{1, 2, 3},
	new List<int>{9, 9, 9}, 
	new List<int>{0},
	new List<int>{1}};
	
	List<List<int>> secondInput = new List<List<int>>{
	new List<int>{9, 9, 9},
	new List<int>{1},
	new List<int>{9},
	new List<int>{11}};
	
	for (int i = 0; i < firstInput.Count; i++)
	{
		var first = firstInput[i];
		var second = secondInput[i];
		
		ListNode fistList = LinkedListUtils.Create(first.ToArray());
		ListNode secondList = LinkedListUtils.Create(second.ToArray());
		
		ListNode sum = LinkedListUtils.Add(fistList, secondList);
		LinkedListUtils.Print(sum);	
	}
}
void Main()
{
	Test();
}

public static class LinkedListUtils
{
	public static ListNode Create(params int[] input)
	{
		ListNode head = new ListNode(0); // sentinel
		ListNode current = head;
		
		foreach (var item in input)
		{
			current.Next = new ListNode(item);
			current = current.Next;
		}
		
		return head.Next;
	}
	
	public static void Print(ListNode list)
	{
		if (list == null)
		{
			return;
		}
		
		ListNode current = list;
		
		while (current != null)
		{
			Console.Write("{0} - ", current.Value);
			current = current.Next;
		}
		Console.WriteLine("");
	}
	
	public static ListNode Add(ListNode first, ListNode second)
	{
		if (first == null && second == null)
		{
			throw new ArgumentNullException("both lists are null");
		}
		
		if (first == null)
		{
			return second;
		}
		
		if (second == null)
		{
			return first;
		}
		
		ListNode result = new ListNode(0); // sentinel
		ListNode currentResult = result;
		ListNode currentFirst = first;
		ListNode currentSecond = second;
		int carry = 0;
		
		while (currentFirst != null || currentSecond != null)
		{
			int currentSum = 0;
			
			if (currentFirst != null && currentSecond != null)
			{
				// Calculate current node
				currentSum = currentFirst.Value + currentSecond.Value + carry;
				
				// Iterate pointers
				currentFirst = currentFirst.Next;
				currentSecond = currentSecond.Next;
			}
			else if (currentFirst != null)
			{
				// Calculate current node
				currentSum = currentFirst.Value + carry;
				
				// Iterate pointers
				currentFirst = currentFirst.Next;
			}
			else if (currentSecond != null)
			{
				// Calculate current node
				currentSum = currentSecond.Value + carry;
				
				// Iterate pointers
				currentSecond = currentSecond.Next;
			}
			
			carry = currentSum / 10;
			currentResult.Next = new ListNode(currentSum % 10);
			currentResult = currentResult.Next;
		}
		
		if (carry > 0)
		{
			currentResult.Next = new ListNode(carry);
			currentResult = currentResult.Next;
		}
		
		return result.Next;
	}
}

public class ListNode
{
	public ListNode Next { get; set; }
	public int Value { get; set; }
	
	public ListNode(int value, ListNode next = null)
	{
		this.Value = value;
		this.Next = next;
	}
}
// Define other methods and classes here
