<Query Kind="Program" />

/* Problem: Permutations

Given a collection of numbers, return all possible permutations.

For example,
[1,2,3] have the following permutations:
[1,2,3], [1,3,2], [2,1,3], [2,3,1], [3,1,2], and [3,2,1].

*/
void Main()
{
	List<int> input = new List<int> { 1, 2, 3};
	
	List<List<int>> permutations = Permutation.FindPermutations(input);	
	
	foreach (var permutation in permutations)
	{
		permutation.Dump();
	}
}

public class Permutation
{
	public static List<List<int>> FindPermutations(List<int> digits)
	{
		List<List<int>> result = new List<List<int>>();
		
		if(digits == null || digits.Count < 2)
		{
			return result;
		}
		
		FindPermutationsHelper(digits, 0, result);
		
		return result;
	}
	
	private static void FindPermutationsHelper(List<int> digits, int iCurrent, List<List<int>> result)
	{
		if(iCurrent == digits.Count)
		{
			result.Add(new List<int>(digits));
			return;
		}
		
		for (int i = iCurrent; i < digits.Count; i++)
		{
			Swap(digits, iCurrent, i);
			FindPermutationsHelper(digits, iCurrent + 1, result);
			Swap(digits, iCurrent, i);
		}
	}
	
	private static void Swap(List<int> source, int index, int change)
	{
		int temp = source[index];
		source[index] = source[change];
		source[change] = temp;
	}
}

// Define other methods and classes here