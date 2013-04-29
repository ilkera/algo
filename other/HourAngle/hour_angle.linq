<Query Kind="Program" />

/* Problem: Hour Angle

Wiki: http://en.wikipedia.org/wiki/Clock_angle_problem

Find angle between hours and minute hands of a clock

*/

void Main()
{
	Console.WriteLine("Angle betwen 2:20 = {0}", HourAngle.FindAngle(2,20));
	Console.WriteLine("Angle betwen 3:45 = {0}", HourAngle.FindAngle(3,45));
	Console.WriteLine("Angle betwen 6:40 = {0}", HourAngle.FindAngle(6,40));
	Console.WriteLine("Angle betwen 12:30 = {0}", HourAngle.FindAngle(12,30));
	Console.WriteLine("Angle betwen 7:05 = {0}", HourAngle.FindAngle(7,5));
}

public class HourAngle
{
	public static double FindAngle(uint hour, uint minute)
	{
		if(minute >= 60)
		{
			throw new Exception("invalid input");
		}
		
		if(hour > 12)
		{
			hour = hour % 12;
		}
		
		// completes 360 in 60 minutes. It moves by 6 degree / min
		double mAngle = minute * 6; 
		// completes 360 in 720 minutes. It moves by 0.5 degree / min
		double hAngle = 0.5 * (60 * hour + minute);
		
		double angle = Math.Abs(mAngle - hAngle);
		angle = Math.Min(angle, 360 - angle);
		return angle;
	}
}

// Define other methods and classes here
