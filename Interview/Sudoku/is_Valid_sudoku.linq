<Query Kind="Program" />

void Main()
{
	int[,] board = { 
	{1, 7, 2, 5, 4, 9, 6, 8, 3},
	{6, 4, 5, 8, 7, 3, 2, 1, 9},
	{3, 8, 9, 2, 6, 1, 7, 4, 5},
	{4, 9, 6, 3, 2, 7, 8, 5, 1},
	{8, 1, 3, 4, 5, 6, 9, 7, 2},
	{2, 5, 7, 1, 9, 8, 4, 3, 6},
	{9, 6, 4, 7, 1, 5, 3, 2, 8},
	{7, 3, 1, 6, 8, 2, 5, 9, 4},
	{5, 2, 8, 9, 3, 4, 1, 6, 7}};
	
	Sudoku su = new Sudoku(board);
	
	int[,] test = new int[9, 9];
	test[0,0] = 1;
	test[1,1] = 1;
	test[0,1] = 2;
	test[0,2] = 3;
	
	test[1,0] = 4;
	test[1,2] = 5;
	
	test[2,0] = 6;
	test[2,1] = 7;
	test[2,2] = 8;
	
//	Sudoku su2 = new Sudoku(test);
//	su2.IsValid().Dump();
	
	su.IsValid().Dump();
	su.IsValid_Optimized().Dump();
	
}

public class Sudoku
{
	private int[,] _board;
	
	public Sudoku(int[,] board)
	{
		this._board = board;
	}
	
	public bool IsValid_Optimized()
	{
		List<List<bool>> rowsSeen = new List<List<bool>>();
		List<List<bool>> colsSeen = new List<List<bool>>();
		List<List<bool>> blocksSeen = new List<List<bool>>();
		
		// Initialize
		const int size = 9;
		this.Initialize(ref rowsSeen, size);
		this.Initialize(ref colsSeen, size);
		this.Initialize(ref blocksSeen, size);
		
		for (int iRow = 0; iRow < 9; iRow++)
		{
			for (int iCol = 0; iCol < 9; iCol++)
			{
				int currentNumber = this._board[iRow, iCol];
				
				if (currentNumber == 0)
				{
					continue;
				}
				
				if (rowsSeen[iRow][currentNumber-1] || colsSeen[iCol][currentNumber-1] || blocksSeen[iRow - iRow % 3 + iCol / 3][currentNumber-1])
				{
					return false;
				}
				rowsSeen[iRow][currentNumber-1] = true;
				colsSeen[iCol][currentNumber-1] = true;
				blocksSeen[iRow - iRow % 3 + iCol / 3][currentNumber - 1] = true;
			}
		}
		
		return true;
	}
	
	public bool IsValid()
	{
		HashSet<int> numberLookup = new HashSet<int>();
		
		// Check each row contains same number
		for (int iRow = 0; iRow < this._board.GetLength(0); iRow++)
		{
			for (int iCol = 0; iCol < this._board.GetLength(1); iCol++)
			{
				int current = this._board[iRow, iCol];
				if (current != 0 && numberLookup.Contains(current) == true)
				{
					Console.WriteLine("Same row");
					return false;
				}
				numberLookup.Add(this._board[iRow, iCol]);
			}
			// Do it for each row
			numberLookup.Clear();
		}
		
		// Check each column contains same number
		for (int iCol = 0; iCol < this._board.GetLength(1); iCol++)
		{
			for (int iRow = 0; iRow < this._board.GetLength(0); iRow++)
			{
				int current = this._board[iRow, iCol];
				if (current != 0 && numberLookup.Contains(current) == true)
				{
					Console.WriteLine("Same column");
					return false;
				}
				numberLookup.Add(this._board[iRow, iCol]);
			}
			// Do it for each column
			numberLookup.Clear();
		}
		
		// Check each section (3x3) contains same number
		for (int iSectionRow = 0; iSectionRow < 3; iSectionRow++)
		{
			for (int iSectionCol = 0; iSectionCol < 3; iSectionCol++)
			{
				for (int iRow = 0; iRow < 3; iRow++)
				{
					for (int iCol = 0; iCol < 3; iCol++)
					{
						int current = this._board[(iSectionRow * 3) + iRow, (iSectionCol * 3) + iCol];
						if (current != 0 && numberLookup.Contains(current) == true)
						{
							Console.WriteLine("Same diagonal");
							return false;
						}
						numberLookup.Add(current);
					}
				}
				// Do it for each section
				numberLookup.Clear();
			}
		}
		
		return true;
	}
	
	private void Initialize(ref List<List<bool>> input, int size)
	{
		for (int i = 0; i < size; i++)
		{
			List<bool> current = new List<bool>(size);
			for (int j = 0; j < size; j++)
			{
				current.Add(false);
			}
			input.Add(current);
		}
	}
}
// Define other methods and classes here
