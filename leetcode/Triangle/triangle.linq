<Query Kind="Program" />

/* Problem : Triangle

Given a triangle, find the minimum path sum from top to bottom. Each step you may move to adjacent numbers on the row below.

For example, given the following triangle

[
     [2],
    [3,4],
   [6,5,7],
  [4,1,8,3]
]
The minimum path sum from top to bottom is 11 (i.e., 2 + 3 + 5 + 1 = 11).

Note:
Bonus point if you are able to do this using only O(n) extra space, where n is the total number of rows in the triangle.

*/

void Main()
{
	List<List<int>> triangle = new List<List<int>>();
	List<int> rowOne = new List<int>{2};
	List<int> rowTwo = new List<int>{3, 4};
	List<int> rowThree = new List<int>{6, 5, 7};
	List<int> rowFour = new List<int>{4, 1, 8, 3};
	
	triangle.Add(rowOne);
	triangle.Add(rowTwo);
	triangle.Add(rowThree);
	triangle.Add(rowFour);
	
	int min = Triangle.FindMinPathSum(triangle);
	
	min.Dump();
}

public class Triangle
{
	public static int FindMinPathSum(List<List<int>> triangle)
	{
		if(triangle == null || triangle.Count == 0)
		{
			return 0;
		}
		
		int triangleSize = triangle.Count;
		
		for (int iRow = triangleSize - 2; iRow >= 0; iRow--)
		{
			for (int iCurrent = 0; iCurrent < triangle[iRow].Count; iCurrent++)
			{
				triangle[iRow][iCurrent] += Math.Min(triangle[iRow+1][iCurrent], triangle[iRow+1][iCurrent+1]);	
			}
		}
		
		return triangle[0][0];
	}
}

// Define other methods and classes here
