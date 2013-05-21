<Query Kind="Program" />

/* Problem: Letter Combinations of Phone Number 

Given a digit string, return all possible letter combinations that the number could represent.

A mapping of digit to letters (just like on the telephone buttons) is given below.

Input:Digit string "23"
Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].

Note:
Although the above answer is in lexicographical order, your answer could be in any order you want.

Telephone words

*/
void Main()
{
	List<string> result = PhoneNumberUtils.FindLetterCombinations("23");
	
	result.Dump();
}

public class PhoneNumberUtils
{
	private static List<string> keypad = new List<string> {"abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"};
	
	public static List<string> FindLetterCombinations(string digits)
	{
		List<string> result = new List<string>();
		
		if(string.IsNullOrEmpty(digits) == true)
		{
			return result;
		}
		
		FindLetterCombinationsHelper(digits, 0, "", result);
		return result;
	}
	
	private static void FindLetterCombinationsHelper(string digits, int currentDigitIndex, string currentCombination, List<string> result)
	{
		if( currentDigitIndex == digits.Length)
		{
			result.Add(currentCombination);
			return;
		}
		
		int keyPadIndex = digits[currentDigitIndex] - '2';
		
		for (int i = 0; i < keypad[keyPadIndex].Length; i++)
		{
			FindLetterCombinationsHelper(
			digits,
			currentDigitIndex + 1,
			string.Concat(currentCombination, keypad[keyPadIndex][i].ToString()),
			result);
		}
	}
}

// Define other methods and classes here