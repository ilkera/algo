<Query Kind="Program" />

/* Problem: Anagrams

Given an array of strings, return all groups of strings that are anagrams.

Note: All inputs will be in lower-case.

*/

void Main()
{
	List<string> strings = new List<string>{ "abc", "def", "xyz", "bac", "fed", "cab", "zxy" };
	
	strings.Dump();
	
	List<string> groupedAnagrams = Anagram.GroupByAnagrams(strings);
	
	groupedAnagrams.Dump();
}

public class Anagram
{
	public static List<string> GroupByAnagrams(List<string> listOfStrings)
	{
		if(listOfStrings == null || listOfStrings.Count == 0)
		{
			return null;
		}
		
		Dictionary<string, List<string>> anagramMap = new Dictionary<string, List<string>>();
		
		foreach (var str in listOfStrings)
		{
			string sorted = Sort(str);
			
			if(anagramMap.ContainsKey(sorted) == false)
			{
				anagramMap.Add(sorted, new List<string>());
			}
			anagramMap[sorted].Add(str);
		}
		
		List<string> result = new List<string>();
		
		foreach (KeyValuePair<string, List<string>> anagram in anagramMap)
		{
			if(anagram.Value.Count > 1)
			{
				foreach (var element in anagram.Value)
				{
					result.Add(element);
				}
			}
			else
			{
				result.Add(anagram.Value[0]);
			}
		}
		
		return result;
	}
	
	private static string Sort(string str)
	{
		if(string.IsNullOrEmpty(str) == true || str.Length < 2)
		{
			return str;
		}
		
		char[] toArray = str.ToCharArray();
		Array.Sort(toArray);
		
		return new string(toArray);
	}
}

// Define other methods and classes here
