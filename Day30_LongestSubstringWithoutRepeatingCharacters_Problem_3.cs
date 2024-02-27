/*
 * Given a string s, find the length of the longest substring without repeating characters.
 * 
 * Example 1:
 * 
 * Input: s = "abcabcbb"
 * Output: 3
 * Explanation: The answer is "abc", with the length of 3.
 * 
 * Example 2:
 * 
 * Input: s = "bbbbb"
 * Output: 1
 * Explanation: The answer is "b", with the length of 1.
 * Example 3:
 * 
 * Input: s = "pwwkew"
 * Output: 3
 * Explanation: The answer is "wke", with the length of 3.
 * Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
 *  
 * 
 * Constraints:
 * 
 * 0 <= s.length <= 5 * 104
 * s consists of English letters, digits, symbols and spaces.
*/

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        char[] charS = s.ToCharArray();
        HashSet<char> set = new HashSet<char>();

        int left = 0, longest_string = 1, right;

        if(string.IsNullOrEmpty(s))
        {
            return 0;
        }
        else if (charS.Length == 1)
        {
            return 1;
        }
        else
        {
            right = charS.Length - 1;
            int j = 0;
            while(left <= right)
            {
                if (!set.Contains(charS[left]))
                {
                    set.Add(charS[left]);
                    left++;
                }
                else
                {
                    longest_string = Math.Max(longest_string, set.Count);
                    set.Remove(charS[j]);
                    j++;
                }
            }
            longest_string = Math.Max(longest_string, set.Count);
            return longest_string;
        }
    }
}
