/*
 * Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
 * 
 * The overall run time complexity should be O(log (m+n)).
 * 
 *  
 * 
 * Example 1:
 * 
 * Input: nums1 = [1,3], nums2 = [2]
 * Output: 2.00000
 * Explanation: merged array = [1,2,3] and median is 2.
 * 
 * 
 * Example 2:
 * 
 * Input: nums1 = [1,2], nums2 = [3,4]
 * Output: 2.50000
 * Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.
 *  
 * 
 * Constraints:
 * 
 * nums1.length == m
 * nums2.length == n
 * 0 <= m <= 1000
 * 0 <= n <= 1000
 * 1 <= m + n <= 2000
 * -106 <= nums1[i], nums2[i] <= 106
*/

***************************Time Complexity => O(n(1+logn))******************************************************************
public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        List<int> mergedList = new List<int>();
        
        for(int i = 0; i< nums1.Length; i++)
        {
            mergedList.Add(nums1[i]);
        }
        for(int i = 0; i < nums2.Length; i++)
        {
            mergedList.Add(nums2[i]);
        }
        int[] mergedArr = mergedList.ToArray();
        Array.Sort(mergedArr);

        int left = 0, right = mergedArr.Length - 1;
        if(mergedArr.Length % 2 != 0)
        {
            int m = left + (right - left) / 2;
            return mergedArr[m];
        }
        else
        {
            double med1 = mergedArr[left + (right - left) / 2];
            double med2 = mergedArr[(left + (right - left) / 2) + 1];

            return (med1 + med2) / 2;
        }
    }
}
***************************Time Complexity => O(log(m+n))******************************************************************
public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int[] temp;
        // swapping for traversing min array
        if(nums1.Length > nums2.Length)
        {
            temp = nums1;
            nums1 = nums2;
            nums2 = temp;
        }

        int n = nums1.Length, m = nums2.Length;
        int low = 0, high = n;
        while(low <= high)
        {
            // partitionX is half of X
            int partitionX = (low + high) / 2;
            // partitionY is half of total merged ele and minus partitionX
            int partitionY = (n + m + 1) / 2 - partitionX;

            // maxX is 1 less tan last partitionX ele
            int maxX = partitionX == 0 ? int.MinValue : nums1[partitionX - 1];
            // maxX is 1 less tan last partitionY ele
            int maxY = partitionY == 0 ? int.MinValue : nums2[partitionY - 1];
            
            // minX is last partitionX ele
            int minX = partitionX == n ? int.MaxValue : nums1[partitionX];
            // minY is last partitionY ele
            int minY = partitionY == m ? int.MaxValue : nums2[partitionY];

            partitionX ele >= partitionY-1 ele && [artition 
            if(minY >= maxX && minX >= maxY)
            {
                if((m+n)%2 == 0)
                {
                    return (double)(Math.Max(maxX, maxY) + Math.Min(minX, minY)) / 2;
                }
                else
                {
                    return (double)Math.Max(maxX, maxY);
                }
            }
            else if(maxX > minY)
            {
                high = partitionX - 1;
            }
            else
            {
                low = partitionX + 1;
            }
        }

        return (double)0.0;
    }
}
