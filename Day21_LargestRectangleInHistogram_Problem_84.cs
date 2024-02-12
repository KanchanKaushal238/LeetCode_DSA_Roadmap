/*
 * Given an array of integers heights representing the histogram's bar height where the width of each bar is 1,
 * return the area of the largest rectangle in the histogram.
 * 
 * Example 1:
 * 
 * Input: heights = [2,1,5,6,2,3]
 * Output: 10
 * Explanation: The above is a histogram where width of each bar is 1.
 * The largest rectangle is shown in the red area, which has an area = 10 units.
 * 
 * Example 2:
 * 
 * Input: heights = [2,4]
 * Output: 4
 *  
 * Constraints:
 * 
 * 1 <= heights.length <= 105
 * 0 <= heights[i] <= 104 
 * 
*/

public class Solution
{
//--------------------------------Less Optimized Solution ---------------------------------------------------------------//
    public static int LargestRectangleArea1(int[] heights)
    {
        Dictionary<int, int> leftDict = new Dictionary<int, int>();
        Dictionary<int, int> rightDict = new Dictionary<int, int>();

        int currentHeight = 0;
        int maxHeight = 0;

        int left = 0;
        int right = 0;

        while (left < heights.Length)
        {
            int width = 0;
            int i = left;
            while (heights[i] != 0 && i + 1 < heights.Length && heights[left] <= heights[i + 1])
            {
                width = width + 1;
                i++;
            }

            leftDict.Add(left, width);

            left++;
        }

        while (right < heights.Length)
        {
            int width = 0;
            int i = right;
            while (heights[i] != 0 && i - 1 >= 0 && heights[right] <= heights[i - 1])
            {
                width = width + 1;
                i--;
            }

            rightDict.Add(right, width);

            right++;
        }

        for (int i = 0; i < heights.Length; i++)
        {
            currentHeight = (leftDict[i] + rightDict[i] + 1) * heights[i];

            if (currentHeight > maxHeight)
            {
                maxHeight = currentHeight;
            }
        }

        return maxHeight;
    }
  
//--------------------------------Optimized Solution ---------------------------------------------------------------//
    public static int LargestRectangleArea(int[] heights)
    {
        int i = 0;

        Stack<int> stack = new Stack<int>();

        int maxHeight = 0;

        while (i < heights.Length)
        {
            if (!stack.Any() || heights[stack.Peek()] <= heights[i])
            {
                stack.Push(i);
                i++;
            }
            else
            {
                int height = heights[stack.Pop()];
                int width = stack.Count == 0 ? i : i - stack.Peek() - 1;

                maxHeight = Math.Max(maxHeight, height * width);
            }
        }

        while(stack.Count > 0)
        {
            int height = heights[stack.Pop()];
            int width = stack.Count == 0 ? i : i - stack.Peek() - 1;
            maxHeight = Math.Max(maxHeight, height * width);
        }

        return maxHeight;
    }
}
