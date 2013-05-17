<Query Kind="Program" />

/* Problem: Set Matrix Zeroes

Given a m x n matrix, if an element is 0, set its entire row and column to 0. Do it in place.

*/
void Main()
{
	int[,] matrix = new int[4,4];
	
	matrix[0,0] = 2;
	matrix[0,1] = 5;
	matrix[0,2] = 4;
	matrix[0,3] = 9;
	
	matrix[1,0] = 2;
	matrix[1,1] = 7;
	matrix[1,2] = 4;
	matrix[1,3] = 1;
	
	matrix[2,0] = 2;
	matrix[2,1] = 5;
	matrix[2,2] = 0;
	matrix[2,3] = 9;
	
	matrix[3,0] = 0;
	matrix[3,1] = 11;
	matrix[3,2] = 16;
	matrix[3,3] = 9;
	
	matrix.Dump();
	
	MatrixUtil.SetZeroes(matrix);
	
	matrix.Dump();
	
}

public class MatrixUtil
{
	public static void SetZeroes(int[,] matrix)
	{
		int rowCount = matrix.GetLength(0);
		int columnCount = matrix.GetLength(1);
		
		bool firstRow = false;
		bool firstCol = false;
		
		// 1 - Scan First row and column
		for (int i = 0; i < rowCount; i++)
		{
			if(matrix[i,0] == 0)
			{
				firstCol = true;
				break;
			}
		}
		
		for (int i = 0; i < columnCount; i++)
		{
			if(matrix[0, i] == 0)
			{
				firstRow = true;
				break;
			}
		}
		
		// Scan rows and columns and sign the first row, and column
		for (int i = 1; i < rowCount; i++)
		{
			for (int j = 1; j < columnCount; j++)
			{
				if(matrix[i,j] == 0)
				{
					matrix[0, j] = 0;
					matrix[i, 0] = 0;
				}
			}
		}
		// Set zeroes in other positions of which the first row or column is signed with 0
		for (int i = 1; i < rowCount; i++)
		{
			for (int j = 1; j < columnCount; j++)
			{
				if(matrix[i, 0] == 0 || matrix[0, j] == 0)
				{
					matrix[i,j] = 0;
				}
			}
		}
		
		// Set zeroes to first column and row
		if(firstCol)
		{
			for (int i = 0; i < rowCount; i++)
			{
				matrix[i,0] = 0;
			}
		}
		
		if(firstRow)
		{
			for (int i = 0; i < columnCount; i++)
			{
				matrix[0,i] = 0;
			}
		}
	}
}

// Define other methods and classes here
