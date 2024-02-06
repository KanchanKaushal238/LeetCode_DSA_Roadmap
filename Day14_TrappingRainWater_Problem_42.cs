
/*
 * Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it can trap after
 * raining.
 * 
 * 
 * Example 1:
 * 
 * Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
 * Output: 6
 * Explanation: The above elevation map (black section) is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. 
 * In this case, 6 units of rain water (blue section) are being trapped.
 * 
 * Example 2:
 * 
 * Input: height = [4,2,0,3,2,5]
 * Output: 9
 *  
 * 
 * Constraints:
 * 
 * n == height.length
 * 1 <= n <= 2 * 104
 * 0 <= height[i] <= 105 
 * 
*/
public class Solution
{
    public static int Trap(int[] height)
    {
        int maxHeight = height.Max();
        int maxHeightIndex = Array.IndexOf(height, maxHeight);

        int currentMax = height[0];
        int fill_amt = 0;
        for (int i = 0; i <= maxHeightIndex; i++)
        {
            fill_amt += Math.Max(0, currentMax - height[i]);
            if(height[i] > currentMax)
            {
                currentMax = height[i];
            }
        }

        currentMax = height[height.Length - 1];
        for(int i = height.Length -1; i >= maxHeightIndex; i--)
        {
            fill_amt += Math.Max(0, currentMax - height[i]);
            if (height[i] > currentMax)
            {
                currentMax = height[i];
            }
        }

        return fill_amt;
    }

    static void Main()
    {
        Console.WriteLine("Enter array length: ");
        int len = Convert.ToInt32(Console.ReadLine());

        int[] height = new int[len];

        for (int i = 0; i < len; i++)
        {
            height[i] = Convert.ToInt32(Console.ReadLine());
        }
        Console.WriteLine("Max Area Is: " + Trap(height));
    }
}
