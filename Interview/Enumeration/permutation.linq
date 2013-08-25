<Query Kind="Program" />

void Main()
{
	List<int> input = new List<int> {1, 2, 3};

	var permutations = Permutation.Permute(input);
	permutations.Dump();
}

public class Permutation
{
	public static List<List<int>> Permute(List<int> input)
	{
		List<List<int>> resultSet = new List<List<int>>();
			
		if (input == null || input.Count < 1)
		{
			return resultSet;
		}
		
		PermutationHelper(input, ref resultSet);
		
		return resultSet;
	}
	
	private static void PermutationHelper(List<int> input, ref List<List<int>> resultSet)
	{
		if (input.Count == 0)
		{
			return;
		}
		
		// Get the first item
		int firstItem = input.First();
		
		// Remove the first item from input
		input.RemoveAt(0);
		
		// Get subsets
		var currentSet = input.ToList();
		var remaining = new List<List<int>>();
		
		PermutationHelper(currentSet, ref remaining);
		
		if (remaining.Count == 0)
		{
			var permutation = new List<int>();
			permutation.Add(firstItem);
			resultSet.Add(permutation);
		}
		else
		{
			foreach (var subset in remaining)
			{
				var permutations = Insert(subset, firstItem);
				resultSet.InsertRange(0, permutations);
			}
		}
	}
	
	private static List<List<int>> Insert(List<int> list, int item)
	{
		List<List<int>> resultSet = new List<List<int>>();
		
		for (int i = 0; i <= list.Count; i++)
		{
			var permutation = list.ToList();
			permutation.Insert(i, item);
			resultSet.Add(permutation);
		}
		
		return resultSet;
	}
}

// Define other methods and classes here
