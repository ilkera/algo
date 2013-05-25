<Query Kind="Program" />

/* Problem: Gray Code

The gray code is a binary numeral system where two successive values differ in only one bit.

Given a non-negative integer n representing the total number of bits in the code, print the sequence of gray code.

A gray code sequence must begin with 0.

For example, given n = 2, return [0,1,3,2]. Its gray code sequence is:

00 - 0
01 - 1
11 - 3
10 - 2
Note:
For a given n, a gray code sequence is not uniquely defined.

For example, [0,2,3,1] is also a valid gray code sequence according to the above definition.

*/
void Main()
{
	GrayCode.Gray(2);
	
	List<int> sequence = GrayCode.FindGraySequence(2);
	
	sequence.Dump();
	
	Console.WriteLine("Convert Binary to Gray: {0}", GrayCodeConverter.BinaryToGray(11));
	Console.WriteLine("Convert Gray to Binary: {0}", GrayCodeConverter.GrayToBinary(14));
}

public class GrayCode
{
	public static List<int> FindGraySequence(int number)
	{
		List<int> sequence = new List<int>();
		
		if(number < 1)
		{
			return sequence;
		}
		
		int nGrayCode =  1 << number;
		
		for (int i = 0; i < nGrayCode; i++)
		{
			sequence.Add((i >> 1) ^ i);
		}
		
		return sequence;
	}
	
	public static void Gray(int number)
	{
		Gray("", number, true);
	}
	
	private static void Gray(string prefix, int number, bool forward)
	{
		if(number == 0)
		{
			Console.WriteLine(prefix);
			return;
		}
		
		if(forward == true)
		{
			Gray(prefix + "0", number - 1, true);
			Gray(prefix + "1", number - 1, false);
		}
		else
		{
			Gray(prefix + "1", number - 1, true);
			Gray(prefix + "0", number - 1, false);
		}
	}
}

public class GrayCodeConverter
{
	public static int BinaryToGray(int number)
	{
		return (number >> 1) ^ number;
	}
	
	public static int GrayToBinary(int number)
	{
	 	int current;
	 	int binary = number;
     
		for (int i= 1; (current = (binary >> i)) != 0; i <<= 1 )
		{
            binary ^= current;
			Console.WriteLine("i={0}, current={1} binary={2}", i, current,  binary);
		}
		
	    return binary;
	}
}

// Define other methods and classes here
