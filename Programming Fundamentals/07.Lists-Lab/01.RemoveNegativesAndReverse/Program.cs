using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.RemoveNegativesAndReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            List<int> listName = numbers.Split(' ').Select(int.Parse).ToList();

            List<int> result=new List<int>();
            bool checkPositive = true;
            foreach (int remainingNumber in listName)
            {
                if (0 < remainingNumber)
                {
                    result.Add(remainingNumber);
                    checkPositive = false;
                }
            }
            result.Reverse();

            if (checkPositive==false)
            {
                Console.Write(string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}