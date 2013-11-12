<Query Kind="Program" />

void Main()
{
	MaxSizeSubstringUniqueChars("efabcah123456").Dump();
}

public static string MaxSizeSubstringUniqueChars(string input)
{
	if (string.IsNullOrEmpty(input) == true)
	{
		throw new ArgumentNullException("Empty/null string");
	}
	
	Dictionary<char, int> charMap = new Dictionary<char, int>();
	int start = 0;
	string currentSubstring = string.Empty;
	string maxSubstring = string.Empty;
	
	for (int index = 0; index < input.Length; index++)
	{
		char current = input[index];
		
		if (charMap.ContainsKey(current) == false)
		{
			charMap.Add(current, index);
		}
		else
		{
			currentSubstring = input.Substring(start, index - start);
			
			if (currentSubstring.Length > maxSubstring.Length)
			{
				maxSubstring = currentSubstring;
			}
			
			start = charMap[current] + 1;
			index = start - 1;
			charMap.Clear();
		}
		
		if (index + 1 == input.Length)
		{
			currentSubstring = input.Substring(start, input.Length - start);
			if (currentSubstring.Length > maxSubstring.Length)
			{
				maxSubstring = currentSubstring;
			}
		}
	}
	
	return maxSubstring;
}

// Define other methods and classes here
