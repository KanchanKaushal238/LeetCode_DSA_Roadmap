/*
 * Given an array of integers temperatures represents the daily temperatures, return an array answer such that answer[i] is the number of days you have to wait after the ith day to get a warmer temperature. If there is no future day for which this is possible, keep answer[i] == 0 instead.
 * 
 * Example 1:
 * 
 * Input: temperatures = [73,74,75,71,69,72,76,73]
 * Output: [1,1,4,2,1,1,0,0]
 * 
 * Example 2:
 * 
 * Input: temperatures = [30,40,50,60]
 * Output: [1,1,1,0]
 * 
 * Example 3:
 * 
 * Input: temperatures = [30,60,90]
 * Output: [1,1,0]
 *  
 * 
 * Constraints:
 * 
 * 1 <= temperatures.length <= 105
 * 30 <= temperatures[i] <= 100 
 * 
*/

public class Solution
{
//----------------------------------Solution 1 (Time Limit Exceeded)------------------------------------------------------------//
    public static int[] DailyTemperatures1(int[] temperatures)
    {
        int[] dayList = new int[temperatures.Length];


        Stack<int> stack = new Stack<int>();

        for (int i = 0; i <= temperatures.Length - 2; i++)
        {
            stack.Push(i + 1);
            if (stack.Count > 0 && temperatures[i] < temperatures[stack.Peek()])
            {
                dayList[i] = 1;
                stack.Pop();
            }
            else
            {
                stack.Pop();
                int j = i;
                stack.Push(j + 1);
                while (stack.Count > 0 && j < temperatures.Length - 1 && temperatures[i] >= temperatures[stack.Peek()])
                {
                    if (j == temperatures.Length - 1)
                    {
                        dayList[i] = 0;
                        break;
                    }
                    else
                    {
                        j = j + 1;
                        stack.Push(j + 1);
                    }
                }
                if (stack.Count > 0 && j < temperatures.Length - 1 && temperatures[i] < temperatures[stack.Peek()])
                {
                    dayList[i] = stack.Count;
                }
            }

            stack = new Stack<int>();
        }

        return dayList;
    }
//-------------------------------------Optimized Solution-----------------------------------------------------------------------------//
    public static int[] DailyTemperatures(int[] temperatures)
    {
        int[] dayList = new int[temperatures.Length];
        if (temperatures.Length == 1) return dayList;

        Stack<int> stack = new Stack<int>();

        stack.Push(temperatures.Length - 1);

        for(int i = temperatures.Length - 2; i >= 0; i--)
        {
            while(stack.Count > 0)
            {
                if(temperatures[i] < temperatures[stack.Peek()])
                {
                    dayList[i] = stack.Peek() - i;
                    break;
                }
                stack.Pop();
            }
            stack.Push(i);
        }
        return dayList;
    }


    static void Main(string[] args)
    {
        Console.Write("Enter length of Array: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] temperatures = new int[] { 73, 74, 75, 71, 69, 72, 76, 73 };

        for (int i = 0; i < n; i++)
        {
            temperatures[i] = Convert.ToInt32(Console.ReadLine());
        }

        int[] resultDays = DailyTemperatures(temperatures);
        
        foreach(var days in resultDays)
        {
            Console.Write(days + ", ");
        }
    }
}
