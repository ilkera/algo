<Query Kind="Program" />

/* Proxy Pattern

Def: Provide a surrogate or placeholder for another object to control access to it

Responsibilities: 

1 - remote proxies
are responsible for encoding a request and its arguments and for sending the encoded request to the real subject in a different address space.

2 - virtual proxies
may cache additional information about the real subject so that they can postpone accessing it.

3 - protection proxies
check that the caller has the access permissions required to perform a request.

*/
void Main()
{
	MathProxy math = new MathProxy();
	
	int a = 6; 
	int b = 3;
	
	Console.WriteLine("{0} + {1} = {2}", a, b ,math.Add(a,b));
	Console.WriteLine("{0} - {1} = {2}", a, b, math.Subtract(a,b));
	Console.WriteLine("{0} * {1} = {2}", a, b, math.Multiply(a,b));
	Console.WriteLine("{0} / {1} = {2}", a, b, math.Divide(a,b));
}

// Subject
public interface IMath
{
	int Add(int x, int y);
	int Subtract(int x, int y);
	int Multiply(int x, int y);
	int Divide(int x, int y);
}

// Real Subject
public class Math : IMath
{
	public int Add(int x, int y)
	{
		return x + y;
	}
	
	public int Subtract(int x, int y)
	{
		return x - y;
	}
	
	public int Multiply(int x, int y)
	{
		return x * y;
	}
	
	public int Divide(int x, int y)
	{
		return x / y;
	}
}

// Proxy class
public class MathProxy : IMath
{
	private Math _math;
	
	public MathProxy()
	{
		_math = new Math();
	}
	
	public int Add(int x, int y)
	{
		return _math.Add(x, y);
	}
	
	public int Subtract(int x, int y)
	{
		return _math.Subtract(x, y);
	}
	
	public int Multiply(int x, int y)
	{
		return _math.Multiply(x, y);
	}
	
	public int Divide(int x, int y)
	{
		return _math.Divide(x, y);
	}
	
	
}

// Define other methods and classes here
