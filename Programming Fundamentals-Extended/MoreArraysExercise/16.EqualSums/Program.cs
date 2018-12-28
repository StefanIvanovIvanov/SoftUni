using System;
using System.Linq;

namespace _16.EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool indexExists = false;
            int index = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;
                for (int j = 0; j < i; j++)
                {
                    leftSum += numbers[j];
                }
                for (int j = i; j < numbers.Length; j++)
                {if(i!=j)
                    rightSum += numbers[j];
                }
                if (leftSum == rightSum)
                {
                    index = i;
                    indexExists = true;
                }
            }
            if (indexExists)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}