using System;

namespace problem_2
{
    public interface ISolution
    {
        int SumOfEvenFibonacci(int limit);
    }

    public class Solution:ISolution
    {
        public int SumOfEvenFibonacci(int limit)
        {
            var start = DateTime.Now;
            int sum = 0;
            int currentTerm = 1;
            int lastTerm = 1;
            while(currentTerm < limit)
            {
                var even = (byte)currentTerm & 0x01;
                if (even == 0)
                    sum += currentTerm;
                int temp = currentTerm;
                currentTerm = currentTerm + lastTerm;
                lastTerm = temp;
            }
            var time = (DateTime.Now - start).Milliseconds;
            Console.WriteLine($"took: {time}ms");
            Console.WriteLine($"Sum {sum}");
            return sum;
        }
    }

    public class Solution2:ISolution
    {
        public int SumOfEvenFibonacci(int limit)
        {
            var start = DateTime.Now;

            int sum = 0;
            int currentTerm = 2;
            var golden3 = 4.236068m;
            while(currentTerm < limit)
            {
                sum += currentTerm;
                currentTerm = (int)Math.Round(currentTerm * golden3);
            }
            var time = (DateTime.Now - start).Milliseconds;
            Console.WriteLine($"took: {time}ms");
            Console.WriteLine($"Sum {sum}");

            return sum;
        }
    }
    

    class Program
    {
        static void Solution()
        {
            var sol = new Solution();
            sol.SumOfEvenFibonacci(4000000);
            
        }

        static void Solution2()
        {
            var sol = new Solution2();
            sol.SumOfEvenFibonacci(4000000);
        }

        static void Main(string[] args)
        {
            Solution();
            Solution2();
        }
    }
}
