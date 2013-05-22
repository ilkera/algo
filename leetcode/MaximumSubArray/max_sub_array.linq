<Query Kind="Program" />

/* Problem: Max Sub Array Problem

Find the contiguous subarray within an array (containing at least one number) which has the largest sum.

For example, given the array [−2,1,−3,4,−1,2,1,−5,4],
the contiguous subarray [4,−1,2,1] has the largest sum = 6.

*/
void Main()
{
	int[] test1 = {-2,1,-3,4,-1,2,1,-5,4 };
	int[] test2 = {-1, -3, -2, -4 };
	int[] test3 = {-1, -4, 3, -2, -9};
	int[] test4 = {1, 3, 4, 5};
	
	List<int> result = ArrayUtils.FindMaxSubArrayItems(test1);
	int max = ArrayUtils.FindMaxSubArray(test1);
	result.Dump();
	
	result = ArrayUtils.FindMaxSubArrayItems(test2);
	max = ArrayUtils.FindMaxSubArray(test2);
	result.Dump();

	result = ArrayUtils.FindMaxSubArrayItems(test3);
	max = ArrayUtils.FindMaxSubArray(test3);
	result.Dump();
	
	result = ArrayUtils.FindMaxSubArrayItems(test4);
	max = ArrayUtils.FindMaxSubArray(test4);
	result.Dump();
}

public class ArrayUtils
{
	public static int FindMaxSubArray(int[] array)
	{
		int maxSoFar = int.MinValue;
		
		if(array == null || array.Length < 1)
		{
			return maxSoFar;
		}
		
		int maxEndHere = 0;
	
		for (int i = 0; i < array.Length; i++)
		{
			maxEndHere += array[i];
			
			if(maxEndHere < 0)
			{
				maxEndHere = 0;
			}
			else
			{
				maxSoFar = Math.Max(maxSoFar, maxEndHere);
			}
		}
		return maxSoFar;
	}
	
	public static List<int> FindMaxSubArrayItems(int[] array)
	{
		List<int> result = new List<int>();
		
		int maxSoFar = int.MinValue;
		
		if(array == null || array.Length < 1)
		{
			return result;
		}
		
		int maxEndHere = 0;
		int previousSum = 0;
		int iStart = -1;
		int iEnd = -1;
		
		for (int i = 0; i < array.Length; i++)
		{
			maxEndHere += array[i];
			
			if(maxEndHere < 0)
			{
				maxEndHere = 0;
			}
			else
			{
				if(maxEndHere > maxSoFar)
				{
					maxSoFar = maxEndHere;
					iEnd = i;
				}
			}
			
			if(previousSum <= 0 && maxEndHere > 0)
			{
				iStart = i;
			}
			
			previousSum = maxEndHere;
		}
		
		if(iStart == -1)
		{
			return result;
		}
		
		for (int i = iStart; i <= iEnd; i++)
		{
			result.Add(array[i]);
		}
		
		return result;
	}
}

// Define other methods and classes here
