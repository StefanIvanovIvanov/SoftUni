using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace _07.CountNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            input.Sort();
            int count = 1;
            int currentElement = input[0];
            bool isLastElementPrinted = false;
            for (int i = 1; i < input.Count; i++)
            {
                int nextElement = input[i];
                if (currentElement == nextElement)
                {
                    count++;
                    if (i == input.Count - 1)
                    {
                        Console.WriteLine("{0} -> {1}", nextElement, count);
                        isLastElementPrinted = true;
                    }
                }
                else
                {
                    Console.WriteLine("{0} -> {1}", currentElement, count);
                    count = 1;
                }
                currentElement = input[i];
            }
            if (!isLastElementPrinted)
            {
                Console.WriteLine("{0} -> {1}", currentElement, 1);
            }
        }
    }
}