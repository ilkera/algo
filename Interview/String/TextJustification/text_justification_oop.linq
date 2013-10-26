<Query Kind="Program" />

void Main()
{
	List<string> words = new List<string> { "This", "is", "an", "example", "of", "text", "justification." };
    //List<string> words = new List<string> { "Justification" , "good", "justification" };
    
	TextJustification textJustifier = new TextJustification(words, 16);
	
    var justified = textJustifier.Justify();
        
    justified.Dump();
}

public class TextJustification
{
	private List<string> words;
	private int maxLineLength;
	
	public TextJustification(List<string> words, int maxLineLength)
	{
		if (words == null || words.Count < 1)
		{
			throw new ArgumentNullException("Null/Empty word collection");
		}
		
		this.words = words;
		this.maxLineLength = maxLineLength;
	}
	
	public List<string> Justify()
	{
		List<string> result = new List<string>();
		int currentLength = 0;
		int iBegin = 0;
		
		for (int iCurrent = 0; iCurrent < this.words.Count; iCurrent++)
		{
			string currentWord = this.words[iCurrent];
			
			if (currentLength + currentWord.Length + iCurrent - iBegin > this.maxLineLength)
			{
				// Current word exceeds current length
				string lineSoFar = Connect(iBegin, iCurrent - 1, currentLength, leftJustify: false);
				result.Add(lineSoFar);
				
				iBegin = iCurrent;
				currentLength = 0;
			}
			currentLength += currentWord.Length;
		}
		
		string lastLine = Connect(iBegin, this.words.Count - 1, currentLength, leftJustify : true);
		result.Add(lastLine);
		
		return result;
	}
	
	private string Connect(int iBegin, int iEnd, int currentLength, bool leftJustify)
	{
		StringBuilder line = new StringBuilder();
		
		int numOfWords = iEnd - iBegin + 1;
		int numOfSpacesToBeAdded = this.maxLineLength - currentLength;
		int numOfSpacesPerWord = numOfWords == 1 ? 0 : numOfSpacesToBeAdded / (numOfWords - 1);
		int extraSpaces = numOfSpacesToBeAdded - (numOfSpacesPerWord * (numOfWords - 1));
		int iCurrent;
		
		for (iCurrent = iBegin; iCurrent <= iEnd; iCurrent++)
		{
			string currentWord = this.words[iCurrent];
			line.Append(currentWord);
			
			if (iCurrent == iEnd)
			{
				continue;
			}
			
			// Add spaces
			int numSpaces = numOfSpacesPerWord;
			
			if (extraSpaces > 0)
			{
				extraSpaces--;
				numSpaces++;
			}
			
			AddSpaces(ref line, numSpaces, leftJustify);
		}
		
		if (line.Length < this.maxLineLength)
		{
			AddSpaces(ref line, this.maxLineLength - line.Length, false);
		}
		
		return line.ToString();
	}
	
	private void AddSpaces(ref StringBuilder line, int numOfSpaces, bool leftJustify)
	{
		int spacesToBeAdded = leftJustify ? 1 : numOfSpaces;
		line.Append('@', spacesToBeAdded);
	}
}

// Define other methods and classes here
