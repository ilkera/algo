<Query Kind="Program" />

void Main()
{
	Console.WriteLine("Input: {0} Result: {1}", "a", IsAnagramOfPalindrome("a"));
	Console.WriteLine("Input: {0} Result: {1}", "aab", IsAnagramOfPalindrome("aab"));
	Console.WriteLine("Input: {0} Result: {1}", "abba", IsAnagramOfPalindrome("abba"));
	Console.WriteLine("Input: {0} Result: {1}", "abcba", IsAnagramOfPalindrome("abcba"));
	Console.WriteLine("Input: {0} Result: {1}", "cabba", IsAnagramOfPalindrome("cabba"));
	
	Console.WriteLine("\nInvalid");
	Console.WriteLine("Input: {0} Result: {1}", "ab", IsAnagramOfPalindrome("ab"));
	Console.WriteLine("Input: {0} Result: {1}", "cabbad", IsAnagramOfPalindrome("cabbad"));
	Console.WriteLine("Input: {0} Result: {1}", "aacddd", IsAnagramOfPalindrome("aacddd"));

}

public static bool IsAnagramOfPalindrome(string input)
{
	if (string.IsNullOrEmpty(input) == true)
	{
		return true;
	}
	
	Dictionary<char, int> charMap = new Dictionary<char, int>();
	
	foreach (var currentChar in input)
	{
		if (charMap.ContainsKey(currentChar) == false)
		{
			charMap.Add(currentChar, 1);
		}
		else
		{
			charMap[currentChar] += 1;
		}
	}
	
	bool hasSeenOddCount = false;
	
	foreach (KeyValuePair<char, int> current in charMap)
	{
		bool isOddCount = current.Value % 2 == 1;
		
		if (isOddCount == true && hasSeenOddCount == false)
		{
			hasSeenOddCount = true;
		}
		else if (isOddCount == true && hasSeenOddCount == true)
		{
			return false;
		}
	}
	
	return true;
}

// Define other methods and classes here
