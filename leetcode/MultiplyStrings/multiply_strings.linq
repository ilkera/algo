<Query Kind="Program" />

/* Problem: Multiply Strings

Given two numbers represented as strings, return multiplication of the numbers as a string.

Note: The numbers can be arbitrarily large and are non-negative.

*/
void Main()
{
	MathUtil.Multiply("46", "12").Dump();
}

public class MathUtil
{
	public static string Multiply(string first, string second)
	{	
		if (string.IsNullOrEmpty(first) == true || string.IsNullOrEmpty(second) == true)
		{
			return string.Empty;
		}
		
		int[] resultNum = new int[first.Length + second.Length];
		
		for (int iFirst = first.Length - 1; iFirst >= 0; iFirst--)
		{
			for (int iSecond = second.Length -1; iSecond >= 0; iSecond--)
			{
				resultNum[iFirst + iSecond + 1] += ((int)(first[iFirst] - '0') * (int)(second[iSecond] - '0'));
			}
		}
		
		int carry = 0;
		for (int i = resultNum.Length - 1; i >= 0; i--)
		{
			resultNum[i] += carry;
			carry = resultNum[i] / 10;
			resultNum[i] = resultNum[i] % 10;
		}
		
		StringBuilder result = new StringBuilder();
		bool skipZero = true;
		
		for (int i = 0; i < resultNum.Length; i++)
		{
			if (skipZero == true && resultNum[i] == 0)
			{
				continue;
			}
			else
			{
				result.Append(resultNum[i].ToString());
				skipZero = true;
			}
		}
		
		return result.ToString();
	}
	
}

// Define other methods and classes here
