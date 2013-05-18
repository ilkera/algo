<Query Kind="Program" />

/* Problem: Roman to Integer

Given a roman numeral, convert it to an integer.

Input is guaranteed to be within the range from 1 to 3999.

*/
void Main()
{
	Console.WriteLine(Roman.ConvertToInt("LXXIX"));
}

public class Roman
{
	private static Dictionary<string, int> romanMap;
	
	static Roman()
	{
		romanMap = new Dictionary<string, int>();
		
		romanMap.Add("I", 1);
		romanMap.Add("IV", 4);
		romanMap.Add("V", 5);
		romanMap.Add("IX", 9);
		
		romanMap.Add("X", 10);
		romanMap.Add("XL", 40);
		romanMap.Add("L", 50);
		romanMap.Add("XC", 90);
		
		romanMap.Add("C", 100);
		romanMap.Add("CD", 400);
		romanMap.Add("D", 500);
		romanMap.Add("CM", 900);
		romanMap.Add("M", 1000);
	}
	
	public static int ConvertToInt(string roman)
	{
		if(string.IsNullOrEmpty(roman) == true)
		{
			throw new ArgumentNullException("romanNumber");
		}
		
        int sum = 0;
        int iCurrent = 0;
              
        while(iCurrent < roman.Length)
		{
           string current = roman[iCurrent].ToString();
                     
           if(iCurrent + 1 < roman.Length)
           {
               string currentWithNext = roman.Substring(iCurrent, 2);
               if(romanMap.ContainsKey(currentWithNext))
               {
                    sum += romanMap[currentWithNext];
                    iCurrent = iCurrent+ 2;
               		continue;
               }
           }
              
           if(romanMap.ContainsKey(current))
           {
               sum +=romanMap[current];
           }
           else
           {
		   		throw new Exception( "invalid input");
       		}
            iCurrent++;
		}    
		
		return sum;
	}
}

// Define other methods and classes here
