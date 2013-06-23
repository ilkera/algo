<Query Kind="Program" />

/* Problem: Reverse words in a sentence */
void Main()
{
	StringUtils.Reverse("Hello, world").Dump();
}
public class StringUtils
{
    public static string Reverse(string sentence)
    {
        if (string.IsNullOrEmpty(sentence) == true || sentence.Length < 2)
        {
            return sentence;
        }
        
        StringBuilder reversed = new StringBuilder(sentence);
        
        // Reverse the all sentence
        Reverse(reversed, 0, reversed.Length - 1);
        
        // Reverse the individual word
        int iCurrent = 0;
        int iStart = 0;
        int iEnd = 0;
        
        while (iCurrent < reversed.Length)
        {
            if (reversed[iCurrent] == ' ')
            {
                iEnd = iCurrent - 1;
                Reverse(reversed, iStart, iEnd);
                
                iStart = iCurrent + 1;
                iEnd = iCurrent + 1;
            }
            else
            {
                iEnd++;
            }
            
            iCurrent++;
        }
        
        Reverse(reversed, iStart, iCurrent - 1);
        
        return reversed.ToString();
        
    }
    
    private static void Reverse(StringBuilder word, int iStart, int iEnd)
    {
        while (iStart < iEnd)
        {
            char temp = word[iStart];
            word[iStart] = word[iEnd];
            word[iEnd] = temp;
            iStart++;
            iEnd--;
        }
    }
}

// Define other methods and classes here
