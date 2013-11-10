<Query Kind="Program" />

void Main()
{
	int[] array = {10, 22, 9, 33, 21, 50, 41, 60, 80};
	
	Console.WriteLine("Longest Increasing Subsequence Length: " + LongestIncreasingSubseqeunce.Longest(array));
}

public class LongestIncreasingSubseqeunce
{
	public static int Longest(int[] array)
	{
		if (array == null || array.Length < 1)
		{
			return 0;
		}
		
		int bestEnd = 0;
		int maxLength = 1;
		int[] sequenceLengths = new int[array.Length];
		int[] sequence = new int[array.Length];
		
		sequenceLengths[0] = 1;
		sequence[0] = -1;
		
		for (int i = 1; i < array.Length; i++)
		{
			sequenceLengths[i] = 1;
			sequence[i] = -1;
			
			for (int j = i - 1; j >= 0; j--)
			{
				if (array[i] > array[j] && sequenceLengths[i] < sequenceLengths[j] + 1)
				{
					sequenceLengths[i] = sequenceLengths[j] + 1;
					sequence[i] = j;
				}
			}
			
			if (sequenceLengths[i] > maxLength)
			{
				maxLength = sequenceLengths[i];
				bestEnd = i;
			}
		}
		
		
		for (int iCurrent = bestEnd; iCurrent != -1; iCurrent = sequence[iCurrent])
		{
			Console.Write("{0}, ", array[iCurrent]);	
		}
		
		return maxLength;
	}
}

// Define other methods and classes here