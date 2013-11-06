<Query Kind="Program" />

void Main()
{
	string[] anagrams = { "abc", "cba", "def", "fed", "klm", "bca", "xyz" };
	
	var result = AnagramUtil.FindAnagramBuckets(anagrams);
	
	result.Dump();
}

public class AnagramUtil
{
	public static List<string> FindAnagramBuckets(string[] anagramList)
	{
		if (anagramList == null || anagramList.Length < 1)
		{
			throw new ArgumentNullException("Anagram list null/empty");
		}
		
		Dictionary<string, List<string>> anagramMap = new Dictionary<string, List<string>>();
		
		foreach (var anagram in anagramList)
		{
			var sortedAnagram = Sort(anagram);
			
			if (anagramMap.ContainsKey(sortedAnagram) == false)
			{
				anagramMap.Add(sortedAnagram, new List<string>());	
			}
			anagramMap[sortedAnagram].Add(anagram);
		}
		
		List<KeyValuePair<string, List<string>>> sortedPairs = anagramMap.ToList();
		var output = SortAndGroupAnagrams(ref sortedPairs);
		
		return output;	
	}
	
	private static string Sort(string input)
	{
		char[] charArray = input.ToCharArray();
		Array.Sort(charArray);
		return new string(charArray);
	}
	
	private static List<string> SortAndGroupAnagrams(ref List<KeyValuePair<string, List<string>>> input)
	{
		// Sort keys
		input.Sort((firstPair, secondPair) =>
		{
			return firstPair.Key.CompareTo(secondPair.Key);
		});
		
		List<string> output = new List<string>();
		
		foreach (KeyValuePair<string, List<string>> pair in input)
		{
			List<string> anagramBucket = pair.Value;
			anagramBucket.Sort((first, second) =>
			{
				return first.CompareTo(second);
			});
			
			foreach (var anagram in anagramBucket)
			{
				output.Add(anagram);	
			}
		}
		
		return output;
	}
	
	
}

// Define other methods and classes here
