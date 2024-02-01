/*
 * String Encode and Decode
 * 
 * Design an algorithm to encode a list of strings to a single string. 
 * The encoded string is then decoded back to the original list of strings.
 * 
 * Please implement encode and decode
 * 
 * Example 1:
 * 
 * Input: ["neet","code","love","you"]
 * 
 * Output:["neet","code","love","you"]
 * 
 * 
 * Example 2:
 * 
 * Input: ["we","say",":","yes"]
 * 
 * Output: ["we","say",":","yes"]
 * 
 * Constraints:

 * 0 <= strs.length < 100
 * 0 <= strs[i].length < 200
 * strs[i] contains only UTF-8 characters.
 * 
*/

public class Solution
{

    public static string Encode(IList<string> strs)
    {
        if (strs.Count == 0)
        {
            return null;
        }
        else
        {
            string s = string.Join("=", strs);
            return s;
        }
    }

    public static List<string> Decode(string s)
    {
        if(s == null)
        {
            return new List<string>();
        }
        else if(string.IsNullOrWhiteSpace(s))
        {
            return new List<string>() { "" };
        }
        else
            return s.Split("=").ToList();
    }
}
