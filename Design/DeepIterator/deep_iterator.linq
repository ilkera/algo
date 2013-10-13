<Query Kind="Program" />

void Main()
{
	ArrayList list = new ArrayList();
	list.Add(1);
	list.Add(new ArrayList() { 2, 3 });
	
	ArrayList inner = new ArrayList();
	inner.Add(4);
	ArrayList inner2 = new ArrayList() { 5, 6};
	inner.Add(inner2);
	inner.Add(7);
	
	list.Add(inner);
	
	DeepIterator iterator = new DeepIterator(list.GetEnumerator());
	
	while (iterator.MoveNext())
	{
		Console.Write("{0} - ", iterator.Current); 
	}
}

public class DeepIterator : IEnumerator
{
	private IEnumerator startIterator;
	private IEnumerator currentIterator;
	private object currentItem;
	private Stack delayedIterators;
	
	public object Current
	{
		get
		{
			return this.currentItem;
		}
	}
	
	public DeepIterator(IEnumerator mainListIterator)
	{
		if (mainListIterator == null)
		{
			throw new ArgumentNullException("null iterator");
		}
		
		delayedIterators = new Stack();
		this.startIterator = mainListIterator;
		this.currentIterator = mainListIterator;
	}
	
	public bool MoveNext()
	{
		this.currentItem = GetNext();
		
		if (this.currentItem == null)
		{
			return false;
		}
		return true;
	}
	
	public void Reset()
	{
		this.currentIterator = this.startIterator;
	}
	
	private object GetNext()
	{
		if (this.currentIterator.MoveNext())
		{
			object temp = this.currentIterator.Current;
			
			if (temp is ArrayList)
			{
				delayedIterators.Push(currentIterator);
				this.currentIterator = ((ArrayList)temp).GetEnumerator();
				return GetNext();
			}
			else
			{
				this.currentItem = temp;
				return this.currentItem;
			}
		}
		else
		{
			if (delayedIterators.Count > 0)
			{
				this.currentIterator = (IEnumerator)delayedIterators.Pop();
				return GetNext();
			}
			else
			{
				return null;
			}
		}
	}
}

// Define other methods and classes here
