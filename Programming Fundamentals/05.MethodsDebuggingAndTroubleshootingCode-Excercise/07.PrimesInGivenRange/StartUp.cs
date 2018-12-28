﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.PrimesInGivenRange
{
    class Primes_in_Given_Range
    {
        static void Main()
        {
            int startNumber = int.Parse(Console.ReadLine());
            int stopNumber = int.Parse(Console.ReadLine());
            string numbers = String.Join(", ", GetPrimeNumbers(startNumber, stopNumber).ToArray());
            Console.WriteLine(numbers);
        }


        private static List<int> GetPrimeNumbers(int start, int stop)
        {
            var result = new List<int>();
            for (int i = start; i <= stop; i++)
            {
                bool isPrime = true;
                if (i < 2) isPrime = false;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    result.Add(i);
                }
            }
            return result;
        }
    }
}