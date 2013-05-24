<Query Kind="Program" />

/* Problem: Permutations of string

*/

void Main()
{
	List<string> result = Permutation.FindPermutations("abc");
	
	result.Dump();
}

public class Permutation
{
	public static List<string> FindPermutations(string str)
	{
		List<string> result = new List<string>();
		
		if(string.IsNullOrEmpty(str) == true)
		{
			return result;
		}
		
		StringBuilder sb = new StringBuilder(str);
		FindPermutations(sb, 0, "", result);
		
		return result;
	}
	
	private static void FindPermutations(StringBuilder str, int iCurrent, string current, List<string> result)
	{
		if(iCurrent == str.Length)
		{
			string perm = String.Copy(current);
			result.Add(perm);
			return;
		}
		
		for (int i = iCurrent; i < str.Length; i++)
		{
			Swap(str, iCurrent, i);
			FindPermutations(str, iCurrent + 1, current + str[iCurrent].ToString(), result);
			Swap(str, iCurrent, i);
		}
	}
	
	private static void Swap(StringBuilder str, int index, int change)
	{
		char temp = str[index];
		str[index] = str[change];
		str[change] = temp;
	}
}

// Define other methods and classes here
