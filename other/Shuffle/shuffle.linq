<Query Kind="Program" />

/* Problem: SHuffle List

http://www.codinghorror.com/blog/2007/12/the-danger-of-naivete.html
http://en.wikipedia.org/wiki/Knuth_shuffle
*/
void Main()
{
	List<int> input = new List<int> { 3, 8, 10, 1, 12, 54, 15};
	
	input.Dump();
	
	ShuffleList.Shuffle(input);
	
	input.Dump();
}

public class ShuffleList
{
	public static void Shuffle(List<int> input)
	{
		if(input == null || input.Count == 0)
		{
			return;
		}
		
		Random rnd = new Random();
		int length = input.Count;
		
		for (int i = length - 1; i >= 0; i--)
		{
			int random = rnd.Next(i+1);
			Swap(input, i, random);
		}
	}
	
	private static void Swap(List<int> input, int index, int change)
	{
		int temp = input[index];
		input[index] = input[change];
		input[change] = temp;
	}
}

// Define other methods and classes here
