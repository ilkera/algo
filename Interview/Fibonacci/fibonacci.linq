<Query Kind="Program" />

/* Fibonacci Sequence

n == 0 Fibo(n) = 0
n == 1 Fibo(n) = 1
n > 1, Fibo(n) = Fibo(n-1) + Fibo(n-2)


*/
void Main()
{
	Fibonacci.NaiveRecursiveFibo(5).Dump();
	Fibonacci.Memoization(5).Dump();
	Fibonacci.Iterative(5).Dump();
	Fibonacci.TailRecursion(5).Dump();
	Fibonacci.DirectComputation(5).Dump();
}

public class Fibonacci
{
	// Running time: exponential.
	// It's doing the same work over again and again.
	// For example; For n = 8, it calculates, it calculates fibo(5) twice
	// For lower numbers, it's more significant. Same value is calculated multiple times.
	public static uint NaiveRecursiveFibo(uint number)
	{
		if (number == 0 || number == 1)
		{
			return number;
		}
		
		return NaiveRecursiveFibo(number - 1) + NaiveRecursiveFibo(number - 2);
	}
	
	// We can solve the problem of doing work multiple times with memoization.
	// We simply store the intermediary calculations to use again later
	// Running time: Linear O(n), Storage: O(n)
	public static uint Memoization(uint number)
	{
		List<uint> cache = new List<uint>();
		cache.Add(0); // for n = 0
		cache.Add(1); // for n = 1
		
		for (int i = 2; i <= number; i++)
		{
			cache.Add(cache[i-1] + cache[i-2]);
		}
		
		return cache[(int)number];
	}
	
	// We do not need to do full memoization. Only last two entries need to be recorded.
	// We can save storage by keeping track of the last two entries only
	// Running time: Linear O(n). Storage O(1)
	public static uint Iterative(uint number)
	{
		if (number == 0 || number == 1)
		{
			return number;
		}
		
		uint first = 0;
		uint second = 1;
		uint result = 0;
		
		for (int i = 2; i <= number; i++)
		{
			result = first + second;
			first = second;
			second = result;
		}
		
		return result;
	}
	
	// Running time: O(n)
	public static uint TailRecursion(uint number)
	{
		if (number == 0)
		{
			return 0;
		}
		return TailRecursionHelper(number, 0, 1);
	}
	
	// Running time: O(logn) bound to pow and sqrt
	public static uint DirectComputation(uint number)
	{
		double positive_golden_ratio = 1 + Math.Sqrt(5);
		double negative_golden_ratio = 1 - Math.Sqrt(5);
		
		double pos_pow = Math.Pow(positive_golden_ratio, number);
		double neg_pow = Math.Pow(negative_golden_ratio, number);
		
		double numerator = pos_pow - neg_pow;
		double denominator = Math.Pow(2, number) * Math.Sqrt(5);
		
		return (uint)(numerator/denominator);
	}
	
	private static uint TailRecursionHelper(uint current, uint first, uint second)
	{
		if (current == 1)
		{
			return second;
		}
		
		return TailRecursionHelper(current - 1, second, first + second);
	}
	
}

// Define other methods and classes here