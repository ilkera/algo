<Query Kind="Program" />

void Main()
{
	 int[] array = { 2, 5, 3, 7, 11, 8, 10, 13, 6, 0 };
	 Console.WriteLine("LIS: {0}", LongestIncreasingSequence.FindLISLength(array));
}

public class LongestIncreasingSequence
{
	public static int FindLISLength(int[] array)
	{
		int[] tracking = new int[array.Length];
		tracking[0] = array[0]; // tracking[0] stores the smallest element
		
		int length = 1;
		
		for (int i = 1; i < array.Length; i++)
		{
			// Case 1 : New smallest element is found, a possible start for a sequence
			if(array[i] < tracking[0])
			{
				tracking[0] = array[i]; 
			}
			// Case 2 : Array[i] is bigger than the end element, it wants to extend
			else if(array[i] > tracking[length - 1])
			{
				tracking[length++] = array[i];
			}
			// Case 3: Array[i] is in between. Do Binary search and find a LIS where end element is smaller than Array[i].
			else
			{
				int lastIndex = Search(tracking, array[i], length -1); // get the ceil index.
				tracking[lastIndex] = array[i];
			}
		}
		return length;
	}
	
	public static int Search(int[] array, int key, int high)
	{
		int low = 0;
		
		while(low <= high)
		{
			int mid = (high - low) / 2 + low;
			
			if (array[mid] >= key)
			{
				high = mid-1;
			}
			else 
			{
				low = mid+1;
			}
		}
		return low;
	}
	
}
// Define other methods and classes here