<Query Kind="Program" />

void Main()
{
	int[] array = {1, 1, 2};
	
	Console.WriteLine(ArrayUtils.RemoveDuplicates(array));
	
	int[] noDuplicate = {1, 2, 3};
	
	Console.WriteLine(ArrayUtils.RemoveDuplicates(noDuplicate));
	
	int[] oneItem = {1};
	
	Console.WriteLine(ArrayUtils.RemoveDuplicates(oneItem));
	
	int[] allDuplicates = {5, 5, 5, 5 ,5 };
	
	Console.WriteLine(ArrayUtils.RemoveDuplicates(allDuplicates));
}

public class ArrayUtils
{
	public static int RemoveDuplicates(int[] array)
	{
		int newLength = 0;
		
		if(array == null || array.Length <1)
		{
			return newLength;
		}
		
		int currentItem = array[0];
		int previous = currentItem;
		int index = 0;
		
		for (int i = 1; i < array.Length; i++)
		{
			currentItem = array[i];
			if(currentItem != previous)
			{
				array[index++] = currentItem;
			}
			previous = currentItem;
		}
		
		return index + 1;
	}
}

// Define other methods and classes here
