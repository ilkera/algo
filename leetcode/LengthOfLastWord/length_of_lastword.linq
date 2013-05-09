<Query Kind="Program" />

/* Problem: Length of Last word

Given a string s consists of upper/lower-case alphabets and empty space characters ' ', return the length of last word in the string.

If the last word does not exist, return 0.

Note: A word is defined as a character sequence consists of non-space characters only.

For example, 
Given s = "Hello World",
return 5.

*/
void Main()
{
	Console.WriteLine(StringUtils.GetLengthOfLastWord("Hello World"));
	Console.WriteLine(StringUtils.GetLengthOfLastWord("Hello"));
}

public class StringUtils
{
	public static int GetLengthOfLastWord(string str)
	{
		if(string.IsNullOrEmpty(str))
		{
			return 0;
		}
		
		int end = str.Length -1;
		
		while(end >= 0 && str[end] == ' ')
		{
			end--;
		}
		
		if(end < 0 )
		{
			return 0;
		}
		
		int start = end - 1;
		
		while(start >= 0 && str[start] != ' ')
		{
			start--;
		}
		
		return end - start;
	}
}

// Define other methods and classes here
