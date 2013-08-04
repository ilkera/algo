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
	public static double Sqrt(double number)
	{
		if (number < 0)
		{
			return double.NaN;
		}
		
		if (number == 0.0 || number == 1.0)
		{
			return number;
		}
		
		double low = 0.0;
		double high = (number / 2.0) + 1.0;
		double precision = 0.000000000000001;
		
		while (high - low >= precision)
		{
			double mid = low + (high - low) / 2.0;
			double midSquare = mid * mid;
			
			if (midSquare == number)
			{
				return mid;
			}
			else if (midSquare < number)
			{
				low = mid;
			}
			else
			{
				high = mid;
			}
		}
		return low;
	}
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