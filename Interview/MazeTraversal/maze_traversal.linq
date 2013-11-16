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
	private Tuple<int, int>[,] _edgeTo;
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
		_edgeTo = new Tuple<int, int>[_rowCount, _colCount];
		
		Search(startX, startY);
	}
	
	public void PrintPath(int targetX, int targetY)
	{
		if (HasPath(targetX, targetY) == false)
		{
			Console.WriteLine("No path");
			return;
		}
		
		// Print
		int currentX = targetX;
		int currentY = targetY;
		
		while (!(currentX == _originX && currentY == _originY))
		{
			Console.Write("({0},{1}) ->", currentX, currentY);
			currentX = _edgeTo[currentX, currentY].Item1;
			currentY = _edgeTo[currentX, currentY].Item2;
		}
		
		Console.WriteLine("({0},{1})", currentX, currentY);
	}
	
	private bool HasPath(int targetX, int targetY)
	{
		return _edgeTo[targetX, targetY] != null;
	}
	
	private void Search(int currentX, int currentY)
	{
		// Visit cell
		_marked[currentX, currentY] = true;
		Tuple<int, int> current = new Tuple<int, int>(currentX, currentY);
		
		// Visit its neighbours
		// Visit down
		if (IsValidCell(currentX + 1, currentY) == true)
		{
			_edgeTo[currentX+1, currentY] = current;
			Search(currentX + 1, currentY);
		}
		
		// Visit Up
		if (IsValidCell(currentX - 1, currentY) == true)
		{
			_edgeTo[currentX - 1, currentY] = current;
			Search(currentX - 1, currentY);
		}
		
		// Visit Left
		if (IsValidCell(currentX, currentY - 1) == true)
		{
			_edgeTo[currentX, currentY - 1] = current;
			Search(currentX, currentY - 1);
		}
	
		// Visit right
		if (IsValidCell(currentX, currentY + 1) == true)
		{
			_edgeTo[currentX, currentY + 1] = current;
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
