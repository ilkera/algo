<Query Kind="Program" />

/* Problem: 

Given an input string and a dictionary of words, segment the input string into a space-separated
sequence of dictionary words if possible.

For example, if the input string is "applepie" and dictionary contains a standard set of English words,
then we would return the string "apple pie" as output.
*/

void Main()
{
	HashSet<string> dict = new HashSet<string>();
	dict.Add("this");
	dict.Add("is");
	dict.Add("shorter");

	HashSet<string> cache = new HashSet<string>();
	string result = StringUtils.Segment_v3("thisisshorter", dict, cache);
	result.Dump();
}

public class StringUtils
{
	// v2 with Cache - Dynamic Programming
	public static string Segment_v3(string input, HashSet<string> dict, HashSet<stsring> cache)
	{
		if (string.IsNullOrEmpty(input) == true || dict.Contains(input) == true)
		{
			return input;
		}
		
		if (cache.Contains(input) == true)
		{	
			return null;
		}
		
		int inputLen = input.Length;
		
		for (int i = 1; i < inputLen; i++)
		{
			string prefix = input.Substring(0, i);
			
			if (dict.Contains(prefix) == true)
			{
				string suffix = input.Substring(i, inputLen - i);
				
				string segmentedSuffix = Segment_v3(suffix, dict, cache);
				
				if(string.IsNullOrEmpty(segmentedSuffix) == false)
				{
					return prefix + " " + segmentedSuffix;
				}
			}
		}
		
		cache.Add(input);
		return null;
	}
	
	// General case
	public static string Segment_v2(string input, HashSet<string> dict)
	{
		if (string.IsNullOrEmpty(input) == true || dict.Contains(input) == true)
		{
			return input;
		}
		
		int inputLen = input.Length;
		
		for (int i = 1; i < inputLen; i++)
		{
			string prefix = input.Substring(0, i);
			
			if (dict.Contains(prefix) == true)
			{
				string suffix = input.Substring(i, inputLen - i);
				
				string segmentedSuffix = Segment_v2(suffix, dict);
				
				if(string.IsNullOrEmpty(segmentedSuffix) == false)
				{
					return prefix + " " + segmentedSuffix;
				}
			}
		}
		
		return null;
		
	}
		
	// Fpr two word case
	public static string Segment_v1(string input, HashSet<string> dict)
	{
		if (string.IsNullOrEmpty(input) == true)
		{
			return null;
		}
		
		int inputLen = input.Length;
		
		for (int i = 1; i < inputLen; i++)
		{
			string prefix = input.Substring(0, i);
			
			if (dict.Contains(prefix) == true)
			{
				string suffix = input.Substring(i, inputLen - i);
				
				if (dict.Contains(suffix) == true)
				{
					return prefix + " " + suffix;
				}
			}
		}
		
		return null;
	}
}

// Define other methods and classes here
