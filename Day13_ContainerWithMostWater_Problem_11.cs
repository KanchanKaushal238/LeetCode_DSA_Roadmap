/*
 *You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) 
 *and (i, height[i]).
 *
 *Find two lines that together with the x-axis form a container, such that the container contains the most water.
 *
 *Return the maximum amount of water a container can store.
 *
 *Notice that you may not slant the container.
 *
 * 
 *
 *Example 1:
 *
 *Input: height = [1,8,6,2,5,4,8,3,7]
 *Output: 49
 *Explanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. In this case, the max area of water (blue section) 
 *the container can contain is 49.
 *
 *Example 2:
 *
 *Input: height = [1,1]
 *Output: 1
 * 
 * 
 *Constraints:
 *
 *n == height.length
 *2 <= n <= 105
 *0 <= height[i] <= 104 
 *
*/

public class Solution
{
    public static int MaxArea(int[] height)
    {
        int initalArea, finalArea = 0;

        int left = 0;
        int right = height.Length - 1;

        while (left < right)
        {
            if (height[left] < height[right])
            {
                initalArea = height[left] * (right - left);

                if (initalArea > finalArea)
                {
                    finalArea = initalArea;
                }

                left++;
            }
            else
            {
                initalArea = height[right] * (right - left);

                if (initalArea > finalArea)
                {
                    finalArea = initalArea;
                }
                right--;
            }
        }

        return finalArea;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter array length: ");
        int len = Convert.ToInt32(Console.ReadLine());

        int[] height = new int[len];
        
        for(int i = 0; i<len; i++)
        {
            height[i] = Convert.ToInt32(Console.ReadLine());
        }
        Console.WriteLine("Max Area Is: " + MaxArea(height));
    }
}
