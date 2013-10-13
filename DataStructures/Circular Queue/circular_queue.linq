<Query Kind="Program" />

void Main()
{
	CircularQueue q = new CircularQueue(5);
	
	for (int i = 0; i < 10; i++)
	{
		Console.WriteLine("Adding {0} result {1} Count: {2}", i, q.Enqueue(i), q.Count);
	}
	Console.WriteLine("Dequeing");
	while (q.Count != 2)
	{
		int item;
		Console.WriteLine("Result: {0} Item: {1} Count: {2}",q.Dequeue(out item), item, q.Count);
	}
	Console.WriteLine("Enqueuing");
	for (int i = 5; i < 8; i++)
	{
		Console.WriteLine("Adding {0} result {1} Count: {2}", i, q.Enqueue(i), q.Count);
	}
	
	Console.WriteLine("Dequeing 2");
	while (q.Count != 0)
	{
		int item;
		Console.WriteLine("Result: {0} Item: {1} Count: {2}",q.Dequeue(out item), item, q.Count);
	}
	
	
}

public class CircularQueue
{
	private int[] queue;
	private uint uiFront;
	private uint uiRear;
	
	public uint Count { get; private set; }
	public uint Capacity { get; private set; }
	
	public CircularQueue(uint capacity)
	{
		this.Capacity = capacity;
		this.queue = new int[this.Capacity];
		this.uiFront = 0;
		this.uiRear = 0;
		this.Count = 0;
	}
	
	public bool Enqueue(int item)
	{
		bool bReturn;
		uint uiNewRear;
		
		if (this.uiRear == this.Capacity - 1)
		{
			uiNewRear = 0;
		}
		else
		{
			uiNewRear = this.uiRear + 1;
		}
		
		if (uiNewRear == this.uiFront)
		{
			bReturn = false; // overflow
		}
		else
		{
			this.uiRear = uiNewRear;
			this.queue[this.uiRear] = item;
			this.Count += 1;
			bReturn = true;
		}
		
		return bReturn;
	}
	
	public bool Dequeue(out int item)
	{
		bool bReturn;
		
		if (this.uiFront == this.uiRear)
		{
			item = 0;
			bReturn = false; // underflow
		}
		else
		{
			if (this.uiFront == this.Capacity - 1)
			{
				this.uiFront = 0;
			}
			else
			{
				this.uiFront += 1;
			}
			
			item = this.queue[this.uiFront];
			this.queue[this.uiFront] = 0;
			this.Count -= 1;
			bReturn = true;
		}
		
		return bReturn;
	}
}

// Define other methods and classes here
