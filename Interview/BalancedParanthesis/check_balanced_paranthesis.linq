<Query Kind="Program" />

void Main()
{
	// Valid
	IsBalanced("((()))").Dump();
	IsBalanced("()()()").Dump();
	IsBalanced("()(())").Dump();
	
	// Invalid
	IsBalanced(")(()))").Dump();
	IsBalanced("()((()").Dump();
	IsBalanced(")))(((").Dump();
}

public static bool IsBalanced(string input)
{
	if (string.IsNullOrEmpty(input) == true)
	{	
		throw new ArgumentNullException("empty/null input");
	}
	
	int nestingLevel = 0;
	
	for (int index = 0; index < input.Length; index++)
	{
		char current = input[index];
		
		if (current == '(')
		{
			nestingLevel++;
		}
		else if (current == ')')
		{
			nestingLevel--;
			
			if (nestingLevel < 0)
			{
				return false;
			}
		}
		else
		{
			return false;
		}
	}
	
	return nestingLevel == 0;
}

// Define other methods and classes here
