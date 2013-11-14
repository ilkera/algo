<Query Kind="Program" />

void Main()
{
	var result = PermutationUtil.Permute("abc");
	result.Dump();
}

public class PermutationUtil
{
	public static List<string> Permute(string input)
	{
		List<string> output = new List<string>();
		
		if (string.IsNullOrEmpty(input) == true)
		{
			return output;
		}
		
		StringBuilder buffer = new StringBuilder(input.Length);
		bool[] usedPositions = new bool[input.Length];
		
		PermutationHelper(input, input.Length, ref usedPositions, buffer, 0, ref output);
		
		return output;
	}
	
	private static void PermutationHelper(
	string input,
	int length,
	ref bool[] usedPositions,
	StringBuilder buffer,
	int currentPosition,
	ref List<string> output)
	{
		if (currentPosition == length)
		{
			output.Add(buffer.ToString());
			return;
		}
		
		for (int index = 0; index < input.Length; index++)
		{
			if (usedPositions[index] == true)
			{
				continue;
			}
			
			// Append current fixed char & mark it as used
			char currentFixed = input[index];
			buffer.Append(currentFixed);
			usedPositions[index] = true;
			
			// Permute on the remaining characters
			PermutationHelper(input, length, ref usedPositions, buffer, currentPosition + 1, ref output);
			
			// Remove current fixed char and mark it as unused
			buffer.Remove(buffer.Length - 1, 1);
			usedPositions[index] = false;
		}
	}
}

// Define other methods and classes here
