/*
 * Given an array of integers nums which is sorted in ascending order, and an integer target, write a function to 
 * search target in nums. If target exists, then return its index. Otherwise, return -1.
 * 
 * You must write an algorithm with O(log n) runtime complexity.
 * 
 *  
 * 
 * Example 1:
 * 
 * Input: nums = [-1,0,3,5,9,12], target = 9
 * Output: 4
 * Explanation: 9 exists in nums and its index is 4
 * 
 * Example 2:
 * 
 * Input: nums = [-1,0,3,5,9,12], target = 2
 * Output: -1
 * 
 * Explanation: 2 does not exist in nums so return -1
 *  
 * 
 * Constraints:
 * 
 * 1 <= nums.length <= 104
 * -104 < nums[i], target < 104
 * All the integers in nums are unique.
 * nums is sorted in ascending order. 
 * 
*/

public class Solution
{
    public static int Search(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        if(nums.Length == 1)
        {
            return nums[0] == target ? 0 : -1;
        }

        while(left <= right)
        {
            int middle = left + (right - left) / 2;

            if(nums[middle] == target)
            {
                return middle;
            }
            if(nums[middle] < target)
            {
                left = middle + 1;
            }
            if(nums[middle] > target)
            {
                right = middle - 1;
            }
        }
        return -1;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter target to search: ");
        int target = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter array length: ");
        int len = Convert.ToInt32(Console.ReadLine());

        int[] nums = new int[len];

        for(int i = 0; i< len; i++)
        {
            nums[i] = Convert.ToInt32(Console.ReadLine());
        }

        int res = Search(nums, target);

        Console.WriteLine("Response is: " + res);
    }
}
