<Query Kind="Program" />

/* Problem: Merge K Sorted Lists

Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity.

*/
void Main()
{
	Node first = new Node(1, new Node(2, new Node(3)));
	Node second = new Node(2, new Node(2, new Node(4, new Node(5))));
	
	List<Node> nodes = new List<Node>();
	nodes.Add(first);
	nodes.Add(second);
	
	Console.WriteLine("First list");
	ListUtils.Print(first);
	Console.WriteLine("Second list");
	ListUtils.Print(second);
	
	
	Node head = ListUtils.MergeSortedLists(nodes);
	
	Console.WriteLine("Merged list");
	ListUtils.Print(head);
}

public class ListUtils
{
	public static void Print(Node head)
	{
		Node current = head;
		
		while(current != null)
		{
			Console.Write("{0} -", current.Value);
			current = current.Next;
		}
		Console.WriteLine("");
	}
	public static Node MergeSortedLists(List<Node> lists)
	{
		Node head = null;
		
		if(lists == null || lists.Count == 0)
		{
			return head;
		}
		
		MinHeap<Node> minHeap = new MinHeap<Node>();
	
		foreach (var list in lists)
		{
			minHeap.Insert(list);
		}
		
		head = minHeap.ExtractMin();
		Node current = head;
		
		if(current.Next != null)
		{
			minHeap.Insert(current.Next);
		}
		
		while(minHeap.Count != 0)
		{
			current.Next = minHeap.ExtractMin();
			current = current.Next;
			
			if(current.Next != null)
			{
				minHeap.Insert(current.Next);
			}
		}
		
		return head;
	}
}

public class Node : IComparable
{
	public Node Next { get; set; }
	public int Value { get; set; }
	
	public Node(int value, Node next = null)
	{
		this.Value = value;
		this.Next = next;
	}
	
	public int CompareTo(object other)
	{
		Node otherNode = other as Node;
		return this.Value.CompareTo(otherNode.Value);
	}
}

public class MinHeap<T> where T : IComparable
{
    private List<T> data = new List<T>();

    public void Insert(T o)
    {
        data.Add(default(T));
        int i = data.Count - 1;
        while (i > 0 && (data[i / 2].CompareTo(o) > 0))
        {
            data[i] = data[i / 2];
            i = i / 2;
        }

        data[i] = o;
    }

    public T ExtractMin()
    {
        if (data.Count < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        T min = data[0];
        data[0] = data[data.Count - 1];
        data.RemoveAt(data.Count - 1);
        this.MinHeapify(0);
        return min;
    }

    public int Count
    {
        get { return data.Count; }
    }

    private void MinHeapify(int i)
    {
        int smallest;
        int l = 2 * i;
        int r = 2 * i + 1;

        if (l < data.Count && (data[l].CompareTo(data[i]) < 0))
        {
            smallest = l;
        }
        else
        {
            smallest = i;
        }

        if (r < data.Count && (data[r].CompareTo(data[smallest]) < 0))
        {
            smallest = r;
        }

        if (smallest != i)
        {
            T tmp = data[i];
            data[i] = data[smallest];
            data[smallest] = tmp;
            this.MinHeapify(smallest);
        }
    }
}


// Define other methods and classes here
