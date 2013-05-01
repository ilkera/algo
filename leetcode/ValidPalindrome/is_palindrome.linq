<Query Kind="Program" />

/* Problem: Valid Palindrome

Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.

For example,
"A man, a plan, a canal: Panama" is a palindrome.
"race a car" is not a palindrome.

Note:
Have you consider that the string might be empty? This is a good question to ask during an interview.

For the purpose of this problem, we define empty string as valid palindrome.

*/

void Main()
{
	Console.WriteLine(Palindrome.IsPalindrome("race a car"));
	Console.WriteLine(Palindrome.IsPalindrome("racecar"));
	Console.WriteLine(Palindrome.IsPalindrome("Madam I'm Adam"));
	Console.WriteLine(Palindrome.IsPalindrome("A man, a plan, a canal: Panama"));
	
}

public class Palindrome
{
	public static bool IsPalindrome(string str)
	{
		if(string.IsNullOrEmpty(str) == true || str.Length < 2)
		{
			return true;
		}
		
		int iLeft = 0;
		int iRight = str.Length -1;
		
		while(iLeft < iRight)
		{
			if(IsAlphaNumeric(str[iLeft]) == false)
			{
				iLeft++;
				continue;
			}
			
			if(IsAlphaNumeric(str[iRight]) == false)
			{
				iRight--;
				continue;
			}
			
			int value = (int) str[iLeft] - (int) str[iRight];
			if(value != 0 && Math.Abs(value) != 32) /* A = 65, a = 97 (diff is 32) */
			{
				return false;
			}
			
			iLeft++;
			iRight--;
		}
		
		return true;
	}
	
	private static bool IsAlphaNumeric(char ch)
	{
		if (ch >= 'a' && ch <='z'  ||
			ch >= 'A' && ch <= 'Z' ||
			ch >= '0' && ch <='9')
		{
			return true;
		}
		
		return false;
	}
}

// Define other methods and classes here
