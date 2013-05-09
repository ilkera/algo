<Query Kind="Program" />

void Main()
{
	int[] arr = {2, 3, 7, 1, 8, -1, -10, 15};
	
	Console.WriteLine("Missing positive {0}",MissingPositive.FindMissingPositive(arr));
	
	int[] arr2 = {1, 2, 3, 4, 5};
	
	Console.WriteLine("Missing positive {0}",MissingPositive.FindMissingPositive(arr2));
	
	int[] arr3 = {0, -2, -3};
	
	Console.WriteLine("Missing positive {0}",MissingPositive.FindMissingPositive(arr3));	

}

public class MissingPositive
{
	public static int FindMissingPositive(int[] array)
	{
		if(array == null)
		{
			throw new ArgumentNullException("array");
		}
		
		int i = 0;
		
		while(i < array.Length)
		{
			if(array[i] != i + 1 && array[i] > 0 && array[i] <= array.Length && array[i] != array[array[i] - 1])
			{
				Swap(array, i, array[i] - 1);
			}
			else
			{
				i++;
			}
		}
		
		array.Dump();
		
		for (i = 0; i < array.Length; i++)
		{
			if(array[i] != i + 1)
			{
				return i+1;
			}
		}
		return array.Length + 1;
	}
	
	public static void Swap(int[] array, int first, int second)
	{
		int temp = array[first];
		array[first] = array[second];
		array[second] = temp;
	}
}

// Define other methods and classes here
