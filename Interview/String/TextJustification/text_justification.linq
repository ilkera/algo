<Query Kind="Program" />

void Main()
{
	List<string> words = new List<string> { "This", "is", "an", "example", "of", "text", "justification." };
	//List<string> words = new List<string> { "Justification" , "good", "justification" };
	
	var justified = StringUtils.Justify(words, 16);
	
	justified.Dump();
}

public class StringUtils
{
	public static List<string> Justify(List<string> words, int maxLineLength)
	{
		if (words == null || words.Count < 1)
		{
			throw new ArgumentNullException("Null/Empty word list");
		}
		
		List<string> result = new List<string>();
		int begin = 0;
		int currentLength = 0;
		
		for (int i = 0; i < words.Count; i++)
		{
			string currentWord = words[i];
			
			if (currentLength + currentWord.Length + i - begin > maxLineLength)
			{
				// Exceeds current line - Connect words between begin and i
				result.Add(Connect(words, maxLineLength, currentLength, begin, i - 1, false));
				begin = i;
				currentLength = 0;
			}
			
			currentLength += currentWord.Length;
		}
		
		// Last Line - Left justified
		result.Add(Connect(words, maxLineLength, currentLength,  begin, words.Count - 1, true));
		
		return result;
	}
	
	private static string Connect(List<string> words, int maxLineLength, int currentLength, int begin, int end, bool leftJustify)
	{
		StringBuilder currentLine = new StringBuilder();
		
		int numberOfWords = end - begin + 1;
		int numberOfSpacesToBeAdded = maxLineLength - currentLength;
		int numberOfSpacesPerWord = numberOfWords == 1 ? 0 : numberOfSpacesToBeAdded / (numberOfWords - 1);
		int extraSpaces = numberOfSpacesToBeAdded - (numberOfSpacesPerWord * (numberOfWords - 1));
		int iCurrent;
		
		for (iCurrent = begin; iCurrent <= end; iCurrent++)
		{
			currentLine.Append(words[iCurrent]);
			
			if (iCurrent == end)
			{
				continue;
			}
			
			int numberOfSpaces = numberOfSpacesPerWord;
			if (extraSpaces > 0)
			{
				extraSpaces--;
				numberOfSpaces += 1;
			}
			
			AddSpaces(currentLine, numberOfSpaces, leftJustify);
		}
		
		if (iCurrent == end + 1 && currentLine.Length < maxLineLength)
		{
			currentLine.Append('@', maxLineLength - currentLine.Length);
		}
		
		return currentLine.ToString();
	}
	
	private static void AddSpaces(StringBuilder line, int numberOfSpaces, bool leftJustify)
	{
		int spaces = leftJustify ? 1 : numberOfSpaces;
		
		for (int i = 0; i < spaces; i++)
		{
			line.Append("@");
		}
	}
}

// Define other methods and classes here
