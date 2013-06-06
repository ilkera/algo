<Query Kind="Program" />

/* Problem: Find the maximum length sequence in a string where sequence has two unique chars 

In: aaabbccccaab
Out: bbcccc

*/
void Main()
{
    string str = "aaabbccccaab";
    string str2 = "aabbaaccccab";
    string str3 = "cbcaadaacaddcacddddacacacaccacaaacdddaaaadddaaccaaaaaddddcccccaaaabbbbbdd";
    string str4 = "cbcaadaacaddcacddddacacacaccacaaacdddaaaadddaaacacacacacccaaaaaddddccccddcddddcccdcccccaaaabbbbbdd";
    string str5 = "cbcaadaacaddcacddddacdddccccddbcddddacacaccdacaaacdddaaaadcddaaacacacacadcccaaaaadcccdcccccaaaabbbbbdd";
	   
	StringUtil.FindMaxUniqueTwoCharSequence(str).Dump();
    StringUtil.FindMaxUniqueTwoCharSequence(str2).Dump();
    StringUtil.FindMaxUniqueTwoCharSequence(str3).Dump();
    StringUtil.FindMaxUniqueTwoCharSequence(str4).Dump();
	StringUtil.FindMaxUniqueTwoCharSequence(str5).Dump();
}

public class StringUtil
{
    public static string FindMaxUniqueTwoCharSequence(string str)
    {
        if(string.IsNullOrEmpty(str) == true)
		{
            return str;
        }	  
             
		int maxSoFar = 0;
        int iCurrent = 0;
        char previous = ' ';
		int previousBegin = -1;
        int begin = 0;
        int end = 0;
        int maxBegin = -1;
        int maxEnd = -1;
			  
        HashSet<char> uniqueSoFar = new HashSet<char>();

        while(iCurrent < str.Length)
        {
            char current = str[iCurrent];
					 
            if(uniqueSoFar.Contains(current) == false && uniqueSoFar.Count == 2) // new sequence should start
            {
				end = iCurrent - 1;
                int currentSoFar = end - begin + 1;
						   
                if(currentSoFar > maxSoFar)
                {
					maxBegin = begin;
                    maxEnd = end;
                    maxSoFar = currentSoFar;
                }
						   
                uniqueSoFar.RemoveWhere(ch => ch.Equals(previous) == false);
                begin = previousBegin;
                end = iCurrent;
                continue;
             }
             else if(uniqueSoFar.Count == 2) // already have a sequence, add same items
             {
                end = iCurrent;
                           
				if(current.Equals(previous) == false)
                {
					previousBegin = iCurrent;
                }
              }
			  else if(uniqueSoFar.Contains(current) == false) // not have a sequence, 0 or 1 item
              {
			  	if(uniqueSoFar.Count == 0)
                {
                      begin = iCurrent;
                }

                uniqueSoFar.Add(current);
                previousBegin = iCurrent;
                end = iCurrent;  
              }
              else
			  {
      	          end = iCurrent;
              }
					 
              previous = current;
              iCurrent++;
		}     
		
		return str.Substring(maxBegin, maxEnd - maxBegin + 1);
       }
}

// Define other methods and classes here