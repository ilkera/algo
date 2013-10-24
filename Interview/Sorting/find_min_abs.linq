<Query Kind="Program" />

void Main()
{
	int[] first = {5, 11, 20, 39, 67 };
	int[] second = {3, 29, 47, 74, 79, 100};
	
	MinAbs.FindMinAbs_v1(first, second).Dump();
}

public class MinAbs
{
	public static int FindMinAbs_v1(int[] first, int[] second)
	{
		if ( first == null || second == null)
		{
			throw new ArgumentNullException("first or second array null");
		}
		
		int minAbs = int.MaxValue;
		
		foreach (var element in first)
		{
			int closest = BinarySearchClosest(second, element);
			int currentMinAbs = Math.Abs(element - closest);
			
			if (currentMinAbs < minAbs)
			{
				minAbs = currentMinAbs;
			}
		}
		
		return minAbs;
	}
	
	private static int BinarySearchClosest(int[] array, int target)
	{
		if (array == null || array.Length < 1)
		{
			throw new ArgumentNullException("no item in the array");
		}
		
		int high = array.Length - 1;
		int low = 0;
		int closest = int.MaxValue;
		int minDiff = int.MaxValue;
		
		while (low <= high)
		{
			int mid = low + (high - low) / 2;
			
			if (array[mid] == target)
			{
				return target;
			}
			else
			{
				int currentMinDiff = Math.Abs(target - array[mid]);
				
				if (currentMinDiff < minDiff)
				{
					minDiff = currentMinDiff;
					closest = array[mid];
				}
				
				if (target < array[mid])
				{
					high = mid - 1;
				}
				else
				{
					low = mid + 1;
				}
			}
		}
		
		return closest;
	}
}
// Define other methods and classes here
