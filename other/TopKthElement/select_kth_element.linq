<Query Kind="Program" />

/* Problem: Select top k elements in an unsorted array

Complexity: O(n) (really depends on the pivot choice and input). Used quicksort partition method

Performance: O(n)
Reorders input array
Not suitable for large input size

*/
void Main()
{
	int[] array = {5, 7, 2, 0, 4, 3, 10};
	int[] result = null;
	
	Selection.TrySelect(array, 3, out result);
	
	result.Dump();

}

public class Selection
{
	public static bool TrySelect(int[] array, int topKelement, out int[] result)
	{
		if (array == null || array.Length < 1 || topKelement < 1)
		{
			result = null;
			return false;
		}
		
		result = new int[topKelement];
		
		int start = 0;
		int end = array.Length -1;
		int pivotIndex = Partition(array, start, end);
		
		while (pivotIndex != topKelement - 1)
		{
			if (pivotIndex > topKelement - 1)
			{
				end = pivotIndex - 1;
			}
			else
			{
				start = pivotIndex + 1;
			}
			
			pivotIndex = Partition(array, start, end);
		}
		
		for (int i = 0; i < topKelement; i++)
		{
			result[i] = array[i];
		}
		
		return true;
	}
	
	public static int Partition(int[] array, int start, int end)
	{
		int pivot = array[start];
		int left = start;
		int right = end;
	
		while (left < right)
		{
			while (array[left] <= pivot)
			{
				left++;
			}
			
			while (array[right] > pivot)
			{
				right--;
			}
			
			if (left < right)
			{
				Swap(ref array, left, right);
			}
		}
		
		Swap(ref array, start, right);
		return right;
	}
	
	private static void Swap(ref int[] array, int sourceIndex, int destIndex)
	{
		int temp = array[sourceIndex];
		array[sourceIndex] = array[destIndex];
		array[destIndex] = temp;
	}
}

// Define other methods and classes here
