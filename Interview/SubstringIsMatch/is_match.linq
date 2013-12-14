<Query Kind="Program" />

void Main()
{
	IsMatch("This is a quick test", "qck").Dump();
}

public static bool IsMatch(string text, string pattern)
{
	if (string.IsNullOrEmpty(text) == true || string.IsNullOrEmpty(pattern) == true)
	{
		return false;
	}
	
	int iCurrentText = 0;
	int iCurrentPattern = 0;
	
	while (iCurrentText < text.Length)
	{
		char current = text[iCurrentText];
		if (current == pattern[iCurrentPattern])
		{
			iCurrentPattern++;
		}
		
		iCurrentText++;

		if (iCurrentPattern == pattern.Length)
		{
			break;
		}
	}
	
	if (iCurrentPattern == pattern.Length)
	{
		return true;
	}
	
	return false;
}

// Define other methods and classes here
