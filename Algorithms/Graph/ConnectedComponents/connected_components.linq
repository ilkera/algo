<Query Kind="Program" />

/* Connected components : Find Connected components of a graph */
void Main()
{
	Graph graph = new Graph(11);
	graph.AddEdge(0, 1);
	graph.AddEdge(1, 2);
	graph.AddEdge(2, 4);
	graph.AddEdge(3, 4);

	graph.AddEdge(5, 6);
	
	graph.AddEdge(7, 8);
	graph.AddEdge(7, 9);
	graph.AddEdge(8, 10);
	
	graph.Display();
	
	ConnectedComponents cc = new ConnectedComponents(graph);
	Console.WriteLine("3 and 4 is connected? " + cc.IsConnected(3, 4));
	Console.WriteLine("5 and 6 is connected? " + cc.IsConnected(5, 6));
	Console.WriteLine("7 and 10 is connected? " + cc.IsConnected(7, 10));
	Console.WriteLine("0 and 8 is connected? " + cc.IsConnected(0, 8));
	Console.WriteLine("6 and 10 is connected? " + cc.IsConnected(6, 10));

}

public class ConnectedComponents
{
	private int[] _id;
	private bool[] _marked;
	private Graph _graph;
	private int _count;
	
	public ConnectedComponents(Graph graph)
	{
		this._graph = graph;
		this._count = 0;
		this._marked = new bool[graph.VertexCount];
		this._id = new int[graph.VertexCount];
		
		for (int i = 0; i < this._graph.VertexCount; i++)
		{
			if(this._marked[i] == false)
			{
				Dfs(graph, i);
				this._count++;
			}
		}
	}
	
	public bool IsConnected (int vOne, int vSecond)
	{
		return GetId(vOne) == GetId(vSecond);
	}
	
	public int GetId(int vertex)
	{
		return this._id[vertex];
	}
	
	private void Dfs(Graph graph, int source)
	{
		this._marked[source] = true;
		this._id[source] = _count;
		
		foreach (var adjacent in graph.GetAdjacent(source))
		{
			if(this._marked[adjacent] == false)
			{
				Dfs(graph, adjacent);
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
