<Query Kind="Program" />

/*

Problem: Two Sum

Given an array of integers, find two numbers such that they add up to a specific target number.

The function twoSum should return indices of the two numbers such that they add up to the target, 
where index1 must be less than index2. Please note that your returned answers (both index1 and index2) are not zero-based.

You may assume that each input would have exactly one solution.

Input: numbers={2, 7, 11, 15}, target=9
Output: index1=1, index2=2

*/

void Main()
{
	int[] numbers = {2, 7, 11, 15 };
	int target = 9;
	int[] result = TwoSum.GetIndices(numbers, target);
	
	if(result[0] == -1)
	{
		Console.WriteLine("No match found");
	}
	else
	{
		Console.WriteLine("Number1 = {0} at Index1 = {1} \nNumber2 = {2} at Index: {3}\nSums up to target {4}",
			numbers[result[0]], 
			result[0],
			numbers[result[1]],
			result[1],
			target);
	}
}

public class TwoSum
{
	public static int[] GetIndices(int[] numbers, int target)
	{	
		if(numbers == null)
		{	
			throw new ArgumentNullException("array");
		}
		
		int[] result = new int[2] { -1, -1};
		
		Dictionary<int,int> seenNumbersSoFar = new Dictionary<int, int>();
		
		for (int index = 0; index < numbers.Length; index++)
		{
			if(seenNumbersSoFar.ContainsKey(target - numbers[index]))
			{
				result[0] = seenNumbersSoFar[target - numbers[index]];
				result[1] = index;
				break;
			}
			else
			{
				seenNumbersSoFar.Add(numbers[index], index);
			}
		}
		return result;
	}
}
// Define other methods and classes here
