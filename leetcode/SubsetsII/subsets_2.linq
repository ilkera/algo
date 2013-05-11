<Query Kind="Program" />

/* Problem: Subsets II

Given a collection of integers that might contain duplicates, S, return all possible subsets.

Note:

Elements in a subset must be in non-descending order.
The solution set must not contain duplicate subsets.
For example,
If S = [1,2,2], a solution is:

[
  [2],
  [1],
  [1,2,2],
  [2,2],
  [1,2],
  []
]

*/

void Main()
{
	List<int> input = new List<int> { 1, 2, 2 };
	
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
			if(Contains(resultSet, subset) == false)
			{	
				resultSet.Add(subset);
			}
		}
		
		return resultSet;
	}
	
	private static bool Contains(List<List<int>> set, List<int> target)
	{	
		foreach (var subset in set.FindAll(e => e.Count == target.Count))
		{
			if(subset.Except(target).Any() == false)
			{
				return true;
			}
		}
		
		return false;
	}
}

// Define other methods and classes here
