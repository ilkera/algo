<Query Kind="Program" />

void Main()
{
	List<int> input = new List<int> { 1, 2, 3 , 4, 5, 6, 7, 8, 9};
	
	Randomization.Shuffle(input);
	
	input.Dump();
}

public class Randomization
{
	public static void Shuffle(List<int> input)
	{
		if (input == null || input.Count < 2)
		{
			return; // no need to shuffle for null or 1 element arrays
		}
		
		Random random = new Random();
		for (int i = input.Count -1; i > 0; i--)
		{
			// Pick a random index
			int rndIndex = random.Next(0, i + 1);
			
			// Swap with current
			int temp = input[i];
			input[i] = input[rndIndex];
			input[rndIndex] = temp;
		}
	}
}

// Define other methods and classes here
