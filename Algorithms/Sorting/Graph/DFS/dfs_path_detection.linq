<Query Kind="Program" />

/* Path Detection using Depth First Search 

Recursive and Iterative versions (using stack) */

void Main()
{
	Graph graph = new Graph(7);
	graph.AddEdge(0, 1);
	graph.AddEdge(1, 2);
	graph.AddEdge(2, 4);
	graph.AddEdge(3, 4);
	graph.AddEdge(5, 6);
	
	graph.Display();
	
	Console.WriteLine("Path detection: ");
	Paths pathDetection = new Paths(graph);
	PathsIterative pathDetectionIterative = new PathsIterative(graph);
	
	Console.WriteLine("(Recursive) Path from 0 to 4 {0}", pathDetection.HasPath(0, 4));
	Console.WriteLine("(Iterative) Path from 0 to 4 {0}", pathDetectionIterative.HasPath(0, 4));
	
	Console.WriteLine("Path from 0 to 4 is:");
	pathDetection.GetPath(0, 4).Dump();
	pathDetectionIterative.GetPath(0, 4).Dump();
	
	Console.WriteLine("(Recursive) Path from 2 to 5 {0}", pathDetection.HasPath(2, 5));
	Console.WriteLine("(Iterative) Path from 2 to 5 {0}", pathDetectionIterative.HasPath(2, 5));
	
	pathDetection.GetPath(2, 5).Dump();
	pathDetectionIterative.GetPath(2, 5).Dump();
}

public class PathsIterative
{
	private Graph _graph;
	private bool[] _marked;
	private int[] _edgeTo;
	
	public PathsIterative(Graph graph)
	{
		this._graph = graph;
	}
	public List<int> GetPath(int source, int target)
	{
		if(HasPath(source, target) == false)
		{
			return null;
		}
		
		Stack<int> path = new Stack<int>();
		
		for (int i = target; i != source ; i = this._edgeTo[i])
		{
			path.Push(i);
		}
		path.Push(source);
		
		return path.ToList<int>();
	}
	public bool HasPath(int source, int target)
	{
		_edgeTo = new int[this._graph.VertexCount];
		_marked = new bool[this._graph.VertexCount];
		
		Stack<int> nextToProcess = new Stack<int>();
		nextToProcess.Push(source);
		
		while(nextToProcess.Count != 0)
		{
			int current = nextToProcess.Pop();
			_marked[current] = true;
			
			if(current == target)
			{
				return true;
			}
			
			foreach (var adjacent in this._graph.GetAdjacent(current))
			{
				if(_marked[adjacent] == false)
				{
					this._edgeTo[adjacent] = current;
					nextToProcess.Push(adjacent);
				}
			}
		}
		
		return false;
	}
}

public class Paths
{	
	private bool[] _marked;
	private int[] _edgeTo;
	private Graph _graph;
	
	public Paths(Graph graph)
	{
		this._graph = graph;
	}
	
	public bool HasPath(int source, int target)
	{
		_marked = new bool[this._graph.VertexCount];
		_edgeTo = new int[this._graph.VertexCount];
		
		Dfs(this._graph, source, target);
		
		return _marked[target];
	}
	
	public List<int> GetPath(int source, int target)
	{
		if(HasPath(source, target) == false)
		{
			return null;
		}
		
		Stack<int> path = new Stack<int>();
		
		for (int i = target; i != source ; i = this._edgeTo[i])
		{
			path.Push(i);
		}
		
		path.Push(source);
		
		List<int> result = path.ToList<int>();
		
		return result;
	}
	
	private void Dfs(Graph graph, int source, int target)
	{
		_marked[source] = true;
		
		if(source == target)
		{
			return;
		}
		
		foreach (var adjacent in graph.GetAdjacent(source))
		{
			if(_marked[adjacent] == false)
			{
				this._edgeTo[adjacent] = source;
				Dfs(graph, adjacent, target);
			}
		}
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
