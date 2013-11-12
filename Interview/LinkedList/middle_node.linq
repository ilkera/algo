<Query Kind="Program" />

void Main()
{
	LinkedList<int> list = new LinkedList<int>();
	
	for (int i = 1; i <= 10; i++)
	{
		list.AddLast(i);
		list.Dump();
		Console.WriteLine("Mid: " + FindMidNode(list.First).Value);
	}
}

public static LinkedListNode<int> FindMidNode(LinkedListNode<int> head)
{
	if (head == null)
	{
		throw new ArgumentNullException("Null head pointer");
	}
	
	LinkedListNode<int> fastPtr = head;
	LinkedListNode<int> slowPtr = head;
	LinkedListNode<int> previous = null;
	
	while (fastPtr != null && fastPtr.Next != null)
	{
		fastPtr = fastPtr.Next.Next;
		previous = slowPtr;
		slowPtr = slowPtr.Next;
	}
	
	return head.List.Count % 2 == 0 ? previous : slowPtr;
}

// Define other methods and classes here
