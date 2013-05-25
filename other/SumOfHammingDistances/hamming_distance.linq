<Query Kind="Program" />

/* Problem : Hamming Distance

the Hamming distance between two strings of equal length is the number of positions at which
the corresponding symbols are different. 

In another way, it measures the minimum number of substitutions required to change one string into the other,
or the minimum number of errors that could have transformed one string into the other.

REF: http://en.wikipedia.org/wiki/Hamming_distance

*/
void Main()
{
	Console.WriteLine("Distance: {0}", HammingDistance.FindDistance("toned", "roses"));
	Console.WriteLine("Distance: {0}", HammingDistance.FindDistance(0x1011101,0x1001001));
}

public class HammingDistance
{
	public static int FindDistance(string firstStr, string secondStr)
	{
		if(string.IsNullOrEmpty(firstStr) == true)
		{
			return string.IsNullOrEmpty(secondStr) ? 0 : secondStr.Length;
		}
		
		if(string.IsNullOrEmpty(secondStr) == true)
		{
			return string.IsNullOrEmpty(firstStr) ? 0 : firstStr.Length;
		}
		
		if(firstStr.Length != secondStr.Length)
		{
			return 0;
		}
		
		int distance = 0;
		int iCurrent = 0;
		
		while(iCurrent < firstStr.Length)
		{
			if(firstStr[iCurrent] != secondStr[iCurrent])
			{
				distance++;
			}
			iCurrent++;
		}
		
		return distance;
	}
	
	public static int FindDistance(long first, long second)
	{
		int distance = 0;
		long value = first ^ second;
		
		while(value != 0)
		{
			distance++;
			value &= value -1;
		}
		
		return distance;
	}
}

// Define other methods and classes here
