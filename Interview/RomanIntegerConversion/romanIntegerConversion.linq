<Query Kind="Program" />

void Main()
{
	RomanUtil.ConvertToRoman(48).Dump();
	RomanUtil.ConvertToInt("XLVIII").Dump();
	RomanUtil.ConvertToInt("XCIV").Dump();
}

public enum Numeral
{
	I = 1,
	IV = 4,
	V = 5,
	IX = 9,
	X = 10,
	XL = 40,
	L = 50,
	XC = 90,
	C = 100,
	CD = 400,
	D = 500,
	CM = 900,
	M = 1000
}

public class RomanUtil
{
	public static int ConvertToInt(string roman)
	{
		if (string.IsNullOrEmpty(roman) == true)
		{
			throw new ArgumentNullException("invalid input");
		}
		
		int result = 0;
		
		for (int i = 0; i < roman.Length; i++)
		{
			string current = roman[i].ToString();
			Numeral value = 0;
			
			if (i + 1 < roman.Length)
			{
				string currentWithNext = roman.Substring(i, 2);
				
				if (Enum.TryParse(currentWithNext, out value) == true)
				{
					result += (int)value;
					i += 1;
					continue;
				}
			}
			
			if (Enum.TryParse(current, out value) == true)
			{
				result += (int)value;
			}
			else
			{
				throw new ArgumentException("invalid input");
			}
		}
		
		return result;
	}
	public static string ConvertToRoman(int number)
	{
		if (number <= 0)
		{
			throw new ArgumentException("invalid number");
		}
		
		StringBuilder romanNumber = new StringBuilder();
		var romanNumberIntegerValues = (Numeral[])Enum.GetValues(typeof(Numeral)); 
		
		for (int i = romanNumberIntegerValues.Length - 1; i >= 0; i--)
		{
			while (number >= (int)romanNumberIntegerValues[i])
			{
				romanNumber.Append(romanNumberIntegerValues[i]);
				number -= (int)romanNumberIntegerValues[i];
			}
		}
		
		return romanNumber.ToString();
		
	}
}

// Define other methods and classes here
