/*
 *Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.

 *You must write an algorithm that runs in O(n) time.
 *
 *Example 1:
 *
 *Input: nums = [100,4,200,1,3,2]
 *Output: 4
 *Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.
 *Example 2:
 *
 *Input: nums = [0,3,7,2,5,8,4,6,0,1]
 *Output: 9
 * 
 *
 *Constraints:
 *
 *0 <= nums.length <= 105
 *-109 <= nums[i] <= 109 
 *
*/
public class Solution
{
    public static int LongestConsecutive(int[] nums)
    {
        int maxNum = 1;
        int maxResult = 1;

        if (nums.Count() == 0)
        {
            return 0;
        }
        Dictionary<int, int> dictNum = new Dictionary<int, int>();
        // Used Dictionary to remove duplicates
        foreach (var num in nums)
        {
            if (!dictNum.ContainsKey(num))
            {
                dictNum.Add(num, num);
            }
        };

        nums = dictNum.Select(x => x.Value).ToArray();

        Array.Sort(nums);

        for (int i = 0; i< nums.Length-1; i++)
        {
            if (nums[i] + 1 == nums[i + 1])
            {
                maxNum++;

                if (maxNum > maxResult)
                {
                    maxResult = maxNum;
                }
            }
            else
            {
                maxNum = 1;
            }
        }

        return maxResult;
    }
}
