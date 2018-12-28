using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace _03.ArrayContainsElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int wantedNumber = int.Parse(Console.ReadLine());
           
            //SHORTER METHOD
           //if (numbers.Any(n => n == wantedNumber))
           //{
           //    Console.WriteLine("yes");
           //}
           //else
           //{
           //    Console.WriteLine("no");
           //}

            bool contains = false;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == wantedNumber)
                {
                    contains = true;
                    break;
                }
            }
            if (contains)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}