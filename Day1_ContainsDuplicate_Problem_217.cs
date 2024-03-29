/*
 * Given an integer array nums, return true if any value appears at least twice in the array, 
 * and return false if every element is distinct.
 * 
 * Example 1:
 * Input: nums = [1,2,3,1]
 * Output: true
 * 
 * Example 2:
 * Input: nums = [1,2,3,4]
 * Output: false
 * 
 * Example 3:
 * Input: nums = [1,1,1,3,3,4,3,2,4,2]
 * Output: true
 * 
 * Constraints:
 * 
 * 1 <= nums.length <= 105
 * -109 <= nums[i] <= 109
*/

public class Solution {
    public bool ContainsDuplicate(int[] nums)
    {
        HashSet<int> distinctNumbers = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if(distinctNumbers.Contains(nums[i]))
            {
                return true;
            }
            distinctNumbers.Add(nums[i]);
        }
        return false;
    }

    static void Main(string[] args)
    {
        int arrayLength = Convert.ToInt32(Console.ReadLine());

        int[] numArr = new int[arrayLength];

        for (int i = 0; i < arrayLength; i++)
        {
            numArr[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine(ContainsDuplicate(numArr));
    }
}
