<Query Kind="Program" />

/* Problem: Search in rotated sorted array

Suppose a sorted array is rotated at some pivot unknown to you beforehand.

(i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).

You are given a target value to search. If found in the array return its index, otherwise return -1.

You may assume no duplicate exists in the array

*/
void Main()
{
	int[] array = {15, 16, 19, 20, 25, 1, 3, 4, 5, 7, 10, 14};
	
	int foundIndex = BinarySearchRotated.Search(array, 5);
	
	foundIndex.Dump();
}

public class BinarySearchRotated
{
	public static int Search(int[] array, int target)
	{
		if (array == null || array.Length < 1)
		{
			return -1;
		}
		
		int low = 0;
		int high = array.Length - 1;
		
		while (low <= high)
		{
			int mid = low + (high - low) / 2;
			
			if (array[mid] == target)
			{
				return mid;
			}
			else if (array[low] <= array[mid]) // left is sorted
			{
				if (target >= array[low] && target < array[mid])
				{
					high = mid - 1;
				}
				else
				{
					low = mid + 1;
				}
			}
			else // right is sorted
			{
				if (target <= array[high] && target > array[mid])
				{
					low = mid + 1;
				}
				else
				{
					high = mid - 1;
				}
			}
		}
		return -1;
	}
	
}

// Define other methods and classes here
