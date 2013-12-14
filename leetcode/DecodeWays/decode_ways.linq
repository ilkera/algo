<Query Kind="Program" />

void Main()
{
//	DecodeWays("12").Dump();
	DecodeWays("121212").Dump();
	DecodeWays_Optimized("121").Dump();
	DecodeWays_Optimized("12100").Dump();
	DecodeWays_Optimized("1").Dump();
	// 1-210, 12-10, 
	// 1- 2 - 10
	// 12 - 10
//	DecodeWays("333230").Dump();
	
}

public static int DecodeWays(string input)
{
	if (string.IsNullOrEmpty(input) == true)
	{
		return 0;
	}
	
	List<int?> cache = new List<int?>(input.Length);
	
	for (int i = 0; i < input.Length; i++)
	{
		cache.Add(null);
	}
	
	int totalPossibleWays = DecodeWaysHelper(input, ref cache);
	
	return totalPossibleWays;
}

private static int DecodeWaysHelper(string input, ref List<int?> cache)
{
	if (string.IsNullOrEmpty(input) == true)
	{
		return 1;
	}
	
	if (cache[input.Length - 1] != null)
	{
		return cache[input.Length - 1].Value;
	}
	
	int currentPossibleWays = 0;
	
	if (input.Length > 1)
	{
		int number = Convert.ToInt32(input.Substring(0, 2));
		if (number > 0 && number < 27)
		{
			currentPossibleWays = DecodeWaysHelper(input.Substring(2), ref cache);
		}
	}
	
	currentPossibleWays += DecodeWaysHelper(input.Substring(1), ref cache);
	cache[input.Length - 1] = currentPossibleWays;
	
	return currentPossibleWays;
}

public static int DecodeWays_Optimized(string input)
{
	if (string.IsNullOrEmpty(input) == true || input[0] == '0')
	{
		return 0;
	}
	
	int result = 1;
	int previous = 1;

	for (int index = 1; index < input.Length; index++)
	{	
		int temp = result;
		if (input[index] == '0')
		{
			result = 0;	
		}
		
		int number = Convert.ToInt32(input[index - 1].ToString()) * 10 + Convert.ToInt32(input[index].ToString());
		if (number >= 10 && number <= 26)
		{
			result += previous;
		}
		previous = temp;
		
		if (result == 0 && previous == 0)
		{
			return 0;
		}
	}
	
	return result;
}

// Define other methods and classes here