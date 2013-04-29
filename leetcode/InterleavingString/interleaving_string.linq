<Query Kind="Program" />

/* Problem: Interleaving String

Given s1, s2, s3, find whether s3 is formed by the interleaving of s1 and s2.

For example,
Given:
s1 = "aabcc",
s2 = "dbbca",

When s3 = "aadbbcbcac", return true.
When s3 = "aadbbbaccc", return false.

*/

void Main()
{
	string s1 = "aabcc";
	string s2 = "dbbca";
	string s3 = "aadbbcbcac";
	
	Console.WriteLine("Is interleaving? {0}", InterleavingString.IsInterleaving(s1,s2,s3));
}

public class InterleavingString
{
	public static bool IsInterleaving(string first, string second, string interleaving)
	{
		if(string.IsNullOrEmpty(first) && string.IsNullOrEmpty(second))
		{
			return string.IsNullOrEmpty(interleaving);
		}
		
		if(string.IsNullOrEmpty(interleaving))
		{
			return false;
		}
		
		if(string.IsNullOrEmpty(first))
		{
			return String.Equals(second, interleaving);
		}
		
		if(string.IsNullOrEmpty(second))
		{
			return String.Equals(first, interleaving);
		}
		
		HashSet<string> cache = new HashSet<string>();
		
		return IsInterleaving(first, second, interleaving, cache);
	}
	
	private static bool IsInterleaving(string first, string second, string interleaving, HashSet<string> cache)
	{
		Console.WriteLine("First: {0} Second: {1} Interleaving: {2}", first, second, interleaving);
		
		if(cache.Contains(string.Concat(first, second)) == true)
		{
			return false;
		}
		
		if(first.Length + second.Length != interleaving.Length)
		{
			return false;
		}
		
		if(first == string.Empty || second == string.Empty)
		{
			return String.Equals(first + second, interleaving);
		}
		
		if(interleaving[0] != first[0] && interleaving[0] != second[0])
		{
			return false;
		}
		
		if(interleaving[0] == first[0] && IsInterleaving(first.Substring(1), second, interleaving.Substring(1), cache))
		{
			return true;
		}
		
		if(interleaving[0] == second[0] && IsInterleaving(first, second.Substring(1), interleaving.Substring(1), cache))
		{
			return true;
		}
		
		cache.Add(string.Concat(first, second));
		
		return false;
	}
}

// Define other methods and classes here