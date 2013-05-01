<Query Kind="Program" />

/* Problem: Longest Consecutive Sequence

Given an unsorted array of integers, find the length of the longest consecutive elements sequence.

For example,
Given [100, 4, 200, 1, 3, 2],
The longest consecutive elements sequence is [1, 2, 3, 4]. Return its length: 4.

Your algorithm should run in O(n) complexity.

*/

void Main()
{
	int[] array = {100, 4, 200, 1, 3, 2 };
	
	Console.WriteLine("Length: {0}", LongestConsecutiveSequence.GetLongestConsecutiveSequenceLength(array));
	Console.WriteLine("Length: {0}", LongestConsecutiveSequence.GetLongestConsecutiveSequenceLength_v2(array));
}

public class LongestConsecutiveSequence
{
	public static int GetLongestConsecutiveSequenceLength(int[] array)
	{	
		int maxLenSoFar = 0;
				
		if(array == null || array.Length < 1)
		{
			return maxLenSoFar;
		}

		Array.Sort(array);
		int currentLen = 1;
		
		for (int i = 1; i < array.Length; i++)
		{
			int diff = array[i] - array[i-1];
			
			if(diff == 0)
			{
				continue; // duplicates
			}
			
			if(diff == 1)
			{
				currentLen++;
				
				if(currentLen > maxLenSoFar)
				{
					maxLenSoFar = currentLen;
				}
			}
			else
			{
				currentLen = 0;
			}
		}
		
		return maxLenSoFar;
	}
	
	public static int GetLongestConsecutiveSequenceLength_v2(int[] array)
	{		
		if(array == null || array.Length < 1)
		{
			return 0;
		}
		
		Dictionary<int, int> consecutiveCount = new Dictionary<int, int>();
		int maxSoFar = 0; 	
		
		for (int i = 0; i < array.Length; i++)
		{
			if(consecutiveCount.ContainsKey(array[i]) == true)
			{
				continue;
			}
			
			consecutiveCount.Add(array[i], 1);
			
			if(consecutiveCount.ContainsKey(array[i] + 1) == true)
			{
				maxSoFar = Math.Max(maxSoFar, Merge(consecutiveCount, array[i], array[i] + 1));
			}
			
			if(consecutiveCount.ContainsKey(array[i] - 1) == true)
			{
				maxSoFar = Math.Max(maxSoFar, Merge(consecutiveCount, array[i], array[i] - 1));
			}
		}
		
		return maxSoFar;
	}
	
	private static int Merge(Dictionary<int, int> consecutiveCount, int left, int right)
	{
		int nLeft = consecutiveCount[left];
		int nRight = consecutiveCount[right];
		
		int length = nLeft + nRight;
		consecutiveCount[left] = length;
		consecutiveCount[right] = length;
		
		return length;
	}
}

// Define other methods and classes here
