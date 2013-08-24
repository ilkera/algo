<Query Kind="Program" />

void Main()
{
	List<int> input = new List<int> { 1, 2, 3};
	
	List<List<int>> resultSet = Selection.Select(input, 3);
	
	foreach (var set in resultSet)
	{
		set.Dump();
	}
}

public class Selection
{
	public static List<List<int>> Select(List<int> input, int selectionSetCount)
	{
		List<List<int>> resultSet = new List<List<int>>();
		
		if (input == null || input.Count < 1)
		{
			return resultSet;
		}
		
		int[] currentSelection = new int[selectionSetCount];
		SelectionHelper(0, input, currentSelection, selectionSetCount, ref resultSet);
		
		return resultSet;
	}
	
	private static void SelectionHelper(
		int currentIndex, 
		List<int> input, 
		int[] currentSelection, 
		int selectionSetCount,
		ref List<List<int>> resultSet)
	{
		// Selection is done
		if (currentIndex == selectionSetCount)
		{
			List<int> currentResult = new List<int>();
			
			for (int i = 0; i < selectionSetCount; i++)
			{
				currentResult.Add(input[currentSelection[i]]);
			}
			resultSet.Add(currentResult);

			return;
		}
		
		// Still need to select more. 
		// Determine the start index to select from remaining set.
		// StartIndex is zero if currentIndex 0 , or it will be the last used index + 1 (without duplicates)
		int startIndex = currentIndex == 0 ? 0 : currentSelection[currentIndex - 1] + 1;
		
		for (int i = startIndex; i < input.Count; i++)
		{
			currentSelection[currentIndex] = i;
			
			// Extend it for remaining selections
			SelectionHelper(currentIndex + 1, input, currentSelection, selectionSetCount, ref resultSet);
		}
	}
}

// Define other methods and classes here
