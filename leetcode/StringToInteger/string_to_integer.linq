<Query Kind="Program" />

void Main()
{
	int result = 0;
	
	StringUtils.TryConvertToInteger("    -123", out result);
	
	result.Dump();
	
	StringUtils.TryConvertToInteger(" 123", out result);
	
	result.Dump();
	
	StringUtils.TryConvertToInteger(" 2147483648", out result);
	
	result.Dump();
}

public class StringUtils
{
	public static bool TryConvertToInteger(string str, out int value)
	{	
		value = 0;
		
		if(string.IsNullOrEmpty(str) == true)
		{
			return false;
		}
		
		int iCurrent = 0;
		while(iCurrent< str.Length && str[iCurrent] == ' ')
		{
			iCurrent++;
		}
		
		if(iCurrent == str.Length)
		{
			return false;
		}
		
		if(str[iCurrent] == '+')
		{
			iCurrent++;
		}
		
		bool isNegative = false;
		if(str[iCurrent] == '-')
		{
			isNegative = true;
			iCurrent++;
		}
		
		long result = 0;
		
		while(iCurrent < str.Length)
		{
			if(str[iCurrent] < '0' || str[iCurrent] > '9')
			{
				break;
			}
			
			int digit = str[iCurrent] - '0';
			result = result * 10 + digit;
			iCurrent++;	
		}
		
		if(isNegative)
		{
			result = -result;
		}
		
		if(result < int.MinValue)
		{
			result = int.MinValue;
		}
		
		if(result > int.MaxValue)
		{
			result = int.MaxValue;
		}
		
		value = (int)result;
		
		return true;
	}
}

// Define other methods and classes here
