<Query Kind="Program" />

void Main()
{
	int[] first = {3, 7, 9, 12, 15, 0, 0, 0, 0};
	int[] second = {1, 5, 13};
	
	MergeSortedArray.Merge(first, 5, second, 3);
	first.Dump();
}

public class MergeSortedArray
{
	public static int[] Merge(int[] first, int firstLength, int[] second, int secondLength)
	{
		int iFirst = firstLength - 1;
		int iSecond = secondLength - 1;
		int iCurrent = iFirst + iSecond + 1;
		
		while(iFirst >= 0 && iSecond >= 0)
		{
			if(first[iFirst] < second[iSecond])
			{
				first[iCurrent--] = second[iSecond--];
			}
			else
			{
				first[iCurrent--] = first[iFirst--];
			}
		}
		
		while(iFirst >= 0)
		{
			first[iCurrent--] = first[iFirst--];
		}
		
		while(iSecond >= 0)
		{
			first[iCurrent--] = second[iSecond--];
		}
		
		return first;
	}
}

// Define other methods and classes here
