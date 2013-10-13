<Query Kind="Program" />

void Main()
{
	int[] array = {1, 3, 5, 2, 4, 6};
	
	Console.WriteLine("Inversion: " + InversionUtil.CountInversion_BruteForce(array));
	
	Console.WriteLine("Inversion: " + InversionUtil.CountInversion_SortCount(array));
}

public class InversionUtil
{
	public static int CountInversion_BruteForce(int[] array)
	{
		if (array == null || array.Length < 1 )
		{
			throw new ArgumentNullException("Null array");
		}
		
		int numInversion = 0;
		
		for (int i = 0; i < array.Length; i++)
		{
			for (int j = i + 1; j < array.Length; j++)
			{
				if (array[i] > array[j])
				{
					numInversion++;
				}
			}
		}
		
		return numInversion;
	}
	
	public static int CountInversion_SortCount(int[] array)
	{
		if (array == null || array.Length < 1)
		{
			throw new ArgumentNullException("null array");
		}
		
		if (array.Length < 2)
		{
			return 0;
		}
		
		int leftSize = array.Length / 2;
		int rightSize = array.Length / 2;
		
		if (array.Length % 2 == 1)
		{
			leftSize += 1;
		}
		
		int[] left = new int[leftSize];
		int[] right = new int[rightSize];
		
		Array.Copy(array, 0, left, 0, leftSize);
		Array.Copy(array, leftSize, right, 0, rightSize);
		
		int leftInversionCount = CountInversion_SortCount(left);
		int rightInversionCount = CountInversion_SortCount(right);
		int splitInversionCount = CountSplitInversions(left, right);
		
		return leftInversionCount + rightInversionCount + splitInversionCount;
	}
	
	private static int CountSplitInversions(int[] left, int[] right)
	{
		int[] merged = new int[left.Length + right.Length];
		
		int iLeft = 0;
		int iRight = 0;
		int iCurrent = 0;
		int numSplitInversions = 0;
		
		while (iLeft < left.Length && iRight < right.Length)
		{
			if (left[iLeft] < right[iRight])
			{
				// Left is smaller. Pick item from left. 
				// No split inversions.
				merged[iCurrent] = left[iLeft];
				iLeft++;
			}
			else
			{
				// Right is smaller. Pick item from right
				// Split Inversion!!
				merged[iCurrent] = right[iRight];
				iRight++;
				numSplitInversions += left.Length - iLeft;
			}
			
			iCurrent++;
		}
		
		while (iLeft < left.Length)
		{
			merged[iCurrent++] = left[iLeft++];
		}
		
		while (iRight < right.Length)
		{
			merged[iCurrent++] = right[iRight++];
		}
		
		return numSplitInversions;
	}
}

// Define other methods and classes here
