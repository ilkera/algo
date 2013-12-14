<Query Kind="Program" />

void Main()
{
	int[] array = {1, 2, 3, 4, 5};
	MovingAverages.PrintMovingAverage(array, 3);
}

public class MovingAverages
{
	public static void PrintMovingAverage(int[] array, int windowSize)
	{
		if (array == null || array.Length < 1 || windowSize < 1)
		{
			return;
		}
		
		Queue<int> bufferQueue = new Queue<int>(windowSize);
		int iCurrent = 0;
	
		while (iCurrent < array.Length)
		{
			if (bufferQueue.Count == windowSize)
			{
				Console.WriteLine("Current avg: " + bufferQueue.Average());
				bufferQueue.Dequeue();
				continue;
			}
			
			bufferQueue.Enqueue(array[iCurrent]);
			iCurrent++;
		}
		
		if (bufferQueue.Count == windowSize)
		{
			Console.WriteLine("Current avg: " + bufferQueue.Average());
		}
	}
}

// Define other methods and classes here
