<Query Kind="Program" />

/* Problem: Word Search

Given a 2D board and a word, find if the word exists in the grid.

The word can be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring. The same letter cell may not be used more than once.

For example,
Given board =

[
  ["ABCE"],
  ["SFCS"],
  ["ADEE"]
]
word = "ABCCED", -> returns true,
word = "SEE", -> returns true,
word = "ABCB", -> returns false.

*/
void Main()
{
	char[,] grid = new char[3, 4];
	
	grid[0,0] = 'A';
	grid[0,1] = 'B';
	grid[0,2] = 'C';
	grid[0,3] = 'E';
	
	grid[1,0] = 'S';
	grid[1,1] = 'F';
	grid[1,2] = 'C';
	grid[1,3] = 'S';
	
	grid[2,0] = 'A';
	grid[2,1] = 'D';
	grid[2,2] = 'E';
	grid[2,3] = 'E';
	
	Console.WriteLine(WordSearch.Exists(grid, "ABCCED"));
	Console.WriteLine(WordSearch.Exists(grid, "SEE"));
	Console.WriteLine(WordSearch.Exists(grid, "ABCB"));
	
}

public class WordSearch
{
	public static bool Exists(char[,] grid, string word)
	{
		int rowCount = grid.GetLength(0);
		int colCount = grid.GetLength(1);
		
		if (grid == null || rowCount == 0 || colCount == 0)
		{
			return false;
		}
		
		bool[,] visited = new bool[rowCount, colCount];
		
		for (int iRow = 0; iRow < rowCount; iRow++)
		{
			for (int iCol= 0; iCol < colCount; iCol++)
			{
				if(Search(grid, visited, iRow, iCol, word, 0) == true)
				{
					return true;
				}
			}
		}
		
		return false;
	}
	
	private static bool Search(char[,] grid, bool[,] visited, int iRow, int iCol, string word, int iCurrent)
	{
		if(grid[iRow,iCol] != word[iCurrent])
		{
			return false;
		}
		
		if(iCurrent + 1 == word.Length)
		{
			return true;
		}
		
		visited[iRow, iCol] = true;
		
		int rowCount = grid.GetLength(0);
		int colCount = grid.GetLength(1);
	
		if(iRow > 0 && visited[iRow-1, iCol] == false && Search(grid, visited, iRow -1, iCol, word, iCurrent + 1) == true)
		{
			return true;
		}
		
		if(iRow < rowCount -1 && visited[iRow+1, iCol] == false && Search(grid, visited, iRow + 1, iCol, word, iCurrent + 1) == true)
		{
			return true;
		}
		
		if(iCol > 0 && visited[iRow, iCol -1] == false && Search(grid, visited, iRow, iCol - 1, word, iCurrent + 1) == true)
		{
			return true;
		}
		
		if(iCol < colCount -1 && visited[iRow, iCol + 1] == false && Search(grid, visited, iRow, iCol + 1, word, iCurrent + 1) == true)
		{
			return true;
		}
		
		visited[iRow, iCol] = false;
		
		return false;
	}
}

// Define other methods and classes here
