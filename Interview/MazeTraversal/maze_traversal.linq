<Query Kind="Program" />

void Main()
{
	int[,] maze = { {0, 0, 0, 1}, {0, 0, 1, 1}, {1, 0, 0, 1}, {1, 0, 0, 1}};
	
	maze.Dump();
	
	MazeTraversal mazeTraversal = new MazeTraversal(maze, 3, 2);
	mazeTraversal.PrintPath(0, 0);
}

public class MazeTraversal
{
	private bool[,] _marked;
	private string[,] _edgeTo;
	private int _originX;
	private int _originY;
	
	public MazeTraversal(int[,] maze, int startX, int startY)
	{
		if (maze == null)
		{
			throw new ArgumentNullException("maze");
		}
		
		this._originX = startX;
		this._originY = startY;
		int rowCount = maze.GetLength(0);
		int colCount = maze.GetLength(1);
		_marked = new bool[rowCount, colCount];
		_edgeTo = new string[rowCount, colCount];
		
		Search(maze, startX, startY, rowCount, colCount);
	}
	
	public void PrintPath(int targetX, int targetY)
	{
		if (HasPath(targetX, targetY) == false)
		{
			Console.WriteLine("No path");
		}
		
		_edgeTo.Dump();
		
		// Print
		int currentX = targetX;
		int currentY = targetY;
		
		string nextPath = null;
		while (!(currentX == _originX && currentY == _originY))
		{
			Console.Write("({0},{1}) ->", currentX, currentY);
			nextPath = _edgeTo[currentX, currentY];
			
			if (string.IsNullOrEmpty(nextPath) == true)
			{
				break;
			}
			
			currentX = Convert.ToInt32(nextPath.Split(',')[0]);
			currentY = Convert.ToInt32(nextPath.Split(',')[1]);
		}
		
		if (nextPath != null)
		{
			// Print origin
			Console.WriteLine("({0},{1})", currentX, currentY);
		}
	}
	
	private bool HasPath(int targetX, int targetY)
	{
		return _edgeTo[targetX, targetY] != null;
	}
	
	private void Search(int[,] maze, int currentX, int currentY, int rowCount, int colCount)
	{
		// Visit cell
		_marked[currentX, currentY] = true;
		string currentPath = string.Format("{0},{1}", currentX, currentY);
		
		// Visit its neighbours
		
		// Visit down
		if (currentX + 1 < rowCount && _marked[currentX + 1, currentY] == false && maze[currentX + 1, currentY] == 0)
		{
			_edgeTo[currentX + 1, currentY] = currentPath;
			Search(maze, currentX + 1, currentY, rowCount, colCount);
		}
		
		// Visit Up
		if (currentX - 1 >= 0 && _marked[currentX - 1, currentY] == false && maze[currentX -1, currentY] == 0)
		{
			_edgeTo[currentX - 1, currentY] = currentPath;
			Search(maze, currentX - 1, currentY, rowCount, colCount);
		}
		
		// Visit Left
		if (currentY - 1 >= 0 && _marked[currentX, currentY - 1] == false && maze[currentX, currentY - 1] == 0)
		{
			_edgeTo[currentX, currentY -1] = currentPath;
			Search(maze, currentX, currentY - 1, rowCount, colCount);
		}
		
		// Visit right
		if (currentY + 1 < colCount && _marked[currentX, currentY + 1] == false && maze[currentX, currentY + 1] == 0)
		{
			_edgeTo[currentX, currentY + 1] = currentPath;
			Search(maze, currentX, currentY + 1, rowCount, colCount);
		}
		
		_marked[currentX, currentY] = false;
	}
}

// Define other methods and classes here
