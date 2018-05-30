using System;

namespace _01.RotateArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            string remember = input[input.Length - 1];

            for (int i = input.Length-1; i >=1 ; i--)
            {
                input[i] = input[i - 1];
            }
            input[0] = remember;

            Console.WriteLine(String.Join(" ",input));
        }
    }
}