leetCode 
https://leetcode.com/problems/single-number/solutions/8518011/singlenumber-by-manar1116-g2up/

```text
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

XOR cancels out duplicate numbers because of its properties. 
When you XOR a number with itself, the result is 0 (e.g., a ^ a = 0).
When you XOR a number with 0, 
the result is the number itself (e.g., a ^ 0 = a).

Input Array 1:  [4, 1, 2, 1, 2]
Single Number:  4

Input Array 2:  [7, 3, 5, 3, 7, 9, 5]
Single Number:  9
```