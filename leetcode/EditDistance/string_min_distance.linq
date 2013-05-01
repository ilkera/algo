<Query Kind="Program" />

/* 
Problem: String Min Distance

Given two words word1 and word2, find the minimum number of steps required to convert word1 to word2. (each operation is counted as 1 step.)

You have the following 3 operations permitted on a word:

a) Insert a character
b) Delete a character
c) Replace a character

http://en.wikipedia.org/wiki/Levenshtein_distance

*/

void Main()
{
	Console.WriteLine("Min distance: {0}", MinDistance.GetMinDistance("INTENTION","EXECUTION"));
}


public class MinDistance
{	
	public static int GetMinDistance(string first, string second)
	{
		int distance = 0;
		
		if(string.IsNullOrEmpty(first) && string.IsNullOrEmpty(second))
		{
			return distance;
		}
		
		if(string.IsNullOrEmpty(first))
		{
			return second.Length;
		}
		
		if(string.IsNullOrEmpty(second))
		{
			return first.Length;
		}
		
		int[,] dist = new int[first.Length + 1, second.Length + 1];
		
		// Initialization
		for (int i = 0; i <= first.Length; i++)
		{
			dist[i,0] = i;
		}
		
		for (int j = 0; j <= second.Length; j++)
		{
			dist[0,j] = j;
		}
		
		for (int iFirst = 1; iFirst <= first.Length; iFirst++)
		{
			for (int iSecond = 1; iSecond <= second.Length; iSecond++)
			{
				if(first[iFirst - 1] != second[iSecond - 1])
				{
					int deletion = dist[iFirst-1, iSecond] + 1;
					int insertion = dist[iFirst, iSecond - 1] + 1;
					int subsitution = dist[iFirst-1, iSecond-1] + 1;
					
					dist[iFirst,iSecond] = Math.Min(subsitution, Math.Min(deletion, insertion));
				}
				else
				{
					dist[iFirst,iSecond] = dist[iFirst-1, iSecond-1];
				}
			}
		}
		
		distance = dist[first.Length-1, second.Length-1];
		dist.Dump();
		return distance;
	}
}
// Define other methods and classes here