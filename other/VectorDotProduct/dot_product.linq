<Query Kind="Program" />

/* Problem: Find dot product of given two 2D vectors.

Ref: http://www.mathsisfun.com/algebra/vectors-dot-product.html
*/

void Main()
{
	Vector first = new Vector(-6, 8);
	Vector second = new Vector(5, 12);
	
	int product = VectorUtils.FindDotProduct(first, second);
	
	product.Dump();
	
	double productWithCos = VectorUtils.FindDotProduct(10, 13, 59.5);
	
	productWithCos.Dump();
	
	Console.WriteLine(VectorUtils.FindDotProduct(new decimal[] { -6, 8 }, new decimal[] { 5, 12 }));
	
	Console.WriteLine(VectorUtils.FindDotProduct(new decimal[] { 1, 3, -5 }, new decimal[] { 4, -2, -1 }));
	
}

public class VectorUtils
{
	// dotProduct = v1.X * v2.X + v1.Y * v2.Y
	public static int FindDotProduct(Vector vFirst, Vector vSecond)
	{	
		if(vFirst == null || vSecond == null)
		{
			return 0;
		}
		
		int xProduct = vFirst.X * vSecond.X;
		int yProduct = vFirst.Y * vSecond.Y;
		
		return xProduct + yProduct;
	}
	
	public static decimal FindDotProduct(decimal[] firstVector, decimal[] secondVector)
	{
		if(firstVector == null || firstVector.Length == 0)
		{
			return 0;
		}
		
		if(secondVector == null || secondVector.Length == 0)
		{
			return 0;
		}
		
		if(firstVector.Length != secondVector.Length)
		{
			return 0;
		}
		
		decimal result = 0;
		
		for (int i = 0; i < firstVector.Length; i++)
		{
			result += firstVector[i] * secondVector[i];
		}
		
		return result;
	}
	
	// dotProduct = |firstLength| * |secondLength| * cos(X)
	public static int FindDotProduct(int first, int second, double angle)
	{
		int result = (int) Math.Round(Math.Abs(first * second) * Math.Cos(DegreeToRadian(angle)));
		return result;
	}
	
	private static double DegreeToRadian(double angle)
	{
   		return Math.PI * angle / 180.0;
	}
}

// 2-D Vector
public class Vector
{
	public int X { get; set; }
	public int Y { get; set; }
	
	public Vector(int x, int y)
	{
		this.X = x;
		this.Y = y;
	}
}

// Define other methods and classes here