<Query Kind="Program" />


static void Test(string[] input)
{
	int newLength;
	RemoveNullsInPlace(input, out newLength);
	
	Console.WriteLine("New length: " + newLength);
	input.Dump();
}


void Main()
{
	//Test(new string[] {"", "a", "", "b", "", "c", "", ""});
	//Test(new string[] {"x", "a", "y", "b", "z", "c", "t", "k"});
	Test(new string[] {"x", "a", "y", "", "z", "c", "t", "k"});
}

public static void RemoveNullsInPlace(string[] words, out int newLength)
{
	newLength = 0;
	
	if (words == null || words.Length < 1)
	{
		return;
	}
	
	int iNullBegin = -1;
	
	for (int iCurrent = 0; iCurrent < words.Length; iCurrent++)
	{
		if (string.IsNullOrEmpty(words[iCurrent]) == true)
		{
			if (iNullBegin == -1)
			{
				iNullBegin = iCurrent;
			}
			continue;
		}

		if (iNullBegin >= 0)
		{
			// optimization: only copy items if you have seen at least 1 null
			string temp = words[iNullBegin];
			words[iNullBegin++] = words[iCurrent];
			words[iCurrent] = temp;
		}
	}
	// iNullBegin == -1, when there is no null items in the list
	newLength = iNullBegin != -1 ? iNullBegin : words.Length;
}

// Define other methods and classes here
