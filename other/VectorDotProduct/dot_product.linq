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