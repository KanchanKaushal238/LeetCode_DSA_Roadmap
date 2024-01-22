/*
 *Given an array of integers nums and an integer target, return indices of the two numbers such that they 
 *add up to target.
 *You may assume that each input would have exactly one solution, and you may not use the same element 
 *twice.
 *
 *You can return the answer in any order.
 *
 *Example 1:
 *
 *Input: nums = [2,7,11,15], target = 9
 *Output: [0,1]
 *Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
 *
 *Example 2:
 *Input: nums = [3,2,4], target = 6
 *Output: [1,2]
 *
 *Example 3:
 *Input: nums = [3,3], target = 6
 *Output: [0,1]
 *
 *Constraints:
 *2 <= nums.length <= 104
 *-109 <= nums[i] <= 109
 *-109 <= target <= 109 
*/

public class Solution
{
    public static int[] TwoSum(int[] nums, int target)
    {
        int i = 0;
        int secondNumber = 0;

        int[] resultArr = new int[2];

        while(i < nums.Length)
        {
            secondNumber = target - nums[i];
            for(int j = i+1; j<nums.Length; j++)
            {
                if(nums[j] == secondNumber)
                {
                    resultArr[0] = i;
                    resultArr[1] = j;
                    return resultArr;
                }
            }
            i++;
        }
        return resultArr;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter array length: ");
        int arrLen = Convert.ToInt32(Console.ReadLine());
        int[] nums = new int[arrLen];

        Console.Write("Enter target: ");
        int target = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Array Digits: ");
        for (int j = 0; j < arrLen; j++)
        {
            nums[j] = Convert.ToInt32(Console.ReadLine());
        }

        int[] result = TwoSum(nums, target);

        foreach(int res in result)
        {
            Console.WriteLine(res);
        }
    }
}
