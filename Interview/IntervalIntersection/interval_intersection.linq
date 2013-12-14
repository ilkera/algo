<Query Kind="Program" />

void Main()
{
	List<Interval> first = new List<Interval>()
	{
		new Interval(0, 4),
		new Interval(7, 10),
		new Interval(12, 15),
		new Interval(18, 20),
		new Interval(22, 28)
	};
	
	List<Interval> second = new List<Interval>()
	{
		new Interval(2, 6),
		new Interval(7, 9),
		new Interval(10, 13),
		new Interval(16, 22),
		new Interval(23, 24)
	};
	
	List<Interval> intersection = IntervalTools.Intersect(first, second);
	
	intersection.Dump();
}

public static class IntervalTools
{
	public static List<Interval> Intersect(List<Interval> first, List<Interval> second)
	{
		if (first == null || second == null)
		{
			return null;
		}
		
		List<Interval> output = new List<Interval>();
		int iLastComparedInterval = 0;
		int iFirst = 0;
		int iSecond = 0;
		
		while (iFirst < first.Count)
		{
			Interval currentFirst = first[iFirst];
			iSecond = iLastComparedInterval;
			
			while (iSecond < second.Count)
			{
				Interval currentSecond = second[iSecond];
				
				if (IsOverlapping(currentFirst, currentSecond) == true)
				{
					iLastComparedInterval = iSecond;

					int start = Math.Max(currentFirst.Start, currentSecond.Start);
					int end = Math.Min(currentFirst.End, currentSecond.End);
					Interval intersection = new Interval(start, end);
					output.Add(intersection);
				}
				
				iSecond++;
			}
			
			iFirst++;
		}
		
		return output;
	}
	
	private static bool IsOverlapping(Interval first, Interval second)
	{
		
		bool isStartOverlap = IsValueInRange(first.Start, second.Start, second.End) || IsValueInRange(second.Start, first.Start, first.End);
		bool isEndOverlap = IsValueInRange(first.End, second.Start, second.End) || IsValueInRange(second.End, first.Start, first.End);
		
		return isStartOverlap && isEndOverlap;
	}
	
	private static bool IsValueInRange(int target, int min, int max)
	{
		return target >= min && target <= max;
	}
}

public class Interval
{
	public int Start { get; set; }
	public int End { get; set; }
	
	public Interval(int start, int end)
	{
		this.Start = start;
		this.End = end;
	}
}



// Define other methods and classes here
