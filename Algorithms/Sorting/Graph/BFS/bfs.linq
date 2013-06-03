<Query Kind="Program" />

void Main()
{
	Graph graph = new Graph(9);
	graph.AddEdge(0, 1);
	graph.AddEdge(1, 2);
	graph.AddEdge(2, 4);
	graph.AddEdge(3, 4);
	graph.AddEdge(3, 5);
	graph.AddEdge(5, 6);
	graph.AddEdge(0, 6);
	graph.AddEdge(7, 8);
	
	graph.Display();
	
	Console.WriteLine("Shortest - Path: ");
	
	// invalid
	BreadthFirstPaths bfs = new BreadthFirstPaths(graph);
	Console.WriteLine("Path from 7 to 0 exitst? " + bfs.HasPath(7, 0));
	
	// valid
	Console.WriteLine("Path from 1 to 3 exists? " + bfs.HasPath(1, 3));
	bfs.GetShortestPath(1, 3).Dump();
	
	// valid
	Console.WriteLine("Path from 5 to 0 exists? " + bfs.HasPath(5, 0));
	bfs.GetShortestPath(5, 0).Dump();
	
}

public class BreadthFirstPaths
{
	private Graph _graph;
	private bool[] _marked;
	private int[] _edgeTo;
	
	public BreadthFirstPaths(Graph graph)
	{
		this._graph = graph;
	}
	
	public bool HasPath(int source, int target)
	{
		_marked = new bool[this._graph.VertexCount];
		_edgeTo = new int[this._graph.VertexCount];
		
		Queue<int> queue = new Queue<int>();
		queue.Enqueue(source);
		_marked[source] = true;
		
		while (queue.Count != 0)
		{
			int current = queue.Dequeue();
			
			if(current == target)
			{
				return true;
			}
			
			foreach (var adjacent in this._graph.GetAdjacent(current))
			{
				if (_marked[adjacent] == false)
				{
					this._edgeTo[adjacent] = current;
					this._marked[adjacent] = true;
					queue.Enqueue(adjacent);
				}
			}
		}
		return false;
	}
	
	public List<int> GetShortestPath(int source, int target)
	{
		if(HasPath(source, target) == false)
		{
			return null;
		}
		
		Stack<int> stack = new Stack<int>();
		
		for(int i = target; i != source; i = this._edgeTo[i])
		{
			stack.Push(i);
		}
		stack.Push(source);
		
		return stack.ToList<int>();
	}
}

public class Graph
{
	public int VertexCount { get; set; }
	public int EdgeCount { get; set; }
	public List<List<int>> AdjacencyList { get; set; }
	
	public Graph(int vertexCount)
	{
		this.VertexCount = vertexCount;
		this.EdgeCount = 0;
		this.AdjacencyList = new List<List<int>>(this.VertexCount);
		
		for (int i = 0; i < vertexCount; i++)
		{
			this.AdjacencyList.Add(new List<int>());
		}
	}
	
	public void AddEdge(int vFirst, int vSecond)
	{
		this.AdjacencyList[vFirst].Add(vSecond);
		this.AdjacencyList[vSecond].Add(vFirst);
	}
	
	public List<int> GetAdjacent(int vertex)
	{
		return this.AdjacencyList[vertex];
	}
	
	public void Display()
	{
		Console.WriteLine("Displaying the graph");
		
		for (int vertex = 0; vertex < this.VertexCount; vertex++)
		{
			Console.Write("{0} -> ", vertex);
			
			foreach (var adjacent in this.GetAdjacent(vertex))
			{
				Console.Write("{0} -", adjacent);
			}
			Console.WriteLine("");
		}
	}
}

// Define other methods and classes here
