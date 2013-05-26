<Query Kind="Program" />

/* Problem: Collatz Problem

Consider the following operation on an arbitrary positive integer:
If the number is even, divide it by two.
If the number is odd, triple it and add one.

Ref: http://en.wikipedia.org/wiki/Collatz_conjecture
*/
void Main()
{
	List<int> result = CollatzProblem.Find(7);
	
	result.Dump();
}


public class CollatzProblem
{
	public static List<int> Find(int number)
	{
		List<int> sequence = new List<int>();
		
		Find(number, sequence);
		
		return sequence;
	}
	
	private static void Find(int number, List<int> result)
	{
		result.Add(number);
		
		if(number == 1)
		{
			return;
		}
		
		if(number % 2 == 0)
		{
			Find(number / 2, result);
		}
		else
		{
			Find((3 * number) + 1, result);
		}
	}
}
// Define other methods and classes here
