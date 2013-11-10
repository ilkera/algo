<Query Kind="Program" />

void Main()
{
	char[,] board = { {'T', 'H', 'A', 'T'}, {'E', 'S', 'X', 'K'}, {'A', 'R', 'S', 'I'}, {'T', 'M', 'C', 'G'}};
	Boggle boggle = new Boggle(board, 4);
	boggle.ShowAllWords();
}

public class Boggle
{
	private HashSet<string> _words;
	private char[,] _board;
	private bool[,] _visited;
	private int _size;
	
	public Boggle(char[,] board, int size)
	{
		this._board = board;
		this._size = size;
		this._words = new HashSet<string>();
		this._visited = new bool[size, size];
		this.InitializeWords();
	}
	
	public void ShowAllWords()
	{
		for (int iRow = 0; iRow < this._size; iRow++)
		{
			for (int iCol = 0; iCol < this._size; iCol++)
			{
				Search(iRow, iCol, "");
			}
		}
	}
	
	private void Search(int iRow, int iCol, string prefix)
	{
		if (iRow == -1 || iCol == -1 || iRow >= this._size || iCol >= this._size)  
		{
			return;
		}
		
		if (this._visited[iRow, iCol] == true)
		{
			return;
		}
		
		if (HasPrefix(prefix) == false)
		{
			return;
		}
		
		this._visited[iRow, iCol] = true;
		
		string word = prefix + this._board[iRow, iCol];
		if (this._words.Contains(word) == true)
		{
			Console.WriteLine("Found: {0}", word);
		}
		
		for (int iCurrentRow = -1; iCurrentRow <= 1; iCurrentRow++)
		{
			for (int iCurrentCol = -1; iCurrentCol <= 1; iCurrentCol++)
			{
				Search(iRow + iCurrentRow, iCol + iCurrentCol, word);
			}
		}
		
		this._visited[iRow, iCol] = false;
	}
	
	private bool HasPrefix(string prefix)
	{
		foreach (var item in this._words.ToList())
		{
			if (item.StartsWith(prefix) == true)
			{
				return true;
			}
		}
		return false;
	}
	
	private void InitializeWords()
	{
		this._words.Add("THAT");
		this._words.Add("HAT");
		this._words.Add("KISS");
		this._words.Add("RAT");
	}
	
}

// Define other methods and classes here
