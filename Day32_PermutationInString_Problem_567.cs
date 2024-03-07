/*
 * Given two strings s1 and s2, return true if s2 contains a permutation of s1, or false otherwise.
 * 
 * In other words, return true if one of s1's permutations is the substring of s2.
 * 
 *  
 * 
 * Example 1:
 * 
 * Input: s1 = "ab", s2 = "eidbaooo"
 * Output: true
 * Explanation: s2 contains one permutation of s1 ("ba").
 * Example 2:
 * 
 * Input: s1 = "ab", s2 = "eidboaoo"
 * Output: false
 *  
 * 
 * Constraints:
 * 
 * 1 <= s1.length, s2.length <= 104
 * s1 and s2 consist of lowercase English letters.
*/

public class Solution {
    public bool CheckInclusion(string s1, string s2) {
      if(s1.Length > s2.Length)
        {
            return false;
        }

        char[] s1char = s1.ToCharArray();
        Dictionary<char, int> s1dict = new Dictionary<char, int>();

        char[] s2char = s2.ToCharArray();
        Dictionary<char, int> s2dict = new Dictionary<char, int>();

        // adding the initial count of each character in dictionary
        for (int i = 0; i < s1char.Length; i++)
        {
            if (!s1dict.ContainsKey(s1char[i]))
            {
                s1dict.Add(s1char[i], 1);
            }
            else
            {
                s1dict[s1char[i]] += 1;
            }
        }

        int left = 0, r = 0; 
        while(r< s2.Length)
        {
            if(s2dict.ContainsKey(s2char[r]))
            {
                s2dict[s2char[r]] += 1;
            }
            else
            {
                s2dict.Add(s2char[r], 1);
            }

            if (r - left + 1 > s1.Length)
            {
                if (s2dict[s2char[left]] == 1)
                {
                    s2dict.Remove(s2char[left]);
                }
                else
                {
                    s2dict[s2char[left]] -= 1;
                }
                left++;
            }

            if(r-left + 1 == s1.Length)
            {
                if(CheckEquals(s1dict, s2dict))
                {
                    return true;
                }
            }
            r++;
        }

        return false;
    }

    static bool CheckEquals(Dictionary<char, int> s1dict, Dictionary<char, int> s2dict)
    {
        foreach (char c in s1dict.Keys)
        {
            if (!s2dict.ContainsKey(c))
            {
                return false;
            }
            else if (s1dict[c] != s2dict[c])
            {
                return false;
            }
        }
        return true;
    }
}
