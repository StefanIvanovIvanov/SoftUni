using System;
using System.Linq;

namespace _17.JumpAround
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int jump = 0;
            int sum = 0;
            bool hasMoved = true;

            while (hasMoved)
            {
                hasMoved = false;
                sum += numbers[jump];
                if (numbers[jump] + jump <= numbers.Length)
                {
                    jump += numbers[jump];
                    hasMoved = true;
                }else if (jump-numbers[jump] >= 0)
                {
                    jump -= numbers[jump];
                    hasMoved = true;
                }
            }
            Console.WriteLine(sum);
        }
    }
}