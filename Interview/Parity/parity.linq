<Query Kind="Program" />

void Main()
{
	Parity.IsEvenParity(13).Dump();
	Parity.IsOddParity(13).Dump();
}

public class Parity
{	
	public static bool IsOddParity(int n)
	{
		return FindParity(n) % 2 == 1;
	}
	
	public static bool IsEvenParity(int n)
	{
		return FindParity(n) % 2 == 0;
	}
	
	private static int FindParity(int n)
	{
		int count = 0;
		while (n != 0)
		{
			count++;
			n &= (n - 1);
		}
		return count;
	}
}

// Define other methods and classes here