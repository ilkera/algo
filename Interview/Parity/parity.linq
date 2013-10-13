<Query Kind="Program" />

void Main()
{
	Parity.IsEvenParity(13).Dump();
	Parity.IsOddParity(13).Dump();
}

public class Parity
{
	public static bool IsOddParity(int number)
	{
		return FindParity(number) % 2 == 1;
	}
	
	public static bool IsEvenParity(int number)
	{
		return FindParity(number) % 2 == 0;
	}
	
	private static int FindParity(int number)
	{
		int numberOf1s = 0;
		
		while (number != 0)
		{
			if ((number & (number - 1)) == 1)
				numberOf1s++;
				
			number = number & (number - 1);
		}
		
		return numberOf1s;
	}
}

// Define other methods and classes here
