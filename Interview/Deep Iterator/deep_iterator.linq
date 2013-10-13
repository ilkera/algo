<Query Kind="Program" />

void Test_BasicIterator()
{
	MyCollection<int> collection = new MyCollection<int>();
	
	collection.Add(1);
	collection.Add(2);
	collection.Add(3);
	
	var iterator = collection.GetEnumerator();
	
	while (iterator.MoveNext())
	{
		Console.Write("{0} ", iterator.Current);
	}
	Console.WriteLine("");
}

void Main()
{
	
	NestedCollection nested = new NestedCollection();
}

public class MyCollection<T>
{
	private List<T> Collection { get; set; }
	
	public MyCollection()
	{
		this.Collection = new List<T>();
	}
	
	public void Add(T item)
	{
		this.Collection.Add(item);
	}
	
	public T this[int index]
	{
		get
		{
			if (IsValidIndex(index) == false)
			{
				throw new ArgumentOutOfRangeException("invalid index");
			}
			
			return this.Collection[index];
		}
		set
		{
			if (IsValidIndex(index) == false)
			{
				throw new ArgumentOutOfRangeException("invalid index");
			}
			
			this.Collection[index] = value;
		}
	}
	
	 public IEnumerator<T> GetEnumerator()
     {
        for (int i = 0; i < this.Collection.Count; i++)
		{
            yield return this.Collection[i];
        }
	}
	
	private bool IsValidIndex(int index)
	{
		if (index < 0 || index > this.Collection.Count)
		{
			return false;
		}
		
		return true;
	}
}

// Define other methods and classes here
