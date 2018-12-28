using System;
using System.Linq;

namespace _07.SumArrays
{
    class Program
    {
        static void Main()
        {
            int[] arr1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] arr2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] biggerArray = new int[Math.Max(arr1.Length, arr2.Length)];
            int sum = Math.Max(arr1.Length, arr2.Length);

            for (int i = 0; i <= biggerArray.Length; i++)
            {
                sum = (arr1[i % arr1.Length] + arr2[i % arr2.Length]);
                if (i >= biggerArray.Length)
                {
                    break;
                }
                Console.Write(sum + " ");
            }
            Console.WriteLine();
        }
    }
}