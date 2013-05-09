<Query Kind="Program" />

/* Problem: Palindrome Partitioning

Given a string s, partition s such that every substring of the partition is a palindrome.

Return all possible palindrome partitioning of s.

For example, given s = "aab",
Return

  [
    ["aa","b"],
    ["a","a","b"]
  ]
  
*/

void Main()
{
       List<List< string>> partitionList = PalindromePartitioning.Partition("aab" );
       
        foreach (List< string> individualPartition in partitionList)
       {
              Console.Write( "[ ");
               foreach ( var element in individualPartition)
              {
                     Console.Write( "{ " + element + "} ," );          
              }
              
              Console.WriteLine( " ]");
       }
}

public class PalindromePartitioning
{
        public static List<List< string>> Partition( string str)
       {
              List<List< string>> resultList = new List<List< string>>();
              
               if( string.IsNullOrEmpty(str))
              {
                      return resultList;
              }

               for ( int i = 0; i < str.Length; i++)
              {      
                      string current = str.Substring( 0, i+ 1);
                      string remaining = str.Substring(i+ 1);
                      if(IsPalindrome(current) == true && IsPalindrome(remaining) == true)
                     {
                           List< string> partition = new List< string>();
                           partition.Add(current);
                           partition.Add(remaining);
                           resultList.Add(partition);
                     }
              }
              
              List< string> singles = new List< string>();
               for ( int i = 0; i < str.Length; i++)
              {
                     singles.Add(str[i].ToString());
              }
              
              resultList.Add(singles);
              
               return resultList;
       }
       
        private static bool IsPalindrome(string str)
       {
               if( string.IsNullOrEmpty(str) == true || str.Length == 1)
              {
                      return true;
              }
              
               int left = 0;
               int right = str.Length- 1;
              
               while(left<right && str[left] == str[right])
              {
                     left++;
                     right--;
              }
              
               if(left >= right)
              {
                      return true;
              }
              
               return false;
       }
}
