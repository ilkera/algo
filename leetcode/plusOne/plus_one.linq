<Query Kind="Program" />

/* Problem: Plus One

Given a number represented as an array of digits, plus one to the number.
*/


void Main()
{
	List<int> input = new List<int> {0};
	input = PlusOne.addOne(input);
	input.Dump();
	
	input = new List<int> { 1};
	input = PlusOne.addOne(input);
	input.Dump();
	
	input = new List<int> { 1, 0};
	input = PlusOne.addOne(input);
	input.Dump();
	
	input = new List<int> { 9, 9};
	input = PlusOne.addOne(input);
	input.Dump();
	
	input = new List<int> { 1, 2, 3};
	input = PlusOne.addOne(input);
	input.Dump();
	
	input = new List<int> { 9, 9, 9};
	input = PlusOne.addOne(input);
	input.Dump();
	
	input = new List<int> { 8, 9, 9, 9};
	input = PlusOne.addOne(input);
	input.Dump();
	
	input = new List<int> { 1, 0, 0, 0, 0};
	input = PlusOne.addOne(input);
	input.Dump();
	
	input = new List<int> { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0};
	input = PlusOne.addOne(input);
	input.Dump();
	
}

public class PlusOne
{
	public static List<int> addOne(List<int> digits)
	{
		if(digits == null || digits.Count == 0)
		{
			if(digits == null)
			{
				digits = new List<int>();
			}
			digits.Add(1);
			return digits;
		}
		
		digits.Reverse();
		int carry = 1;
		
		for (int i = 0; i < digits.Count; i++)
		{
			int sum = digits[i] + carry;
			digits[i] = sum % 10;
			carry = sum / 10;
			
			if(carry == 0)
			{
				break;
			}
		}
		
		if(carry != 0)
		{
			digits.Add(carry);
		}
		
		digits.Reverse();
		
		return digits;
	}
}

// Define other methods and classes here
