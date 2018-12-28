using System;
using System.Linq;

class Program
{
    static void Main()
    {

        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] condensed = new int[arr.Length - 1];

        if (arr.Length == 1)
        {
            Console.WriteLine(arr[0]);
            return;
        }

        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < condensed.Length - i; j++)
            {
                condensed[j] = arr[j] + arr[j + 1];
            }
            arr = condensed;
        }
        Console.WriteLine(condensed[0]);
    }
}