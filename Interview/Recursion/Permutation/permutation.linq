<Query Kind="Program" />

void Main()
{
	List<int> input = new List<int> {1, 2, 3 };
	
	List<List<int>> resultSet = Permutation.Permute(input);
	
	foreach (var set in resultSet)
	{
		set.Dump();
	}
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
		
		int[] currentPermutation = new int[input.Count];
	//	PermutationHelper(0, currentPermutation, input, ref resultSet);
		PermutationHelper2(0, input, ref resultSet);
		
		return resultSet;
	}
	
	private static void PermutationHelper(
		int currentIndex,
		int[] currentPermutation,
		List<int> input,
		ref List<List<int>> resultSet)
	{
		// Permutation is done
		if (currentIndex == currentPermutation.Length)
		{
			List<int> currentResult = new List<int>();
			
			for (int i = 0; i < currentPermutation.Length; i++)
			{
				currentResult.Add(input[currentPermutation[i]]);
			}
			
			resultSet.Add(currentResult);
			
			return;
		}
		
		// Extend the permutation, make the next assignment
		for (int i = 0; i < input.Count; i++)
		{
			// Make sure ith item is not used.
			bool isUsed = false;
			for (int j = 0; j < currentIndex; j++)
			{
				if (currentPermutation[j] == i)
				{
					isUsed = true;
					break;
				}
			}
			
			if (isUsed == false)
			{
				currentPermutation[currentIndex] = i;
				
				PermutationHelper(currentIndex + 1, currentPermutation, input, ref resultSet);
			}
		}
	}
	
	private static void PermutationHelper2(
		int currentIndex,
		List<int> input,
		ref List<List<int>> resultSet)
	{
		if (currentIndex == input.Count)
		{
			resultSet.Add(new List<int>(input));
			return;
		}
		
		for (int i = currentIndex; i < input.Count; i++)
		{
			Swap(ref input, currentIndex, i);
			PermutationHelper2(currentIndex + 1, input, ref resultSet);
			Swap(ref input, currentIndex, i);
		}
	}
	
	private static void Swap(ref List<int> input, int srcIndex, int destIndex)
	{
		int temp = input[srcIndex];
		input[srcIndex] = input[destIndex];
		input[destIndex] = temp;
	}
}

// Define other methods and classes here
