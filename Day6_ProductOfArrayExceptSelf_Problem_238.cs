/*
 *Given an integer array nums, return an array answer such that answer[i] is equal to the product of
 *all the elements of nums except nums[i].
 *
 *The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
 *
 *You must write an algorithm that runs in O(n) time and without using the division operation.
 *
 *
 *Example 1:
 *
 *Input: nums = [1,2,3,4]
 *Output: [24,12,8,6]
 *
 *
 *Example 2:
 *
 *Input: nums = [-1,1,0,-3,3]
 *Output: [0,0,9,0,0]
 *
 *
 *Constraints:
 *
 *2 <= nums.length <= 105
 *-30 <= nums[i] <= 30
 *
 *The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
 *
 *
 *Follow up: Can you solve the problem in O(1) extra space complexity? 
 *(The output array does not count as extra space for space complexity analysis.) 
*/

//---------------------------------Solution 1------------------------------------------------//
//--------------------------------Timeout error----------------------------------------------//

public class Solution1
{
    public static int[] ProductExceptSelf(int[] nums)
    {
        int mul = 1;
        List<int> resp = new List<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                if (j == i)
                {
                    continue;
                }
                else
                {
                    mul *= nums[j];
                }
            }
            resp.Add(mul);
            mul = 1;
        }
        return resp.ToArray();
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter ArrayLength: ");
        int numLen = Convert.ToInt32(Console.ReadLine());

        int[] nums = new int[numLen];

        for (int i = 0; i < numLen; i++)
        {
            nums[i] = Convert.ToInt32(Console.ReadLine());
        }

        int[] result = ProductExceptSelf(nums);

        foreach (var res in result)
        {
            Console.WriteLine("Response is : " + res);
        }
    }
}

//---------------------------------Solution 2------------------------------------------------//
//-----------------------------Fixed: Timeout error------------------------------------------//

/* Explaination------------------------------------------------
 num = 1
 nums[] = [2 3 4 5]

 product = 1
    num = 1* 2 = 2
 product = 1, 2
    num = 2 * 3 = 6
 product = 1, 2, 6
    num = 6 * 4 = 24
 product = 1, 2, 6, 24
    num = 24* 5 = 120

====> product = [1, 2, 6, 24]
num = 1;

 product[3] = 24 * 1 = 24
    num = 1 * 5 = 5
 product[2] = 6 * 5 = 30
    num = 5 * 4 = 20
 product[1] = 2 * 20 = 40
    num = 20 * 3 = 60
 product[0] = 1 * 60 = 60
    num = 60 * 2 = 120
 */
public class Solution2
{
    public static int[] ProductExceptSelf(int[] nums)
    {
        int num = 1, i;
        int[] product = new int[nums.Length];

        for(i = 0; i < nums.Length; i++)
        {
            product[i] = num;
            num = num * nums[i];
        }
        num = 1;

        for(i = nums.Length - 1; i>=0; i--)
        {
            product[i] *= num;
            num *= nums[i];
        }

        return product;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter ArrayLength: ");
        int numLen = Convert.ToInt32(Console.ReadLine());

        int[] nums = new int[numLen];

        for (int i = 0; i < numLen; i++)
        {
            nums[i] = Convert.ToInt32(Console.ReadLine());
        }

        int[] result = ProductExceptSelf(nums);

        foreach (var res in result)
        {
            Console.WriteLine("Response is : " + res);
        }
    }
}
