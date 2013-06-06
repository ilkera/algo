<Query Kind="Program" />

/* Problem: Longest Common Subsequence */ 
void Main()
{
	string first = "CATCGA";
	string second = "GTACCGTCA";
	
	string lcs = LongestCommonSubsequence.FindLCS(first, second);
	
	lcs.Dump();
}

public class LongestCommonSubsequence
{
	public static string FindLCS(string first, string second)
	{
		if(string.IsNullOrEmpty(first) == true || string.IsNullOrEmpty(second) == true)
		{
			return string.Empty;
		}
		
		int[,] lcsTable = new int[first.Length, second.Length];
		
		ComputeLCSTable(ref first, ref second, ref lcsTable);
		
		string result = GetLCS(ref first, ref second, first.Length -1, second.Length -1, ref lcsTable);
		
		return result;
	}
	
	private static string GetLCS(ref string first, ref string second, int iFirst, int iSecond, ref int[,] lcsTable)
	{
		string result = string.Empty;
		
		if(iFirst < 1 || iSecond < 1)
		{
			return result;
		}
		
		if(first[iFirst].Equals(second[iSecond]) == true)
		{
			result = GetLCS(
					ref first, 
					ref second,
					iFirst - 1,
					iSecond - 1,
					ref lcsTable);
					
			result = string.Concat(result, first[iFirst].ToString());
		}
		else
		{
			if(lcsTable[iFirst, iSecond - 1] >= lcsTable[iFirst - 1, iSecond])
			{
				result = GetLCS(
					ref first, 
					ref second,
					iFirst,
					iSecond - 1,
					ref lcsTable);
			}
			else
			{
				result = GetLCS(
					ref first, 
					ref second,
					iFirst - 1,
					iSecond,
					ref lcsTable);
			}
		}
		
		return result;
	}
	
	private static void ComputeLCSTable(ref string first, ref string second, ref int[,] lcsTable)
	{
		for (int i = 0; i < first.Length; i++)
		{
			lcsTable[i, 0] = 0;
		}
		
		for (int i = 0; i < second.Length; i++)
		{
			lcsTable[0, i] = 0;
		}
		
		for (int iFirst = 1; iFirst < first.Length; iFirst++)
		{
			for (int iSecond = 1; iSecond < second.Length; iSecond++)
			{
				if(first[iFirst].Equals(second[iSecond]) == true)
				{
					lcsTable[iFirst, iSecond] = lcsTable[iFirst -1, iSecond -1] + 1;
				}
				else
				{
					lcsTable[iFirst, iSecond] = Math.Max(lcsTable[iFirst -1, iSecond], lcsTable[iFirst, iSecond -1]);
				}
			}
		}
	}
}

// Define other methods and classes here
