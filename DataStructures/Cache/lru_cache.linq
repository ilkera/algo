<Query Kind="Program" />

void Main()
{
	LRUCache<int, string> cache = new LRUCache<int, string>(5);
	cache.Put(1, "A");
	cache.Put(2, "B");
	cache.Put(3, "C");
	cache.Put(4, "D");
	cache.Put(5, "E");
	
	for (int i = 1; i < 6; i++)
	{
		Console.WriteLine("Key: {0} Value: {1}", i, cache.Get(i));
	}
	
	cache.Put(6, "F");
	cache.Put(7, "G");
	
	cache.Get(3);
	cache.Get(4);
	
	Console.WriteLine("Second pass");
	for (int i = 1; i < 10; i++)
	{
		Console.WriteLine("Key: {0} Value: {1}", i, cache.Get(i));
	}
}

public class CacheEntry<TKey, TValue>
{
	public TKey Key { get; set; }
	public TValue Value { get; set; }
	
	public CacheEntry(TKey key, TValue value)
	{
		this.Key = key;
		this.Value = value;
	}
}

// Define other methods and classes here
public class LRUCache<TKey, TValue>
{
	private Dictionary<TKey,LinkedListNode<CacheEntry<TKey, TValue>>> _cache;
	private LinkedList<CacheEntry<TKey, TValue>> _leastRecentlyUsedItems;
	
	public uint Capacity
	{
		get;
		private set;
	}
	
	public LRUCache(uint cacheSize)
	{
		this.Capacity = cacheSize;
		this._cache = new Dictionary<TKey, LinkedListNode<CacheEntry<TKey, TValue>>>((int)this.Capacity);
		this._leastRecentlyUsedItems = new LinkedList<CacheEntry<TKey, TValue>>();
	}
	
	public void Put(TKey key, TValue value)
	{
		if (this._cache.Count == this.Capacity)
		{
			this.Evict();
		}
		
		LinkedListNode<CacheEntry<TKey, TValue>> cacheEntryNode;
		bool isNewCacheEntry = true;
		
		if (this.Exists(key) == true)
		{
			cacheEntryNode = this._cache[key];
			cacheEntryNode.Value.Value = value;
			isNewCacheEntry = false;
		}
		else
		{
			cacheEntryNode = new LinkedListNode<CacheEntry<TKey, TValue>>(new CacheEntry<TKey, TValue>(key, value));
			this._cache.Add(key, cacheEntryNode);
		}
		
		this.Touch(cacheEntryNode, isNewCacheEntry);
	}
	
	public TValue Get(TKey key)
	{
		if (this._cache.ContainsKey(key) == false)
		{
			return default(TValue);
		}
		
		this.Touch(this._cache[key]);
		
		return this._cache[key].Value.Value;
	}
	
	public bool Exists(TKey key)
	{
		return this._cache.ContainsKey(key);
	}
	
	public void Remove(TKey key)
	{
		if (this.Exists(key) == false)
		{
			return;
		}
		
		LinkedListNode<CacheEntry<TKey, TValue>> cacheEntryNode = this._cache[key];
		this._cache.Remove(key);
		this._leastRecentlyUsedItems.Remove(cacheEntryNode);
	}
	
	public void Clear()
	{
		this._cache.Clear();
		this._leastRecentlyUsedItems.Clear();
	}
	
	private void Touch(LinkedListNode<CacheEntry<TKey, TValue>> cacheEntryNode, bool newNode = false)
	{
		if (newNode == false)
		{
			this._leastRecentlyUsedItems.Remove(cacheEntryNode);
		}
		
		this._leastRecentlyUsedItems.AddFirst(cacheEntryNode);
	}
	
	private void Evict()
	{
		LinkedListNode<CacheEntry<TKey, TValue>> leastRecentlyUsed = this._leastRecentlyUsedItems.Last;
		this._leastRecentlyUsedItems.RemoveLast();
		this._cache.Remove(leastRecentlyUsed.Value.Key);
	}
}