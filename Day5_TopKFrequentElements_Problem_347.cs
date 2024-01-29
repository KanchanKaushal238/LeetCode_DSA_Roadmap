/*
 *Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.
 *
 *Example 1:
 *
 *Input: nums = [1,1,1,2,2,3], k = 2
 *Output: [1,2]
 *
 *Example 2:
 *
 *Input: nums = [1], k = 1
 *Output: [1]
 *
 *
 *Constraints:
 *1 <= nums.length <= 105
 *-104 <= nums[i] <= 104
 *k is in the range [1, the number of unique elements in the array].
 *
 *It is guaranteed that the answer is unique.
 *
 *Follow up: Your algorithm's time complexity must be better than O(n log n), where n is the array's size. 
*/

public class Solution
{
    public static int[] TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int> calNums = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (calNums.TryGetValue(nums[i], out int temp))
            {
                calNums[nums[i]] = temp+1;
            }
            else
            {
                calNums.Add(nums[i], 1);
            }
        }

        calNums = (from ele in calNums orderby ele.Value descending select ele).Take(k).ToDictionary(x=>x.Key, x=>x.Value);
        
        return calNums.Keys.ToArray();
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter K: ");
        int k = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter ArrayLength: ");
        int numLen = Convert.ToInt32(Console.ReadLine());

        int[] nums = new int[numLen];

        for (int i = 0; i<numLen; i++)
        {
            nums[i] = Convert.ToInt32(Console.ReadLine());
        }

        int[] result = TopKFrequent(nums, k);

        foreach(var res in result)
        {
            Console.WriteLine("Response is : "+ res);
        }
    }
}
