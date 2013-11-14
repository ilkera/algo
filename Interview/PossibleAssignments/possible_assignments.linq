<Query Kind="Program" />

void Main()
{
	GetAllPossibleAssignments(3, 1).Dump();
}

public static int GetAllPossibleAssignments(int numTotalAssignments, int minDiff)
{
	return GetAssignmentsHelper(numTotalAssignments, minDiff, 0, -1);
}

private static int GetAssignmentsHelper(int numTotalAssignments, int minDiff, int currentIndex, int lastAd)
{	
	if (currentIndex == numTotalAssignments)
	{
		return 1;
	}
	
	int allPossibleAssignments = 0;
	if (lastAd == -1 || currentIndex - lastAd > minDiff)
	{
		allPossibleAssignments += GetAssignmentsHelper(numTotalAssignments, minDiff, currentIndex + 1, currentIndex);
	}
	
	allPossibleAssignments += GetAssignmentsHelper(numTotalAssignments, minDiff, currentIndex + 1, lastAd);

	return allPossibleAssignments;
}

// Define other methods and classes here
