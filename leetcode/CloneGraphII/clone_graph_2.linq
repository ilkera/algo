<Query Kind="Program" />

void Main()
{
	Node graph = new Node(0);
	
	for (int i = 1; i < 6; i++)
	{
		graph.Neighbours.Add(new Node(i));
	}
	
	Random rnd = new Random();
	
	graph.Neighbours[0].Neighbours.Add(new Node(rnd.Next(0,20)));
	graph.Neighbours[1].Neighbours.Add(new Node(rnd.Next(0,20)));
	graph.Neighbours[2].Neighbours.Add(new Node(rnd.Next(0,20)));
	graph.Neighbours[3].Neighbours.Add(new Node(rnd.Next(0,20)));
	graph.Neighbours[4].Neighbours.Add(new Node(rnd.Next(0,20)));
	
	graph.Neighbours[0].Neighbours[0].Neighbours.Add(new Node(rnd.Next(0,20)));
	graph.Neighbours[1].Neighbours[0].Neighbours.Add(new Node(rnd.Next(0,20)));
	graph.Neighbours[2].Neighbours[0].Neighbours.Add(new Node(rnd.Next(0,20)));
	graph.Neighbours[3].Neighbours[0].Neighbours.Add(new Node(rnd.Next(0,20)));
	graph.Neighbours[4].Neighbours[0].Neighbours.Add(new Node(rnd.Next(0,20)));	
	
	graph.Dump();
	
	Node clone = GraphUtils.GraphCopy(graph);
	
	clone.Dump();
	
}

public class Node
{
	public int Data { get; set; }
	public List<Node> Neighbours { get; set;}
	
	public Node(int value)
	{
		this.Data = value;
		this.Neighbours = new List<Node>();
	}
}

public class GraphUtils
{
	public static Node GraphCopy(Node graph)
	{	
		Node clone = null;
		
		if (graph == null)
		{
			return clone;
		}
		
		DfsClone(graph, ref clone);
		
		return clone;
	}
	
	private static void DfsClone(Node node, ref Node clone)
	{
		Dictionary<Node, Node> nodeMap = new Dictionary<Node, Node>();
		Stack<Node> unvisited = new Stack<Node>();
		unvisited.Push(node);
		
		clone = new Node(node.Data);
		nodeMap.Add(node, clone);
		
		while (unvisited.Count != 0)
		{
			Node current = unvisited.Pop();
			
			// Copy Node
			if(nodeMap.ContainsKey(current) == false)
			{
				Node copy = new Node(current.Data);
				nodeMap.Add(current, copy);
			}
			// Copy Links
			foreach (var neighbour in current.Neighbours)
			{
				if(nodeMap.ContainsKey(neighbour) == false)
				{
					Node copy = new Node(neighbour.Data);
					nodeMap.Add(neighbour, copy);
				}
				nodeMap[current].Neighbours.Add(nodeMap[neighbour]);
				unvisited.Push(neighbour);
			}
		}
		
	}
}

// Define other methods and classes here
