<Query Kind="Program" />

/* Problem: Clone Graph

Using BFS

Clone a graph. Input is a Node pointer. Return the Node pointer of the cloned graph.

A graph is defined below:
struct Node {
vector neighbors;
}

Problem: http://leetcode.com/2012/05/clone-graph-part-i.html

*/

void Main()
{
	Node first = new Node(1);
	Node second = new Node(2);
	Node third = new Node(3);
	Node fourth = new Node(4);
	
	// 1 -2, 1-3
	// 2-4
	// 3-4
	first.Neighbours.Add(second);
	first.Neighbours.Add(third);
	
	second.Neighbours.Add(fourth);
	second.Neighbours.Add(first);
	
	third.Neighbours.Add(fourth);
	third.Neighbours.Add(first);
	
	fourth.Neighbours.Add(second);
	fourth.Neighbours.Add(third);
	
	GraphUtil.BFS(first);
	
	Node clone = GraphUtil.CloneGraph(first);
	
	Console.WriteLine("Clone");
	GraphUtil.BFS(clone);
	
}

// Graph structure
public class Node
{
	public int Value { get; set; }
	public List<Node> Neighbours { get; set; }
	
	public Node(int value)
	{
		this.Value = value;
		this.Neighbours = new List<Node>();
	}
}

public class GraphUtil
{
	public static void BFS(Node graph)
	{
		Dictionary<Node, bool> visited = new Dictionary<Node, bool>();
		Queue<Node> nodes = new Queue<Node>();
		nodes.Enqueue(graph);
		visited.Add(graph, true);
		
		while(nodes.Count != 0)
		{
			Node current = nodes.Dequeue();
			Console.Write("{0} -", current.Value);
			
			for (int i = 0; i < current.Neighbours.Count; i++)
			{
				Node neighbour = current.Neighbours[i];
				
				if(visited.ContainsKey(neighbour) == false)
				{
					visited.Add(neighbour, true);
					nodes.Enqueue(neighbour);
				}
			}
		}
		
		Console.WriteLine("");
	}
	
	public static Node CloneGraph(Node graph)
	{
		if (graph == null)
		{
			return null;
		}
		
		Dictionary<Node, Node> mapNode = new Dictionary<Node, Node>();
		Queue<Node> nodes = new Queue<Node>();
		
		Node graphCopy = new Node(graph.Value);
		mapNode.Add(graph, graphCopy);
		nodes.Enqueue(graph);
		
		while(nodes.Count != 0)
		{
			Node current = nodes.Dequeue();
			
			for (int i = 0; i < current.Neighbours.Count; i++)
			{
				Node neighbour = current.Neighbours[i];
				
				if (mapNode.ContainsKey(neighbour) == true)
				{
					mapNode[current].Neighbours.Add(mapNode[neighbour]);
				}
				else
				{
					Node newCopy = new Node(neighbour.Value);
					mapNode[current].Neighbours.Add(newCopy);
					mapNode.Add(neighbour, newCopy);
					nodes.Enqueue(neighbour);
				}
			}
		}
		
		return graphCopy;
	}
}


// Define other methods and classes here
