<Query Kind="Program" />

void Main()
{
	GetFirstNonRepeatingChar("abcaddb").Dump();
	GetFirstNonRepeatingChar("abcbdcdb").Dump();
	GetFirstNonRepeatingChar("abcaddbc").Dump();
}

public static char GetFirstNonRepeatingChar(string input)
{
	if (string.IsNullOrEmpty(input) == true)
	{
		throw new ArgumentNullException("empty/null input");
	}
	
	Dictionary<char, int> charCountMap = new Dictionary<char, int>();
	
	for (int iCurrent = 0; iCurrent < input.Length; iCurrent++)
	{
		if (charCountMap.ContainsKey(input[iCurrent]) == true)
		{
			charCountMap[input[iCurrent]] += 1;
		}
		else
		{
			charCountMap.Add(input[iCurrent], 1);
		}
	}
	
	char firstNonRepeating = ' ';
	
	for (int iCurrent = 0; iCurrent < input.Length; iCurrent++)
	{
		if (charCountMap[input[iCurrent]] == 1)
		{
			firstNonRepeating = input[iCurrent];
			break;
		}
	}
	
	return firstNonRepeating;
}

// Define other methods and classes here
