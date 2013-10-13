<Query Kind="Program" />

void Main()
{
	string str = "This is a test\0\0\0\0\0\0\0\0\0\0";
	
	List<char> test = new List<char>(25);
	test.AddRange(str.ToCharArray());
	
	ReplaceBlanks(test);
	
	test.Dump();
	
//	original.Length.Dump();
}

public static void ReplaceBlanks(List<char> input)
{
	if (input == null || input.Count < 1)
	{
		return;
	}
	
	int numSpace = 0;
	int iCurrent = 0;
	
	while (iCurrent < input.Count)
	{
		if (input[iCurrent] == ' ')
		{
			numSpace++;
		}
		else if (input[iCurrent] == '\0')
		{
			break;
		}
		
		iCurrent++;
	}
	
	int originalLength = iCurrent + 1;
	int newLength = originalLength + (2 * numSpace);

	if (newLength > input.Capacity)
	{
		return;
	}
	
	int iNew = newLength - 1;
	int iOriginal = originalLength - 1;
	
	while (iOriginal >= 0 && iNew > iOriginal)
	{	
		if (input[iOriginal] == ' ')
		{
			input[iNew--] = '0';
			input[iNew--] = '2';
			input[iNew--] = '%';
		}
		else
		{
			input[iNew--] = input[iOriginal];
		}
		
		iOriginal--;
	}
}

// Define other methods and classes here
