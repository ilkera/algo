<Query Kind="Program" />

/* Problem: Implement strStr

Implement strStr().

Returns a pointer to the first occurrence of needle in haystack, or null if needle is not part of haystack.

*/
void Main()
{
	Console.WriteLine(StringUtils.strStr("This is nice video", "nice"));
}

public class StringUtils
{
	public static string strStr(string str, string pattern)
	{
		if(string.IsNullOrEmpty(str) || string.IsNullOrEmpty(pattern))
		{
			return str;
		}
		
		int strLen= str.Length;
		int patternLen = pattern.Length;
		
		int iCurrent = 0;
		while(iCurrent < strLen- patternLen + 1)
		{
			if(str[iCurrent] != pattern[0])
			{
				iCurrent++;
				continue;
			}
			
			int iSubCurrent = 0;
			while(iSubCurrent < patternLen && str[iCurrent] == pattern[iSubCurrent])
			{
				iCurrent++;
				iSubCurrent++;
			}
			
			if(iSubCurrent == patternLen)
			{
				return str.Substring(iCurrent-iSubCurrent, patternLen);
			}
			iCurrent = iCurrent - iSubCurrent + 1;
		}
		return null;
	}
}

// Define other methods and classes here