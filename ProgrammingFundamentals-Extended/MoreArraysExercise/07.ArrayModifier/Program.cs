using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> numbers = Console.ReadLine().Split().Select(long.Parse).ToList();

            string input = null;

            while ((input=Console.ReadLine())!= "end")
            {
                string[] arrgs = input.Split().ToArray();
                string command = arrgs[0];
                if (command == "swap")
                {
                    int index1 = int.Parse(arrgs[1]);
                    int index2 = int.Parse(arrgs[2]);
                    numbers=Swap(numbers, index1, index2);
                }
                else if (command == "multiply")
                {
                    int index1 = int.Parse(arrgs[1]);
                    int index2 = int.Parse(arrgs[2]);
                    numbers = Multiply(numbers, index1, index2);
                }
                else if (command == "decrease")
                {
                    numbers = Decrese(numbers);
                }
            }
            Console.WriteLine(String.Join(", ",numbers));
        }

        static List<long> Swap(List<long> numbers, int index1, int index2)
        {
            long remember = numbers[index2];
            numbers[index2] = numbers[index1];
            numbers[index1] = remember;
            return numbers;
        }

        static List<long> Multiply(List<long> numbers, int index1, int index2)
        {
            numbers[index1] *= numbers[index2];
            return numbers;
        }

        static List<long> Decrese(List<long> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] -= 1;
            }
            return numbers;
        }
    }
}