
/*
 * Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', 
 * determine if the input string is valid.
 * 
 * An input string is valid if:
 * 
 * Open brackets must be closed by the same type of brackets.
 * Open brackets must be closed in the correct order.
 * Every close bracket has a corresponding open bracket of the same type.
 *  
 * 
 * Example 1:
 * 
 * Input: s = "()"
 * Output: true
 * 
 * Example 2:
 * 
 * Input: s = "()[]{}"
 * Output: true
 * 
 * Example 3:
 * 
 * Input: s = "(]"
 * Output: false
 *  
 * 
 * Constraints:
 * 
 * 1 <= s.length <= 104
 * s consists of parentheses only '()[]{}'. 
*/
public class Solution
{
    public static bool IsValid(string s)
    {
        char[] sChar = s.ToCharArray();

        Stack stackChar = new Stack();

        // eliminates first digit as closed brackets 
        if(sChar[0] == '}' || sChar[0] == ')' || sChar[0] == ']')
        {
            return false;
        }

        // eliminates 1 digit count
        if(string.IsNullOrWhiteSpace(s) || sChar.Length == 0 || sChar.Length == 1)
        {
            return false;
        }

        // eleminate odd number count
        if (sChar.Length % 2 != 0) return false;

        int count = 0;

        for(int i = 0; i< sChar.Length; i++)
        {
            if (sChar[i] == '{' || sChar[i] == '(' || sChar[i] == '[' )
            {
                count++;
                stackChar.Push(sChar[i]);
            }
            if (stackChar.Count != 0 && (sChar[i] == '}' || sChar[i] == ')' || sChar[i] == ']'))
            {
                if (Convert.ToChar(stackChar.Peek()) == '(' && sChar[i] == ')')
                {
                    count++;
                    stackChar.Pop();
                }
                else if (Convert.ToChar(stackChar.Peek()) == '{' && sChar[i] == '}')
                {
                    count++;
                    stackChar.Pop();
                }
                else if (Convert.ToChar(stackChar.Peek()) == '[' && sChar[i] == ']')
                {
                    count++;
                    stackChar.Pop();
                }
                else
                {
                    return false;
                }
            }
        }
        if (count != sChar.Length) return false;
        if (stackChar == null || stackChar.Count != 0) return false;

        return true;
    }

    static void Main(string[] args)
    {
        string s = Console.ReadLine();

        bool isValidBrackets = IsValid(s);

        Console.WriteLine(isValidBrackets);
    }
}
