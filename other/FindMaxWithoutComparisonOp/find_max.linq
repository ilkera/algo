<Query Kind="Program" />

/* Problem: Find maximum of two numbers without using comparison operator

*/
void Main()
{
	int a = 9;
	int b = 4;
	
	Console.WriteLine("Max({0},{1}) = {2}",	a, b, MaxUtil.Max(a, b));
	Console.WriteLine("Max({0},{1}) = {2}",	b, a, MaxUtil.Max(b, a));
}

public class MaxUtil
{
	public static int Max(int a, int b)
	{
		int c = a - b;
		int k = (c >> 31) & 0x1;
		int max = a - (c * k);
		return max;
	}
}


// Define other methods and classes here
