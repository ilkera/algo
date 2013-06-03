<Query Kind="Program" />

void Main()
{	
	Graph graph = new Graph(5);
	graph.AddEdge(0, 1);
	graph.AddEdge(1, 2);
	graph.AddEdge(2, 4);
	graph.AddEdge(3, 4);
	
	graph.Display();
	
	Console.WriteLine("Running DFS");
	DepthFirstSearch dfs = new DepthFirstSearch(graph, 0);
}

public class DepthFirstSearch
{
	private bool[] _marked;
	private Graph _graph;
	
	public DepthFirstSearch(Graph graph, int sourceVertex)
	{
		this._graph = graph;
		this._marked = new bool[graph.VertexCount];
		dfs(this._graph, sourceVertex);
	}
	
	private void dfs(Graph graph, int vertex)
	{
		_marked[vertex] = true;
		Console.Write(vertex + " - ");
		
		foreach (var adjacent in graph.GetAdjacent(vertex))
		{
			if(_marked[adjacent] == false)
			{	
				dfs(graph, adjacent);
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
