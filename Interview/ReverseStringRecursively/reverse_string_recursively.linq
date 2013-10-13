<Query Kind="Program" />

void Main()
{
	Reverse("Hello").Dump();
	
}

public static string Reverse(string str)
{
	if (string.IsNullOrEmpty(str) == true || str.Length < 2)
	{
		return str;
	}
	else
	{
		return Reverse(str.Substring(1)) + str[0].ToString();
	}
}

// Define other methods and classes here
