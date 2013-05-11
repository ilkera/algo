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
	public static string strStr(string str, string subStr)
	{
		if(string.IsNullOrEmpty(str) || string.IsNullOrEmpty(subStr))
		{
			if (str.Equals(subStr) == true)
			{
				return str;
			}
			return null;
		}
		
		int lenStr = str.Length;
		int lenSubStr = subStr.Length;
		
		int iCurrent = 0;
		while(iCurrent < lenStr - lenSubStr + 1)
		{
			if(str[iCurrent] != subStr[0])
			{
				iCurrent++;
				continue;
			}
			
			int iSubCurrent = 0;
			while(iSubCurrent < lenSubStr && str[iCurrent] == subStr[iSubCurrent])
			{
				iCurrent++;
				iSubCurrent++;
			}
			
			if(iSubCurrent == lenSubStr)
			{
				return str.Substring(iCurrent-iSubCurrent, lenSubStr);
			}
		}
		return null;
	}
}

// Define other methods and classes here
