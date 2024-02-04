
/*
 *A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.

Given a string s, return true if it is a palindrome, or false otherwise.

 

Example 1:

Input: s = "A man, a plan, a canal: Panama"
Output: true
Explanation: "amanaplanacanalpanama" is a palindrome.
Example 2:

Input: s = "race a car"
Output: false
Explanation: "raceacar" is not a palindrome.
Example 3:

Input: s = " "
Output: true
Explanation: s is an empty string "" after removing non-alphanumeric characters.
Since an empty string reads the same forward and backward, it is a palindrome.
 

Constraints:

1 <= s.length <= 2 * 105
s consists only of printable ASCII characters. 
*/

public class Solution
{
    public static bool IsPalindrome(string s)
    {
        // Removing empty val
        s = s.Replace(" ", "");

        // Converting the string to lower case
        s = s.ToLower();

        // Converting string to list
        List<char> charList = s.ToCharArray().ToList();

        List<char> newCharList = new List<char>();

        int listCount = charList.Count;
        // For removing any special characters
        for (int i = 0; i< listCount; i++)
        {
            if(!char.IsLetterOrDigit(charList[i]) || char.IsWhiteSpace(charList[i]) || charList[i] == ' ')
            {
                continue;
            }
            else
            {
                newCharList.Add(charList[i]);
            }
        }

        if(newCharList.Count == 1)
        {
            return true;
        }
        int len = newCharList.Count;
        int m, n;
        for(m = 0, n = len -1; m < len/2 && n >= len/2; m++,n--)
        {
            if(newCharList[m] != newCharList[n])
            {
                return false;
            }
        }
        return true;
    }

    static void Main(string[] args)
    {
        string s = Convert.ToString(Console.ReadLine());

        Console.WriteLine(IsPalindrome(s));
    }
}
