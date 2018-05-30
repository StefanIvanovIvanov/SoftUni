using System;
using System.Linq;

namespace _15.LargestCommonEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split().ToArray();
            string[] arr2 = Console.ReadLine().Split().ToArray();

            int min = Math.Min(arr1.Length, arr2.Length);
            int count = 0;
            int higestCount = 0;
            for (int i = 0; i < min; i++)
            {
                if (arr1[i] == arr2[i])
                {
                    count++;
                    if (count > higestCount)
                    {
                        higestCount = count;
                    }
                    else
                    {
                        count = 0;
                    }
                }
            }
            Array.Reverse(arr1);
            Array.Reverse(arr2);
            int countReversed = 0;
            int higestCountReversed = 0;
            for (int i = 0; i < min; i++)
            {
                if (arr1[i] == arr2[i])
                {
                    countReversed++;
                    if (countReversed > higestCountReversed)
                    {
                        higestCountReversed = countReversed;
                    }
                    else
                    {
                        countReversed = 0;
                    }
                }
            }
            int result = Math.Max(higestCount, higestCountReversed);
            Console.WriteLine(result);
        }
    }
}