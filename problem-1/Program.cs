using System;

namespace problem_1
{
        /*If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
            Find the sum of all the multiples of 3 or 5 below 1000. 
            solution: 233168    
        */
    
    public static class IntegerHelper
    {
        public static bool IsMultipleOf(this int number, int multipleOf)
        {
            return number%multipleOf == 0;
        }
    }

    public class Solution
    {
        public int FindSumForRange(int max)
        {
            int sum = 0;

            for(int i =0 ;i< max; i++)
            {
                if(i.IsMultipleOf(3) || i.IsMultipleOf(5)) 
                    sum += i;
            }
            return sum;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int range = 1000;
            var sol = new Solution();
            var sum = sol.FindSumForRange(range);

            Console.WriteLine($"sum of multiples in range 0<x<{range} is: {sum}");
        }
    }
}
