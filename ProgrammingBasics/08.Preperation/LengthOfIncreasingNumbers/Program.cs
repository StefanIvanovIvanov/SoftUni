using System;

namespace LengthOfIncreasingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int record = 0;
            int length = 0;
            int largestLength = 0;

            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (record < num)
                {
                    length += 1;
                } else if (record > num)
                {
                    length =1;
                }

                if (length > largestLength)
                {
                    largestLength = length;
                }

                    record = num;
                
            }
            Console.WriteLine(largestLength);
        }
    }
}