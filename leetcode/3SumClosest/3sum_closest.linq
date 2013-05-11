<Query Kind="Program" />

/* Problem: 3Sum Closest

Given an array S of n integers, find three integers in S such that the sum is closest to a given number, target. Return the sum of the three integers. You may assume that each input would have exactly one solution.

For example, given array S = {-1 2 1 -4}, and target = 1.

The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
	
*/
void Main()
{
	List<int> input = new List<int> { -1, 2, 1, -4};
	
	int threeSumClosestValue = ThreeSum.GetThreeSumClosest(input, 1);
	
	threeSumClosestValue.Dump();
}

public class ThreeSum
{
	public static int GetThreeSumClosest(List<int> input, int target)
	{	
		if(input == null || input.Count == 0)
		{
			return 0;
		}
		
		input.Sort();
		int minDiff = int.MaxValue;
		int result = 0;
		
		for (int i = 0; i < input.Count; i++)
		{
			int left = i + 1;
			int right = input.Count - 1;
			
			while(left < right)
			{
				int sum = input[i] + input[left] + input[right];
				
				if(sum == target)
				{
					return sum;
				}
				
				int currentDiff = Math.Abs(sum - target);
				if(currentDiff < minDiff)
				{
					minDiff = currentDiff;
					result = sum;
				}
				
				if(sum > target)
				{
					right--;
				}
				else
				{
					left++;
				}
			}
		}
		
		return result;
	}
}

// Define other methods and classes here
