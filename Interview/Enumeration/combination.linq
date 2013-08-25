<Query Kind="Program" />

void Main()
{
	List<int> input = new List<int> { 1, 2, 3 };
	List<List<int>> resultSet = Combination.Find(input);
	
	foreach (var set in resultSet)
	{
		set.Dump();
	}
}

public class Combination
{
	public static List<List<int>> Find(List<int> input)
	{
		List<List<int>> resultSet = new List<List<int>>();
		
		if (input == null || input.Count < 1)
		{
			resultSet.Add(new List<int>()); // empty set
			return resultSet;
		}
		
		// Get the first item
		int currentItem = input.First();
		
		// Remove the first item
		input.RemoveAt(0);
		
		// Get remaining subsets
		var current = new List<int>(input);
		List<List<int>> subsets = Find(current);
		
		foreach (var subset in subsets)
		{
			subset.Add(currentItem);
			resultSet.Add(subset);
		}
			
		return resultSet;
	}
	
}

// Define other methods and classes here
