using System;
using System.Linq;

namespace _01.LargestCommonEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] arr2 = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();

            int leftCount = FindMaxCommonItems(arr1, arr2);
            Array.Reverse(arr1);
            arr2 = arr2.Reverse().ToArray();
            int rightCount = FindMaxCommonItems(arr1, arr2);

            Console.WriteLine($"{Math.Max(leftCount, rightCount)}");
        }

        private static int FindMaxCommonItems(string[] firstArray, string[] secondArray)
        {
            int length = Math.Min(firstArray.Length, secondArray.Length);
            int count = 0;
            for (int i = 0; i < length; i++)
            {
                if (firstArray[i] == secondArray[i])
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            return count;
        }

    }
}