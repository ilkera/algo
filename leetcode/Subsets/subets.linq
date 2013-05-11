<Query Kind="Program" />

/* Problem: Subsets

Given a set of distinct integers, S, return all possible subsets.

Note:

Elements in a subset must be in non-descending order.
The solution set must not contain duplicate subsets.
For example,
If S = [1,2,3], a solution is:

[
  [3],
  [1],
  [2],
  [1,2,3],
  [1,3],
  [2,3],
  [1,2],
  []
]

*/

void Main()
{
	List<int> input = new List<int> { 1, 2, 3 };
	
	List<List<int>> subsets = Subsets.FindSubsets(input);
	
	subsets.Dump();
}

public class Subsets
{
	public static List<List<int>> FindSubsets(List<int> input)
	{
		List<List<int>> resultSet = new List<List<int>>();
		
		if(input == null || input.Count == 0)
		{
			return resultSet;
		}
		
		int subsetSize = (int)Math.Pow(2, input.Count);
		
		for (int i = 0; i < subsetSize; i++)
		{
			List<int> subset = new List<int>();
			
			int current = i;
			int iElement = 0;
			
			while(current > 0)
			{
				if((current & 0x01) == 1)
				{
					subset.Add(input[iElement]);
				}
				current = current >> 1;
				iElement++;
			}
			subset.Sort();
			resultSet.Add(subset);
		}
		
		return resultSet;
	}
}

// Define other methods and classes here
