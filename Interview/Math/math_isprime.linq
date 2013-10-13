<Query Kind="Program" />

void Main()
{
	for (int i = 0; i < 1000; i++)
	{
		if (PrimeNumber.IsPrimeNaive(i) == true)
		{
		//	Console.WriteLine("(Naive) Number: {0} is prime", i);
		}
	}
	
	PrimeNumber.IsPrimeSieve(15).Dump();
	PrimeNumber.IsPrimeSieve(17).Dump();
}

public class PrimeNumber
{
	public static bool IsPrimeNaive(int number)
	{
		if (number < 2) return false;	
		if (number == 2) return true;
		if (number % 2 == 0) return false;
		
		for (int iCurrent = 3; iCurrent < Math.Sqrt(number); iCurrent += 2)
		{
			if (number % iCurrent == 0)
			{
				return false;
			}
		}
		
		return true;
	}
	
	public static bool IsPrimeSieve(int number)
	{
		if (number < 2) return false;	
		
		bool[] primes = new bool[number + 1];
		for (int i = 2; i < primes.Length; i++)
		{
			primes[i] = true;
		}
		
		for (int i = 2; i <= Math.Sqrt(number); i++)
		{
			if (primes[i] == true)
			{
				int multiple = i * 2;
				while (multiple <= number)
				{
					primes[multiple] = false;
					multiple += i;
				}
			}
		}
		
		return primes[number];
	}
}

// Define other methods and classes here
