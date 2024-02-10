/*
 * Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
 * 
 * Example 1:
 * 
 * Input: n = 3
 * Output: ["((()))","(()())","(())()","()(())","()()()"]
 * 
 * Example 2:
 * 
 * Input: n = 1
 * Output: ["()"]
 *  
 * 
 * Constraints:
 * 
 * 1 <= n <= 8 
 * 
*/

/*
  * Rules =>
  *  # Pattern should always start with Open parentheses
  *  # open < n
  *  # closed < open
*/

public class Solution
{
    public static IList<string> GenerateParenthesis(int n)
    {
        List<string> parenthesis = new List<string>();

        GenerateParenthesis("(", 1, 0, n, parenthesis);

        return parenthesis;
    }

    public static void GenerateParenthesis(string current, int open, int closed, int length, List<string> parenthesis)
    {
        if (current.Length == length*2)
        {
            parenthesis.Add(current);
            return;
        }

        if (open < length)
            GenerateParenthesis(current + "(", open + 1, closed, length, parenthesis);

        if (closed < open)
             GenerateParenthesis(current + ")", open, closed + 1, length, parenthesis);
    }
  
    static void Main(string[] args)
    {
        Console.Write("Enter n: ");
        int n = Convert.ToInt32(Console.ReadLine());

        IList<string> resultingString = GenerateParenthesis(n);

        foreach(var res in resultingString)
        {
            Console.Write(res + " ");
        }
    }
}
