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

// Cache Internal Data structures 
public class CacheItem<TKey, TValue>
{
	public TKey Key { get; set; }
	public TValue Value { get; set; }
	
	public CacheItem(TKey key, TValue value)
	{
		this.Key = key;
		this.Value = value;
	}
	
	public virtual void Update(TKey key, TValue value)
	{
		this.Key = key;
		this.Value = value;
	}
}

public class LRUCacheItem<TKey, TValue> : CacheItem<TKey, TValue>
{	
	public LinkedListNode<CacheItem<TKey, TValue>> CacheNode { get; set; }

	public LRUCacheItem(TKey key, TValue value) : base(key, value)
	{
		this.CacheNode = null;
	}
	
	public override void Update(TKey key, TValue value)
	{
		base.Update(key, value);
		
		this.CacheNode.Value.Key = key;
		this.CacheNode.Value.Value = value;
	}
}

public interface ICacheMap<TKey, TValue>
{	
	uint Count { get; }
	
	uint Capacity { get; set; } 
	
	void Put(TKey key, TValue value);

	TValue Get(TKey key);
	
	bool Exists(TKey key);
	
	void Remove(TKey key);
	
	void Clear();
}

public class LRUCacheMap<TKey, TValue> : ICacheMap<TKey, TValue>
{
	private Dictionary<TKey, LRUCacheItem<TKey, TValue>> _cacheMap;
	
	public uint Capacity
	{
		get; 
	    set;
	}
	
	public uint Count
	{
		get
		{
			return (uint)this._cacheMap.Count;
		}
	}
	
	public LRUCacheMap(uint maxCacheCapacity)
	{
		this.Capacity = maxCacheCapacity;
		this._cacheMap = new Dictionary<TKey, LRUCacheItem<TKey, TValue>>((int)maxCacheCapacity);
	}
	
	public	void Put(TKey key, TValue value)
	{
		if (this._cacheMap.ContainsKey(key) == false)
		{
			this._cacheMap.Add(key, new LRUCacheItem<TKey, TValue>(key, value));
		}
		else
		{
			LRUCacheItem<TKey, TValue> cacheItem = this._cacheMap[key];
			cacheItem.Update(key, value);
		}
	}

	public TValue Get(TKey key)
	{
		if (this._cacheMap.ContainsKey(key) == true)
		{
			LRUCacheItem<TKey, TValue> cacheItem = this._cacheMap[key];
			return cacheItem.Value;
		}
		return default(TValue);
	}
	
	public LRUCacheItem<TKey,TValue> GetCacheItem(TKey key)
	{
		return this._cacheMap[key];
	}
	
	public bool Exists(TKey key)
	{
		return this._cacheMap.ContainsKey(key);
	}
	
	public void Remove(TKey key)
	{
		this._cacheMap.Remove(key);
	}
	
	public void Clear()
	{
		this._cacheMap.Clear();
	}
}

// Eviction Strategy Interface
public interface IEvictionStrategy<TKey, TValue>
{
	void Evict();
	void Touch(TKey key, TValue value);
}

// LRU Eviction Strategy Concrete Class
public class LRUEvictionStrategy<TKey, TValue> : IEvictionStrategy<TKey, TValue>
{
	private LRUCacheMap<TKey, TValue> _cacheMap;
	private LinkedList<LRUCacheItem<TKey, TValue>> _leastRecentlyUsedItems;
	
	public LRUEvictionStrategy(LRUCacheMap<TKey, TValue> cacheMap)
	{
		this._cacheMap = cacheMap;
		this._leastRecentlyUsedItems = new LinkedList<LRUCacheItem<TKey, TValue>>();
	}
	
	public void Evict()
	{
		LinkedListNode<LRUCacheItem<TKey, TValue>> lastItem = this._leastRecentlyUsedItems.Last;
		this._leastRecentlyUsedItems.RemoveLast();
		
		// Evict from cache
		this._cacheMap.Remove(lastItem.Value.Key);
	}
	
	public void Touch(TKey key, TValue value)
	{
		LRUCacheItem<TKey, TValue> cacheItem = this._cacheMap.GetCacheItem(key);
		LinkedListNode<CacheItem<TKey, TValue>> cacheNode = cacheItem.CacheNode;
		
		if (cacheNode == null)
		{
			cacheItem.CacheNode = new LinkedListNode<CacheItem<TKey, TValue>>(new CacheItem<TKey, TValue>(key, value));
			this._leastRecentlyUsedItems.AddFirst(cacheItem);
		}
		else
		{
			this._leastRecentlyUsedItems.Remove(cacheItem);
			this._leastRecentlyUsedItems.AddFirst(cacheItem);
		}
	}
}

// Abstract Cache
public abstract class Cache<TKey, TValue>
{
	protected ICacheMap<TKey, TValue> _cacheMap;
	protected IEvictionStrategy<TKey, TValue> _evictionStrategy;
	
	public uint Capacity
	{
		get;
		private set;
	}
	
	public Cache(uint maxCacheCapacity)
	{
		this.Capacity = maxCacheCapacity;
	}
	
	public void Put(TKey key, TValue value)
	{
		if (this._cacheMap.Count == this.Capacity)
		{
			this._evictionStrategy.Evict();
		}
		this._cacheMap.Put(key, value);
		this._evictionStrategy.Touch(key, value);
	}
	
	public TValue Get(TKey key)
	{
		if (this._cacheMap.Exists(key) == true)
		{
			TValue result = this._cacheMap.Get(key);
			this._evictionStrategy.Touch(key, result);
			return result;
		}
		
		return default(TValue);
	}
	
	public bool Exists(TKey key)
	{
		return this._cacheMap.Exists(key);
	}
	
	public void Clear()
	{
		this._cacheMap.Clear();
	}
}

// LRUCache Concrete Class
public class LRUCache<TKey, TValue> : Cache<TKey, TValue>
{	
	public LRUCache(uint maxCacheCapacity) : base(maxCacheCapacity)
	{
		LRUCacheMap<TKey, TValue> lruCache = new LRUCacheMap<TKey, TValue>(maxCacheCapacity);
		this._evictionStrategy = new LRUEvictionStrategy<TKey, TValue>(lruCache);
		this._cacheMap = lruCache;
	}
}
// Define other methods and classes here
