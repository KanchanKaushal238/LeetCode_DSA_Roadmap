/*
 * You are given an m x n integer matrix matrix with the following two properties:

 * Each row is sorted in non-decreasing order.
 * The first integer of each row is greater than the last integer of the previous row.
 * Given an integer target, return true if target is in matrix or false otherwise.
 * 
 * You must write a solution in O(log(m * n)) time complexity.
 * 
 *  
 * 
 * Example 1:
 * 
 * 
 * Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 3
 * Output: true
 *
 * Example 2:
 * 
 * Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 13
 * Output: false
 *  
 * 
 * Constraints:
 * 
 * m == matrix.length
 * n == matrix[i].length
 * 1 <= m, n <= 100
 * -104 <= matrix[i][j], target <= 104
*/
public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int top = 0;
        int bottom = matrix.GetLength(0)-1;

        while(top <= bottom)
        {
            // for finding row in which number exists
            int middleRow = top + (bottom - top) / 2;

            if(target > matrix[middleRow][matrix[middleRow].Length-1])
            {
                top = middleRow + 1;
            }
            else if(target < matrix[middleRow][0])
            {
                bottom = middleRow - 1;
            }
            else
            {
                // for searching in single column where number may exist
                int left = 0;
                int right = matrix[middleRow].Length - 1;

                while(left <= right)
                {
                    int middle = left + (right - left) / 2;

                    if (target == matrix[middleRow][middle])
                    {
                        return true;
                    }

                    if (target < matrix[middleRow][middle])
                    {
                        right = middle - 1;
                    }
                    else if(target > matrix[middleRow][middle])
                    {
                        left = middle + 1;
                    }
                }
                // returning false if number not found in else case while loop that means number does not exist
                return false;
            }
            
        }
        return false;
    }
}
