<Query Kind="Program" />

/* Problem: Integer to Roman

Given an integer, convert it to a roman numeral.

Input is guaranteed to be within the range from 1 to 3999.

*/
void Main()
{
	Console.WriteLine(Roman.ParseInt(79));
}

public class Roman
{
	private static Dictionary<int, string> _IntegerToRomanMap;
	private static int[] _Bases = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000};
	
	static Roman()
	{
		_IntegerToRomanMap = new Dictionary<int, string>();
		
		_IntegerToRomanMap.Add(1, "I");
		_IntegerToRomanMap.Add(4, "IV");
		_IntegerToRomanMap.Add(5, "V");
		_IntegerToRomanMap.Add(9, "IX");
		
		_IntegerToRomanMap.Add(10, "X");
		_IntegerToRomanMap.Add(40, "XL");
		_IntegerToRomanMap.Add(50, "L");
		_IntegerToRomanMap.Add(90, "XC");
		
		_IntegerToRomanMap.Add(100, "C");
		_IntegerToRomanMap.Add(400, "CD");
		_IntegerToRomanMap.Add(500, "D");
		_IntegerToRomanMap.Add(900, "CM");
		_IntegerToRomanMap.Add(1000, "M");
		
	}
	
	public static string ParseInt(int number)
	{
		StringBuilder result = new StringBuilder();
		
		for (int i = _Bases.Length -1; i >= 0; i--)
		{
			while(_Bases[i] <= number)
			{
				result.Append(_IntegerToRomanMap[_Bases[i]]);
				number -= _Bases[i];
			}
		}
		
		return result.ToString();
	}
}

// Define other methods and classes here
