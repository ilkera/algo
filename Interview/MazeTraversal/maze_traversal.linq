<Query Kind="Program" />

void Main()
{
	int[,] maze = { {0, 0, 0, 1}, {0, 0, 1, 1}, {1, 0, 0, 1}, {1, 0, 0, 1}};
	
	maze.Dump();
	
	MazeTraversal mazeTraversal = new MazeTraversal(maze, 3, 3);
	mazeTraversal.PrintPath(0, 0);
}

public class MazeTraversal
{
	private int[,] _maze;
	private bool[,] _marked;
	private string[,] _edgeTo;
	private int _originX;
	private int _originY;
	private int _rowCount;
	private int _colCount;
	
	public MazeTraversal(int[,] maze, int startX, int startY)
	{
		if (maze == null)
		{
			throw new ArgumentNullException("maze");
		}
		
		_maze = maze;
		_originX = startX;
		_originY = startY;
		_rowCount = _maze.GetLength(0);
		_colCount = _maze.GetLength(1);
		_marked = new bool[_rowCount, _colCount];
		_edgeTo = new string[_rowCount, _colCount];
		
		Search(startX, startY);
	}
	
	public void PrintPath(int targetX, int targetY)
	{
		if (HasPath(targetX, targetY) == false)
		{
			Console.WriteLine("No path");
			return;
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
	
	private void Search(int currentX, int currentY)
	{
		// Visit cell
		_marked[currentX, currentY] = true;
		string currentPath = string.Format("{0},{1}", currentX, currentY);
		
		// Visit its neighbours
		// Visit down
		if (IsValidCell(currentX + 1, currentY) == true)
		{
			_edgeTo[currentX + 1, currentY] = currentPath;
			Search(currentX + 1, currentY);
		}
		
		// Visit Up
		if (IsValidCell(currentX - 1, currentY) == true)
		{
			_edgeTo[currentX - 1, currentY] = currentPath;
			Search(currentX - 1, currentY);
		}
		
		// Visit Left
		if (IsValidCell(currentX, currentY - 1) == true)
		{
			_edgeTo[currentX, currentY -1] = currentPath;
			Search(currentX, currentY - 1);
		}
	
		// Visit right
		if (IsValidCell(currentX, currentY + 1) == true)
		{
			_edgeTo[currentX, currentY + 1] = currentPath;
			Search(currentX, currentY + 1);
		}

		_marked[currentX, currentY] = false;
	}
	
	private bool IsValidCell(int targetX, int targetY)
	{
		bool isValidX = targetX >= 0 && targetX < _rowCount;
		bool isValidY = targetY >= 0 && targetY < _colCount;
		
		if (isValidX == false || isValidY == false)
		{
			return false;
		}
		
		bool isNotMarked = _marked[targetX, targetY] == false;
		bool hasValueZero = _maze[targetX, targetY] == 0;
		
		return isNotMarked && hasValueZero;
	}
}

// Define other methods and classes here
