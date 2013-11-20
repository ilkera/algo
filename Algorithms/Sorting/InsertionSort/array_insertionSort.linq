<Query Kind="Program" />

void Main()
{
	int[] array = {7, 2, 1, 8, 0, 6, 4, 9, 5, 10, 3};
	
	InsertionSort(array);
	
	array.Dump();
}

public static void InsertionSort(int[] array)
{
	if (array == null || array.Length < 2)
	{
		return;
	}
	
	for (int index = 1; index < array.Length; index++)
	{
		int current = array[index];
		int iLeft = index - 1;
		
		while (iLeft >= 0 && current < array[iLeft])
		{
			array[iLeft + 1] = array[iLeft];
			iLeft--;
		}
		
		array[iLeft + 1] = current;
	}
}

// Define other methods and classes here
