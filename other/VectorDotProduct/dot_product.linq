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
	
	SortedList<int, double> listFirst = new SortedList<int, double>();
	listFirst.Add(1, 0.5);
	listFirst.Add(3, 0.7);
	listFirst.Add(12, 1.3);
	
	SortedList<int, double> listSecond = new SortedList<int, double>();
	listSecond.Add(2, 0.4);
	listSecond.Add(3, 2.3);
	listSecond.Add(12, 4.7);
	
	double resultOfTwoSparseVectors = VectorUtils.FindDotProduct(listFirst, listSecond);
	resultOfTwoSparseVectors.Dump();
	// (1, 0.5), (3, 0.7), (12, 1.3)> * <(2, 0.4), (3, 2.3), (12, 4.7)
	
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
	
	public static double FindDotProduct(SortedList<int, double> vFirst, SortedList<int, double> vSecond)
	{
		if(vFirst == null || vFirst.Count == 0)
		{
			return 0;
		}
		
		if(vSecond == null || vSecond.Count == 0)
		{
			return 0;
		}
		
		double result = 0;
		int iFirst = 0;
		int iSecond = 0;
		
		while(iFirst < vFirst.Count && iSecond < vSecond.Count)
		{
			KeyValuePair<int, double> currentFirst = vFirst.ElementAt(iFirst);
			KeyValuePair<int, double> currentSecond = vSecond.ElementAt(iSecond);
			
			if(currentFirst.Key == currentSecond.Key)
			{
				result += currentFirst.Value * currentSecond.Value;
				iFirst++;
				iSecond++;
			}
			else if (currentFirst.Key < currentSecond.Key)
			{
				iFirst++;
			}
			else
			{
				iSecond++;
			}
		}
		return result;
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