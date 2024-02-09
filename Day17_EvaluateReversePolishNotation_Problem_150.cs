/*
 * You are given an array of strings tokens that represents an arithmetic expression in a Reverse Polish Notation.
 * 
 * Evaluate the expression. Return an integer that represents the value of the expression.
 * 
 * Note that:
 * 
 * The valid operators are '+', '-', '*', and '/'.
 * Each operand may be an integer or another expression.
 * The division between two integers always truncates toward zero.
 * There will not be any division by zero.
 * The input represents a valid arithmetic expression in a reverse polish notation.
 * The answer and all the intermediate calculations can be represented in a 32-bit integer.
 *  
 * 
 * Example 1:
 * 
 * Input: tokens = ["2","1","+","3","*"]
 * Output: 9
 * Explanation: ((2 + 1) * 3) = 9
 * 
 * Example 2:
 * 
 * Input: tokens = ["4","13","5","/","+"]
 * Output: 6
 * Explanation: (4 + (13 / 5)) = 6
 * 
 * Example 3:
 * 
 * Input: tokens = ["10","6","9","3","+","-11","*","/","*","17","+","5","+"]
 * Output: 22
 * Explanation: ((10 * (6 / ((9 + 3) * -11))) + 17) + 5
 * = ((10 * (6 / (12 * -11))) + 17) + 5
 * = ((10 * (6 / -132)) + 17) + 5
 * = ((10 * 0) + 17) + 5
 * = (0 + 17) + 5
 * = 17 + 5
 * = 22
 *  
 * 
 * Constraints:
 * 
 * 1 <= tokens.length <= 104
 * tokens[i] is either an operator: "+", "-", "*", or "/", or an integer in the range [-200, 200].
 * 
*/
public class Solution
{
    public static int EvalRPN(string[] tokens)
    {
        Stack stack = new Stack();

        for(int i = 0; i<tokens.Length; i++)
        {
            if(int.TryParse(tokens[i], out int result))
            {
                stack.Push(tokens[i]);
            }
            else
            {
                int sum = 0;
                int b = Convert.ToInt32(stack.Pop());
                int a = Convert.ToInt32(stack.Pop());

                if (tokens[i] == "*")  sum = a * b;
                if (tokens[i] == "+") sum = a + b;
                if (tokens[i] == "-") sum = a - b;
                if (tokens[i] == "/") sum = a / b;

                stack.Push(sum);
            }
        }

        return Convert.ToInt32(stack.Peek());
    }

    static void Main(string[] args)
    {
        Console.Write("Enter array length: ");
        int arrayLen = Convert.ToInt32(Console.ReadLine());

        string[] tokens = new string[arrayLen];

        for(int i = 0; i<arrayLen; i++)
        {
            tokens[i] = Convert.ToString(Console.ReadLine());
        }

        int res = EvalRPN(tokens);
        Console.WriteLine(res);
    }
}
