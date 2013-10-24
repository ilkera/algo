<Query Kind="Program" />

void Main()
{
	double[,] matrix = { {0, 1, 2, 0, 2}, {0, 0, 3, 0, 1}, {0, 0, 0, 2, 1}, {0, 1, 0, 2, 1}, {0, 0, 0, 1, 0} };
	double[] vector = {1, 2, 1, 1, 1};
	
	var result = DotProduct(matrix, vector);
	
	result.Dump();
	
	SparseVector[] sparse = new SparseVector[matrix.GetLength(0)];
	
	for (int i = 0; i < matrix.GetLength(0); i++)
	{
		sparse[i] = new SparseVector();
	}
	
	sparse[0].Put(1,1);
	sparse[0].Put(2,2);
	sparse[0].Put(4,2);
	
	sparse[1].Put(2,3);
	sparse[1].Put(4,1);
	
	sparse[2].Put(3,2);
	sparse[2].Put(4,1);
	
	sparse[3].Put(1,1);
	sparse[3].Put(3,2);
	sparse[3].Put(4,1);

	sparse[4].Put(3,1);
	
	double[] result2 = new double[matrix.GetLength(0)];
	for (int i = 0; i < matrix.GetLength(0); i++)
	{
		result2[i] = sparse[i].Dot(vector);
	}
	
	result2.Dump();
}

public class SparseVector
{
	private Dictionary<int, double> sparseVector;
	
	public SparseVector()
	{	
		sparseVector = new Dictionary<int, double>();
	}
	
	public void Put(int index, double value)
	{
		sparseVector.Add(index, value);
	}
	
	public double Get(int key)
	{
		if (sparseVector.ContainsKey(key) == false)
		{	
			return 0.0;
		}
		
		return sparseVector[key];
	}
	
	public List<int> GetKeys()
	{
		return this.sparseVector.Keys.ToList();
	}
	
	public double Dot(double[] vector)
	{
		double sum = 0.0;
		foreach (var index in this.GetKeys())
		{
			sum += vector[index] * this.sparseVector[index];
		}	
		
		return sum;
	}
}

public static double[] DotProduct(double[,] matrix, double[] vector)
{
	double[] result = new double[vector.Length];
	
	for (int iRow = 0; iRow < matrix.GetLength(0); iRow++)
	{
		double sum = 0;
		for (int iColumn = 0; iColumn < matrix.GetLength(1); iColumn++)
		{
			sum += matrix[iRow,iColumn] * vector[iColumn];
		}
		result[iRow] = sum;
	}
	
	return result;
}

// Define other methods and classes here
