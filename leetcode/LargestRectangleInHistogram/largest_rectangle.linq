<Query Kind="Program" />

/* Problem: Largest Rectangle in Histogram

Given n non-negative integers representing the histogram's bar height where the width of each bar is 1,
find the area of largest rectangle in the histogram.

Above is a histogram where width of each bar is 1, given height = [2,1,5,6,2,3].

The largest rectangle is shown in the shaded area, which has area = 10 unit.

For example,
Given height = [2,1,5,6,2,3],
return 10.
*/
void Main()
{
	int[] bars = {2, 1, 5, 6, 2, 3};
	
	int maxArea = Histogram.FindMaxArea(bars);
	
	maxArea.Dump();
}

public class Histogram
{
	public static int FindMaxArea(int[] histogram)
	{
		if(histogram == null || histogram.Length < 1)
		{
			return 0;
		}
		
		Stack<int> barIndexStack = new Stack<int>();
		
		int iCurrentBar = 0;
		int maxArea = 0;
		
		while(iCurrentBar < histogram.Length)
		{
			if(barIndexStack.Count == 0 || histogram[barIndexStack.Peek()] <= histogram[iCurrentBar])
			{
				barIndexStack.Push(iCurrentBar++);
			}
			else
			{
				int topIndex = barIndexStack.Peek();
				barIndexStack.Pop();
				
				int topArea = histogram[topIndex] * (barIndexStack.Count == 0 ? iCurrentBar : iCurrentBar - barIndexStack.Peek() - 1);
				
				if(topArea > maxArea)
				{
					maxArea = topArea;
				}
			}
		}
		
		iCurrentBar--;
		
		while(barIndexStack.Count != 0)
		{
			int topInddex = barIndexStack.Peek();
			barIndexStack.Pop();
			
			int topArea = histogram[topInddex] * (barIndexStack.Count == 0 ? iCurrentBar : iCurrentBar - barIndexStack.Peek() - 1);
			
			if(topArea > maxArea)
			{
				maxArea = topArea;
			}	
		}
		
		return maxArea;
	}
}

// Define other methods and classes here
