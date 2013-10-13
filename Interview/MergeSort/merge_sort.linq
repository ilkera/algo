<Query Kind="Program" />

void Main()
{
	int[] array = {2, 4, 5, 1, 3, 7};
	MergeSort.Sort(ref array);
	array.Dump();
}

public class MergeSort
{
	public static void Sort(ref int[] array)
	{
		if (array == null || array.Length < 1)
		{
			throw new ArgumentNullException("Empty/Null array");
		}
		
		if (array.Length < 2)
		{
			return; // one element case.
		}
		
		int leftSize = array.Length / 2 ;
		int rightSize = array.Length / 2;
		
		if (array.Length % 2 == 1)
		{
			leftSize += 1;
		}
		
		int[] left = new int[leftSize];
		int[] right = new int[rightSize];
		
		Array.Copy(array, 0, left, 0, leftSize);
		Array.Copy(array, leftSize, right, 0, rightSize);

		Sort(ref left);
		Sort(ref right);
		array = Merge(left, right);
	}
	
	private static int[] Merge(int[] left, int[] right)
	{
		int[] merged = new int[left.Length + right.Length];
		
		int iLeft = 0;
		int iRight = 0;
		int iCurrent = 0;
		
		while (iCurrent < merged.Length)
		{
			if (iLeft < left.Length && iRight < right.Length)
			{
				if (left[iLeft] < right[iRight])
				{
					merged[iCurrent++] = left[iLeft++];
				}
				else
				{
					merged[iCurrent++] = right[iRight++];
				}
			}
			else if(iLeft < left.Length)
			{
				merged[iCurrent++] = left[iLeft++];
			}
			else if(iRight < right.Length)
			{
				merged[iCurrent++] = right[iRight++];
			}
		}
		
		return merged;
	}
}

// Define other methods and classes here
