<Query Kind="Program" />

void Main()
{
	for (int i = 0; i < 30; i++)
	{
		Console.WriteLine("Sqrt({0}) = {1}", i, Sqrt(i));
	}
}

public static double Sqrt(double number)
{
	if (number < 0)
	{
		return double.NaN;
	}
	
	double low = 0;
	double high = number / 2 + 1;
	double precision = 0.000000000000001;
	
	while (high - low >= precision)
	{
		double mid = low + (high - low) / 2;
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

// Define other methods and classes here
