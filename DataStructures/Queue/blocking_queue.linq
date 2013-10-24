<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here

public class BlockingQueue
{	
	private static object lockObject = new object();
	
	private readonly Queue<int> queue;
	private bool closing;
	
	public uint Capacity { get; private set; }
	
	public BlockingQueue(uint capacity)
	{
		this.Capacity = capacity;
		this.queue = new Queue<int>((int)this.Capacity);
		this.closing = false;
	}
	
	public void Enqueue(int item)
	{
		lock(lockObject)
		{
			while (queue.Count >= this.Capacity)
			{
				Monitor.Wait(lockObject);
			}
			
			queue.Enqueue(item);
			
			if (queue.Count == 1)
			{
				// wake up any blocked dequeue
				Monitor.PulseAll(lockObject);
			}
		}

	}
	
	public int Dequeue()
	{
		lock (lockObject)
		{
			while (queue.Count == 0)
			{
				Monitor.Wait(lockObject);
			}
			
			int item = queue.Dequeue();
			
			if (queue.Count == this.Capacity - 1)
			{
				// wake up any blocked enqueue
				Monitor.PulseAll(lockObject);
			}
			
			return item;
		}
	}
	
	public bool TryDequeue(out int item)
	{
		lock (lockObject)
		{
			while (queue.Count == 0)
			{
				if (closing == true)
				{
					item = default(int);
					return false;
				}
				Monitor.Wait(lockObject);
			}
			
			item = queue.Dequeue();
			
			if (queue.Count == this.Capacity - 1)
			{
				Monitor.PulseAll(lockObject);
			}
			
			return true;
		}
	}
}