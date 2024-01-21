/*
 *Given two strings s and t, return true if t is an anagram of s, and false otherwise.
 *
 *An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, 
 *typically using all the original letters exactly once.
 *
 *Example 1:
 *Input: s = "anagram", t = "nagaram"
 *Output: true
 *
 *Example 2:
 *Input: s = "rat", t = "car"
 *Output: false
 *
 *Constraints:
 *1 <= s.length, t.length <= 5 * 104
 *s and t consist of lowercase English letters. 
*/

public class Solution
{
    public static bool IsAnagram(string s, string t)
    {
        char[] firstStringArr = s.ToCharArray();
        char[] secondStringArr = t.ToCharArray();

        if (firstStringArr.Length != secondStringArr.Length)
        {
            return false;
        }
        else 
        {
            Array.Sort(firstStringArr);
            Array.Sort(secondStringArr);

            for (int i = 0; i < firstStringArr.Length; i++)
            {
                if(firstStringArr[i] != secondStringArr[i])
                {
                    return false;
                }
            }

            return true;
        }
    }

    static void Main(string[] args)
    {
        string s = Console.ReadLine(); 
        string t = Console.ReadLine();

        Console.WriteLine(IsAnagram(s, t));
    }
}
