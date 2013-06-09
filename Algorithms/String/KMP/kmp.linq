<Query Kind="Program" />

void Main()
{
	KMP.Search("abacaabaccabacabaabb", "abacab").Dump();
}

public class KMP
{
	public static int Search(string text, string pattern)
	{
		if (string.IsNullOrEmpty(text) == true || string.IsNullOrEmpty(pattern) == true)
		{
			return -1;
		}
		
		int textSize = text.Length;
		int patternSize = pattern.Length;
		
		if (patternSize > textSize)
		{
			return -1;
		}
		
		int[] kmpNext = ComputeKmpPrefix(pattern);
		int tIdx = 0;
		int pIdx = 0;
		
		while(tIdx < textSize)
		{
		 	if (pattern[pIdx] == text[tIdx])
			{
				if (pIdx == patternSize - 1)
				{
					return tIdx - (patternSize - 1);
				}
				tIdx++;
				pIdx++;
			}
			else if (pIdx > 0)
			{
			 	pIdx = kmpNext[pIdx - 1];
			}
			else
			{
				tIdx++;
			}
		}
		
		return -1;
	}
	
	private static int[] ComputeKmpPrefix(string pattern)
	{
		int patternSize = pattern.Length;
		int[] kmpNext = new int[patternSize];
		
		int prefixPos = 0;
		int suffixPos = 1;
		
		while (suffixPos < patternSize)
		{
			if (pattern[prefixPos] == pattern[suffixPos])
			{
				kmpNext[suffixPos] = prefixPos + 1;
				prefixPos++;
				suffixPos++;
			}
			else if (prefixPos > 0)
			{
				prefixPos = kmpNext[prefixPos - 1];
			}
			else
			{
				kmpNext[suffixPos] = 0;
				suffixPos++;
			}
		}
		
		return kmpNext;
	}
}

// Define other methods and classes here
