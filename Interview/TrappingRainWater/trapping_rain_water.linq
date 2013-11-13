<Query Kind="Program" />

void Main()
{
	int[] array = {0,1,0,2,1,0,1,3,2,1,2,1};
	
	int volume = Trap(array);
	
	Console.WriteLine("Volume: " + volume);
}

public static int Trap(int[] array)
{
	if (array == null || array.Length < 1)
	{
		return 0;
	}
	
	int iMaxHeight = 0;
	int water = 0;
	int height = 0;
	
	// Find Max Height
	for (int index = 0; index < array.Length; index++)
	{
		if (array[index] > array[iMaxHeight])
		{
			iMaxHeight = index;
		}
	}
	
	// Find water volume before max height
	for (int index = 0; index < iMaxHeight; index++)
	{
		if (height > array[index])
		{
			water += height - array[index];
		}
		else
		{	
			height = array[index];
		}
	}
	
	// Find water volume after max height
	height = 0;
	for (int index = array.Length - 1; index > iMaxHeight; index--)
	{
		if (height > array[index])
		{
			water += height - array[index];
		}
		else
		{
			height = array[index];
		}
	}
	
	return water;
}

// Define other methods and classes here