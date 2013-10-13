<Query Kind="Program" />

void Main()
{
	var list = Factors.FindPrimeFactors(105);
//	list.Dump();
	
	Factors.FindFactors(12).Dump();
}

public class Factors
{
	public static List<List<int>> FindFactors(int number)
	{
		var result = new List<List<int>>();
		var currentFactors = new List<int>();
		
		FindFactors(number, 2, ref currentFactors, ref result);
		
		return result;
	}
	
	
	public static List<uint> FindPrimeFactors(uint number)
	{
		HashSet<uint> primeFactors = new HashSet<uint>();
		
		uint nextPrime = 2;
		
		while (number != 1)
		{
			if (IsPrime(nextPrime) == true)
			{
				while (number % nextPrime == 0)
				{
					primeFactors.Add(nextPrime);
					number /= nextPrime;
				}
			}
			
			if (nextPrime == 2) nextPrime = 3;
			else nextPrime += 2;
		}
		
		return primeFactors.ToList();
	}
	
	public static bool IsPrime(uint number)
	{
		if (number < 2)
		{
			return false;
		}
		
		if (number == 2 )
		{
			return true;
		}
		
		uint currentDivisor = 3;
		
		while (currentDivisor < number && number % currentDivisor != 0)
		{
			currentDivisor += 2;
		}
		
		if (currentDivisor == number)
		{
			return true;
		}
		return false;
	}
	
	private static void FindFactors(int number, int currentFactor, ref List<int> currentFactors, ref List<List<int>> result)
	{
		Console.WriteLine("Number: {0} CurrentFactor: {1}", number, currentFactor);
		currentFactors.Dump();
		
		if (number == 1)
		{
			if (currentFactors.Count < 2)
			{
				currentFactors.Add(1);
			}
			
			result.Add(new List<int>(currentFactors));
			currentFactors.Clear();
		}
		else
		{
			while (currentFactor <= number)
			{
				if (number % currentFactor == 0)
				{	
					currentFactors.Add(currentFactor);
					FindFactors(number / currentFactor, currentFactor, ref currentFactors, ref result);
				}
				currentFactor++;
			}
		}
		
	}
}

// Define other methods and classes here