<Query Kind="Program" />

void Main()
{
	   Console.WriteLine(Numeric.IsNumeric( "123"));
       Console.WriteLine(Numeric.IsNumeric( "-123"));
       Console.WriteLine(Numeric.IsNumeric( "3.416"));
       Console.WriteLine(Numeric.IsNumeric( "-3.416"));
       Console.WriteLine(Numeric.IsNumeric( "+100"));
       Console.WriteLine(Numeric.IsNumeric( "5e2"));
       Console.WriteLine(Numeric.IsNumeric( "-.123"));
       Console.WriteLine(Numeric.IsNumeric( "-1E-16"));
       
        // INVALID
       Console.WriteLine( "Invalid");
       Console.WriteLine(Numeric.IsNumeric( "12E"));
       Console.WriteLine(Numeric.IsNumeric( "1a3.14"));
       Console.WriteLine(Numeric.IsNumeric( ""));
       Console.WriteLine(Numeric.IsNumeric( null));
       Console.WriteLine(Numeric.IsNumeric( "12.A"));
       Console.WriteLine(Numeric.IsNumeric( "12.A12"));

}

public class Numeric
{
	public static bool IsNumeric(string input)
	{
		if (string.IsNullOrEmpty(input) == true)
		{
			return false;
		}
		
		// Skip leading spaces
		int start = 0;
		while (start < input.Length && input[start] == ' ')
		{
			start++;
		}
		
		// Skip trailing spaces
		int end = input.Length - 1;
		while (end >= 0 && input[end] == ' ')
		{
			end--;
		}
		
		if (start > end)
		{
			return false;
		}
		
		// Check for sign
		if (input[start] == '+' || input[start] == '-')
		{
			start++;
		}
		
		bool isDigitSeen = false;
		bool isDotSeen = false;
		bool isExpoSeen = false;
		
		while (start != end + 1 )
		{
			if (input[start] >= '0' && input[start] <= '9')
			{
				isDigitSeen = true;
			}
			else if (input[start] == '.')
			{
				if (isExpoSeen || isDotSeen) 
				{
					return false;
				}
				isDotSeen = true;
			}
			else if (input[start] == 'e' || input[start] == 'E')
			{
				if (isExpoSeen || isDigitSeen == false)
				{
					return false;
				}
				isExpoSeen = true;
				isDigitSeen = false;
			}
			else if (input[start] == '+' || input[start] == '-')
			{
				if (input[start - 1] != 'e' && input[start - 1] != 'E')
				{
					return false;
				}
			}
			else
			{
				return false;
			}
			
			start++;
		}
		
		return isDigitSeen;
	}
}

// Define other methods and classes here
