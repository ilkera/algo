<Query Kind="Program" />

/* Problem: Climbing Stairs

You are climbing a stair case. It takes n steps to reach to the top.

Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

Solution:

Same as Fibonacci. F(n) = F(n-1) + F(n-2)
*/

void Main()
{
	int steps = ClimbingStairs.Climb_v1(6);
	Console.WriteLine("6 stairs can be in {0} steps", steps);
	
	steps = ClimbingStairs.Climb_v2(6);
	Console.WriteLine("6 stairs can be in {0} steps", steps);
}

public class ClimbingStairs
{
	public static int Climb_v2(int n)
	{
		if(n < 0)
		{
			throw new ArgumentException("n can't be less than 0");
		}
		
		if(n == 1 || n== 0)
		{
			return 1;
		}
		
		int sFirst = 1;
		int sSecond = 1;
		int sTotal = 0;
		
		for (int i = 2; i <= n; i++)
		{
			sTotal = sFirst + sSecond;
			sSecond = sFirst;
			sFirst = sTotal;
		}
		
		return sTotal;
	}
	
	public static int Climb_v1(int n)
	{
		if(n < 0)
		{
			throw new ArgumentException("n can't be less than 0");
		}
		
		if(n == 0 || n == 1)
		{
			return 1;
		}
		
		return Climb_v1(n-1) + Climb_v1(n-2);
	}
}


// Define other methods and classes here
