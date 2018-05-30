using System;
using System.Linq;

namespace _06.FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int k = input.Length / 4;
            int[] left = input.Take(k).ToArray();
            int[] middle = input.Skip(k).Take(k * 2).ToArray();
            int[] right = input.Skip(k * 3).ToArray();
            Array.Reverse(left);
            Array.Reverse(right);
            int[] newArray = left.Concat(right).ToArray();
            for (int i = 0; i < middle.Length; i++)
            {
                middle[i] += newArray[i];
            }
            Console.WriteLine(string.Join(" ", middle));
        }
    }
}