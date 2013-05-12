<Query Kind="Program" />

/* Problem: Longest Increasing Subsequence

 the longest increasing subsequence problem is to find a subsequence of a given sequence in which
 the subsequence elements are in sorted order, lowest to highest, and in which the subsequence is as long as possible. 
 This subsequence is not necessarily contiguous, or unique
 
 e.g.
 
 Input: 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15
	
 a longest increasing subsequence is
	
 Output: 0, 2, 6, 9, 13, 15.

*/
void Main()
{
	int[] array = {10, 22, 9, 33, 21, 50, 41, 10};
	Console.WriteLine("Longest increasing subsequence: {0} ",LongestIncreasingSubsequence(array));
}

static int LongestIncreasingSubsequence(int[] array)
{
	if (array == null || array.Length == 0) 
	{
		return 0;
	}
	
	int[] sequenceTrack = new int[array.Length];
	
	for (int i = 0; i < sequenceTrack.Length; i++)
	{
		sequenceTrack[i] = 1;
	}
	
	for (int i = 1; i < array.Length; i++)
	{
		for (int j = 0; j < i; j++)
		{
			if(array[i] > array[j] && sequenceTrack[i] < sequenceTrack[j] + 1)
			{
				sequenceTrack[i] = sequenceTrack[j] + 1;
			}
		}
	}
	
	// Find the max.
	int longest = sequenceTrack[0];
	
	for (int i = 1; i < sequenceTrack.Length; i++)
	{
		if(longest < sequenceTrack[i])
		{
			longest = sequenceTrack[i];
		}
	}
	return longest;
	
}

// Define other methods and classes here