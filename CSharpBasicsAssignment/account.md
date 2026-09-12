leetCode 
https://leetcode.com/problems/single-number/solutions/8518011/singlenumber-by-manar1116-g2up/


        public class Solution 
{
    public int SingleNumber(int[] nums) 
    {
        int result = 0;
        
        foreach (int num in nums) 
        {
            result ^= num; 
        }
        
        return result;
    }
}