<Query Kind="Program" />

void Main()
{
	Graph graph = new Graph(9);
	graph.AddEdge(0, 1);
	graph.AddEdge(2, 3);
	graph.AddEdge(4, 5);
	graph.AddEdge(6, 7);
	graph.AddEdge(8, 0);

	
	graph.Display();
	
	BipartiteGraph bg = new BipartiteGraph(graph);
	Console.WriteLine("Is bipartite? " + bg.IsBipartiteGraph);
}

public class BipartiteGraph
{
	private bool[] _marked;
	private bool[] _color;
	public bool IsBipartiteGraph { get; private set; }
	
	public BipartiteGraph(Graph graph)
	{
		this.IsBipartiteGraph = true;	
		this._marked = new bool[graph.VertexCount];
		this._color = new bool[graph.VertexCount];
		
		for (int i = 0; i < graph.VertexCount; i++)
		{
			if(this._marked[i] == false)
			{
				Dfs(graph, i);
			}
		}
	}
	
	private void Dfs(Graph graph, int current)
	{
		this._marked[current] = true;
		
		foreach (var adjacent in graph.GetAdjacent(current))
		{
			if(this._marked[adjacent] == false)
			{
				this._color[adjacent] = !this._color[current];
				Dfs(graph, adjacent);
			}
			else if(this._color[current] == this._color[adjacent])
			{
				IsBipartiteGraph = false;
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