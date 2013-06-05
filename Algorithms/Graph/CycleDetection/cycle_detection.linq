<Query Kind="Program" />

/* Problem: Cycle detection problem */
void Main()
{
	Graph graph = new Graph(4);
	graph.AddEdge(0, 1);
	graph.AddEdge(1, 2);
	graph.AddEdge(2, 3);
	graph.AddEdge(3, 0);
	
	graph.Display();
	
	CycleDetection cd = new CycleDetection(graph);
	
	Console.WriteLine("Has cycle? " + cd.HasCycle);
}

public class CycleDetection
{
	private bool[] _marked;
	
	public bool HasCycle { get; private set; }
	
	public CycleDetection(Graph graph)
	{
		this.HasCycle = false;	
		this._marked = new bool[graph.VertexCount];
		
		for (int i = 0; i < graph.VertexCount; i++)
		{
			if(this._marked[i] == false)
			{
				Dfs(graph, i, i);
			}
		}
	}
	
	private void Dfs(Graph graph, int current, int previous)
	{
		this._marked[current] = true;
		
		foreach (var adjacent in graph.GetAdjacent(current))
		{
			if(this._marked[adjacent] == false)
			{
				Dfs(graph, adjacent, current);
			}
			else if(adjacent != previous)
			{
				HasCycle = true;
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
