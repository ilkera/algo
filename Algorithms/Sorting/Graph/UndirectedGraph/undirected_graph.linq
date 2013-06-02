<Query Kind="Program" />

/* Undirected Graph Adjacency List Implementation */

void Main()
{
	UndirectedGraph graph = new UndirectedGraph(5);
	graph.AddEdge(0, 1);
	graph.AddEdge(1, 2);
	graph.AddEdge(2, 4);
	graph.AddEdge(3, 4);
	
	graph.Display();
}

public class UndirectedGraph
{
	public int VertexCount { get; set; }
	public int EdgeCount { get; set; }
	public List<List<int>> AdjacencyList { get; set; }
	
	public UndirectedGraph(int vertexCount)
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
