<Query Kind="Program" />

void Main()
{
	var combinations = Combination.Combine("abc");
	combinations.Dump();
}

public class Combination
{
	public static List<string> Combine(string str)
	{
		List<string> output = new List<string>();
		
		if (string.IsNullOrEmpty(str) == true)
		{
			return output;
		}
		
		StringBuilder buffer = new StringBuilder(str.Length);
		CombinationHelper(str, str.Length, buffer, 0 ,ref output);
		
		return output;
	}
	
	private static void CombinationHelper(
	string str,
	int length,
	StringBuilder buffer, 
	int iSelectionBegin,
	ref List<string> output)
	{
		if (iSelectionBegin == length)
		{
			return;
		}
		
		for (int index = iSelectionBegin; index < str.Length; index++)
		{
			// Add current char to buffer and output
			char current = str[index];
			buffer.Append(current);
			output.Add(buffer.ToString());
			
			// Call combination helper for the remaining chars
			CombinationHelper(str, length, buffer, index + 1, ref output);
			
			// Remove character from buffer
			buffer.Remove(buffer.Length - 1, 1);
		}
	}
}

// Define other methods and classes here
