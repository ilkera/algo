<Query Kind="Program" />

void Main()
{
	string[] keys = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

	SimpleHashTable<string, string> hTable = new SimpleHashTable<string, string>();
	hTable.Put("A", "1");
	hTable.Put("B", "2");
	hTable.Put("C", "3");
	hTable.Put("D", "4");
	hTable.Put("E", "5");
	hTable.Put("F", "6");
	hTable.Put("G", "7");
	hTable.Put("H", "8");
	hTable.Put("I", "9");
	hTable.Put("J", "10");
	hTable.Put("K", "11");
	hTable.Put("L", "12");
	hTable.Put("M", "13");
	hTable.Put("N", "14");
	hTable.Put("O", "15");
	hTable.Put("P", "16");
	hTable.Put("Q", "17");
	hTable.Put("R", "18");
	hTable.Put("S", "19");
	hTable.Put("T", "20");
	hTable.Put("U", "21");
	hTable.Put("V", "22");	
	hTable.Put("W", "23");
	hTable.Put("X", "24");
	hTable.Put("Y", "25");
	hTable.Put("Z", "26");
	
	foreach (var key in keys)
	{
		Console.WriteLine("Key: {0} Value: {1}", key, hTable.Get(key));
	}

}

public class Node<TKey, TValue>
{
	public TKey Key { get; set; }
	public TValue Value { get; set; }
	public Node<TKey, TValue> Next { get; set; }
	
	public Node(TKey key, TValue value, Node<TKey, TValue> next = null)
	{
		this.Key = key;
		this.Value = value;
		this.Next = next;
	}
}
public class SimpleHashTable<TKey, TValue>
{
	private const int MAX_NODE_SIZE = 10;
	private Node<TKey,TValue>[] nodes;

	public SimpleHashTable()
	{
		this.nodes = new Node<TKey,TValue>[MAX_NODE_SIZE];
	}
	
	public TValue Get(TKey key)
	{
		int index = Hash(key);
		
		for (Node<TKey,TValue> current = nodes[index]; current != null; current = current.Next)
		{
			if (key.Equals(current.Key) == true)
			{
				return current.Value;
			}
		}
		return default(TValue);
	}
	
	public void Put(TKey key, TValue value)
	{
		int index = Hash(key);
		
		for (Node<TKey, TValue> current = this.nodes[index]; current != null; current = current.Next)
		{
			if (key.Equals(current.Key) == true)
			{
				current.Value = value;
				return;
			}
		}
		
		Node<TKey,TValue> newNode = new Node<TKey, TValue>(key, value, this.nodes[index]);
		this.nodes[index] = newNode;
	}
	
	private int Hash(TKey key)
	{
		return (key.GetHashCode() & 0xfffffff) % MAX_NODE_SIZE;
	}
	
}

// Define other methods and classes here
