<Query Kind="Program" />

/* Problem: Sqrt(x)

Implement int sqrt(int x).

Compute and return the square root of x.

*/

void Main()
{
	Console.WriteLine(MathUtils.Sqrt(16));
	Console.WriteLine(MathUtils.Sqrt(25));
	Console.WriteLine(MathUtils.Sqrt(49));
	Console.WriteLine(MathUtils.Sqrt(5));
}

public class MathUtils
{
	public static int Sqrt(int number)
	{
		if(number < 2)
		{
			return number;
		}
		
		int left = 0;
		int right = 1 + (number / 2);
		
		while(left + 1 < right)
		{
			int mid = (right - left) / 2 + left;
			int square = mid * mid;
			
			if(square == number)
			{
				return mid;
			}
			else if(square > number)
			{
				right = mid;
			}
			else
			{
				left = mid;
			}
		}
		return left;
	}
}


// Define other methods and classes here