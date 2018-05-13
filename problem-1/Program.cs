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

    public interface ISolution
    {
        int FindSumForRange(int start, int end, int diff);
    }

    public class Solution: ISolution
    {
        public int FindSumForRange(int start, int end, int diff)
        {
            int sum = 0;

            for(int i =start ;i<= end; i++)
            {
                if(i.IsMultipleOf(diff)) 
                    sum += i;
            }
            return sum;
        }
    }

    public class Solution2:ISolution
    {
        private int FindTerms(int a, int an, int d)
        {
            return (an - a + d) / d;
        }

        private int SumTerms(int n, int a, int d)
        {
            return (n*(2*a + (n-1)*d))/2;
        }

        public int FindSumForRange(int start, int end, int diff)
        {
            var n = FindTerms(start, end, diff);
            var sum = SumTerms(n, start , diff);
            return sum;
        }
    }


    class Program
    {
        static void UseSolution()
        {
            var start = DateTime.Now;
            int range = 1000-1;
            var sol = new Solution();
            var sumOfMultiplesOfThree = sol.FindSumForRange(3, range, 3);
            var sumOfMultiplesOfFive = sol.FindSumForRange(5, range, 5);
            var sumOfMultiplesOfFifteen = sol.FindSumForRange(15, range, 15);
            var time = (DateTime.Now - start).Milliseconds;

            Console.WriteLine($"sum of multiples in range 0<x<{range} is: {sumOfMultiplesOfThree+sumOfMultiplesOfFive - sumOfMultiplesOfFifteen}");
            Console.WriteLine($"took: {time}ms");
        }

        static void UseSolution2()
        {
            var start = DateTime.Now;
            int range = 1000-1;
            ISolution sol = new Solution2();
            var sum = sol.FindSumForRange(3, range, 3);
            var sum2 = sol.FindSumForRange(5, range, 5);
            var sum3 = sol.FindSumForRange(15, range, 15);
            var time = (DateTime.Now - start).Milliseconds;

            Console.WriteLine($"sum of multiples in range 0<x<{range} is: {sum+sum2 - sum3}");
            Console.WriteLine($"took: {time}ms");
        }

        static void Main(string[] args)
        {
            UseSolution2();
            UseSolution();
        }
    }
}
