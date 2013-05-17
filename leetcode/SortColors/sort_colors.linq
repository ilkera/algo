<Query Kind="Program" />

/* Problem: Sort Colors

Given an array with n objects colored red, white or blue,

sort them so that objects of the same color are adjacent, with the colors in the order red, white and blue.

Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.

Note:
You are not suppose to use the library's sort function for this problem.

http://en.wikipedia.org/wiki/Dutch_national_flag_problem

*/
void Main()
{
	int[] array = {2, 2, 1, 0, 1, 0 , 0, 1, 2, 1, 0};
	
	array.Dump();
	
	SortColors.Sort(array);
	
	array.Dump();
}

public class SortColors
{
	private static int RED = 0;
	private static int WHITE = 1;
	private static int BLUE = 2;
	
	public static void Sort(int[] colors)
	{
		if(colors == null || colors.Length < 2)
		{
			return;
		}
		
		int left = 0;
		int right = colors.Length - 1;
		int current = 0;
		
		while(current < right)
		{
			if(colors[current] == SortColors.WHITE)
			{
				current++;
				continue;
			}
			
			if(colors[current] == SortColors.RED)
			{
				Swap(colors, left, current);
				left++;
				current++;
			}
			else if(colors[current] == SortColors.BLUE)
			{
				Swap(colors, right, current);
				right--;
			}
			else
			{
				throw new ArgumentException(string.Format("invalid color value {0}", colors[current]));
			}
		}
	}
	
	private static void Swap(int[] array, int index, int change)
	{
		int temp = array[index];
		array[index] = array[change];
		array[change] = temp;
	}
}

// Define other methods and classes here
