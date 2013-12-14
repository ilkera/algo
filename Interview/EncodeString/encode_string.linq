<Query Kind="Program" />

void Main()
{
	Console.WriteLine(StringEncoder.Encode("a"));
	Console.WriteLine(StringEncoder.Encode("ab"));
	Console.WriteLine(StringEncoder.Encode("abc"));
	Console.WriteLine(StringEncoder.Encode("aab"));
	Console.WriteLine(StringEncoder.Encode("aabbc"));
	Console.WriteLine(StringEncoder.Encode("aabbbbbccdaa"));
	Console.WriteLine(StringEncoder.Encode("aaaaaaaa"));
	
}

public class StringEncoder
{
	public static string Encode(string input)
	{
		if (string.IsNullOrEmpty(input) == true)
		{
			return string.Empty;
		}
		
		StringBuilder output = new StringBuilder();
		char previous = input[0];
		char current = previous;
		int currentCount = 1;
		int iCurrent = 1;
		
		while (iCurrent < input.Length)
		{
			current = input[iCurrent];
			
			if (current == previous)
			{
				currentCount++;
			}
			else
			{
				output.Append(previous.ToString() + currentCount);
				currentCount = 1;
			}
			
			previous = current;
			iCurrent++;
		}
		
		if (iCurrent == input.Length)
		{
			output.Append(previous.ToString() + currentCount);
		}
		
		return output.ToString();
	}
}

// Define other methods and classes here
