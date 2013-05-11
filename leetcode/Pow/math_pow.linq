<Query Kind="Program" />

/* Problem: Pow

Implement Math.Pow function

*/
void Main()
{
	Console.WriteLine(MathUtils.Pow(2,3));
	Console.WriteLine(MathUtils.Pow(2,5));
	Console.WriteLine(MathUtils.Pow(3,4));
	Console.WriteLine(MathUtils.Pow(3,-4));	
	
	Console.WriteLine(MathUtils.Pow(3,1));
	Console.WriteLine(MathUtils.Pow(1,4));
	Console.WriteLine(MathUtils.Pow(3,0));
	Console.WriteLine(MathUtils.Pow(0,4));
	Console.WriteLine(MathUtils.Pow(0,0));
}

public class MathUtils
{
	public static double Pow(double baseNumber, int expo)
	{	
		bool isNegative = expo < 0;
		
		if(isNegative)
		{
			expo = -expo;
		}
		
		double temp = baseNumber;
		double result = 1.0;
		
		for (int i = expo; i > 0; i /=2)
		{
			if(i % 2 == 1)
			{
				result *=temp;
			}
			temp *=temp;
		}
		
		if(isNegative == true)
		{
			result = 1.0 / result;
		}
		
		return result;
	}
}

// Define other methods and classes here
