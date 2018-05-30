using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Spyfer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split().Select(int.Parse)
                .ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                int sum = 0;

                if (i == 0)
                {
                    sum = numbers[i + 1];
                    if (numbers[i] == sum)
                    {
                        numbers.RemoveAt(i + 1);
                        i = 0;
                    }
                }
                else if (i == numbers.Count - 1)
                {
                    sum = numbers[i - 1];
                    if (numbers[i] == sum)
                    {
                        numbers.RemoveAt(i - 1);
                        i = 0;
                    }
                }
                else
                {
                    sum = numbers[i + 1] + numbers[i - 1];
                    if (numbers[i] == sum)
                    {
                        numbers.RemoveAt(i + 1);
                        numbers.RemoveAt(i - 1);
                        i = 0;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}