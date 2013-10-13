<Query Kind="Program" />

/* Problem: Word Segmentation

Given an input string and a dictionary of words, segment the input string into a space-separated
sequence of dictionary words if possible.

For example, if the input string is "applepie" and dictionary contains a standard set of English words,
then we would return the string "apple pie" as output.

*/


void Main()
{
	HashSet<string> dict = new HashSet<string>();
	dict.Add("apple");
	dict.Add("pie");
	dict.Add("is");
	dict.Add("good");
	
	Segmentation.Segment_v1("applepie", dict).Dump();
	Segmentation.Segment_v1("applepieisgood", dict).Dump();
	Segmentation.Segment_v2("applepieisgood", ref dict).Dump();
	Segmentation.Segment_v3("applepieisgood", ref dict).Dump();
}

public class Segmentation
{
	// Naive simple solution for two words.
	public static string Segment_v1(string input, HashSet<string> dict)
	{
		if (string.IsNullOrEmpty(input) == true)
		{
			return null;
		}
		
		int inputLength = input.Length;
		
		for (int i = 1; i < inputLength; i++)
		{
			string prefix = input.Substring(0, i);
			
			if (dict.Contains(prefix) == true)
			{
				string suffix = input.Substring(i);
				
				if (dict.Contains(suffix) == true)
				{
					return prefix + " " + suffix;
				}
			}
		}
		
		return null;
	}
	
	// General solution. Example string may contain multiple words to be segmented.
	// Running time: Exponential as the function tries to find all possible solution (powerset)
	// Consider the input: aaaaab where dict. "a", "aa", "aaa", "aaaa", "aaaaa" ..
	public static string Segment_v2(string input, ref HashSet<string> dict)
	{	
		if (string.IsNullOrEmpty(input) == true)
		{
			return null;
		}
		
		if (dict.Contains(input) == true)
		{
			return input;
		}
		
		int inputLength = input.Length;
		
		for (int i = 1; i < inputLength; i++)
		{
			string prefix = input.Substring(0, i);
			if (dict.Contains(prefix) == true)
			{
				string suffix = input.Substring(i);
				string segmentedSuffix = Segment_v2(suffix, ref dict);
				
				if (segmentedSuffix != null)
				{
					return prefix + " " + segmentedSuffix;
				}
			}
		}
		
		return null;
	}
	
	// Optimization
	// Running time: O(n3)
	private static HashSet<string> _memoized = new HashSet<string>();
	
	public static string Segment_v3(string input, ref HashSet<string> dict)
	{
		if (string.IsNullOrEmpty(input) == true || _memoized.Contains(input) == true)
		{
			return null;
		}
		
		if (dict.Contains(input) == true)
		{
			return input;
		}
		
		int inputLength = input.Length;
		
		for (int i = 1; i < inputLength; i++)
		{
			string prefix = input.Substring(0, i);
			if (dict.Contains(prefix) == true)
			{
				string suffix = input.Substring(i);
				string segmentedSuffix = Segment_v2(suffix, ref dict);
				
				if (segmentedSuffix != null)
				{
					return prefix + " " + segmentedSuffix;
				}
			}
		}
		_memoized.Add(input);
		return null;
	}
}


// Define other methods and classes here
