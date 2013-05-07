<Query Kind="Program" />

/* Problem: 3Sum

Given an array S of n integers, are there elements a, b, c in S such that a + b + c = 0?
Find all unique triplets in the array which gives the sum of zero.

Note:

Elements in a triplet (a,b,c) must be in non-descending order. (ie, a ? b ? c)
The solution set must not contain duplicate triplets.
    For example, given array S = {-1 0 1 2 -1 -4},

    A solution set is:
    (-1, 0, 1)
    (-1, -1, 2)

*/

void Main()
{
	int[] array = {-1, 0, 1, 2, -1, -4, 1};
	
	List<List<int>> triplets = ThreeSum.FindThreeSum(array);
	
	foreach (var triplet in triplets)
	{
		triplet.Dump();
	}
}

public class ThreeSum
{
	public static List<List<int>> FindThreeSum(int[] array)
	{
		if(array == null || array.Length <3)
		{
			throw new ArgumentException("invalid input.");
		}
		
		Array.Sort(array);
		List<List<int>> result = new List<List<int>>();
		
		for (int i = 0; i < array.Length; i++)
		{
			int left = i + 1;
			int right = array.Length - 1;
			
			while(left < right)
			{
				int current = array[i] + array[left] + array[right];
				
				if(current == 0)
				{
					List<int> triplet = new List<int>();
					triplet.Add(array[i]);
					triplet.Add(array[left]);
					triplet.Add(array[right]);
					
					triplet.Sort();
					
					if(TryFind(triplet, result) == false)
					{
						result.Add(triplet);
					}
					
					left++;
					right--;
				}
				else if(current > 0)
				{
					right--;
				}
				else
				{
					left++;
				}
			}
		}
		
		return result;
	}
	
	private static bool TryFind(List<int> target, List<List<int>> collection)
	{
		foreach (var triplet in collection)
		{
			if(target.Count != triplet.Count)
			{
				continue;
			}
			
			bool containsAll = target.All(item => triplet.Contains(item));
			
			if(containsAll == true)
			{
				return true;
			}
		}
		
		return false;
	}
}

// Define other methods and classes here
