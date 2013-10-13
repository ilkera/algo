<Query Kind="Program" />

void Main()
{
	int[] bases = {-2, -1, 0, 1, 2, 3, 4};
	int[] powers = {-2, -1, 0, 1, 2, 3, 4};
	
	foreach (var baseNumber in bases)
	{
		foreach (var power in powers)
		{
			int result = Power(baseNumber, power);
			Console.WriteLine("Pow({0},{1}) = {2}", baseNumber, power, result);
			
			int actual = (int)Math.Pow(baseNumber, power);
			
			if (result != actual)
			{
				Console.WriteLine("Pow({0},{1}) SHOULD BE = {2}", baseNumber, power, actual);
			}
		}
	}
	
}

public static int Power(int baseNumber, int power)
{
	if (baseNumber == 0)
	{
		if (power > 0)
		{
			return 0;
		}
		else if (power == 0)
		{
			return 1;
		}
		else
		{
			return int.MinValue;
		}
	}
	bool isNegativePower = power < 0;
	
	if (isNegativePower == true)
	{
		power = -power;
	}
	
	int result = 1;
	int temp = baseNumber;
	
	while (power != 0)
	{
		if (power % 2 == 1)
		{
			result *= temp;
		}
		
		temp *= temp;
		power /= 2;
	}
	
	if (isNegativePower == true)
	{
		result = 1 / result;
	}
	
	return result;
}

// Define other methods and classes here
