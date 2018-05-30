using System;
using System.Linq;

namespace _02.RotateAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rotations = int.Parse(Console.ReadLine());

            int[] sumRotatedNumbers = new int[numbers.Length];

            for (int i = 0; i < rotations; i++)
            {
                int[] rotatedNumbers = new int[numbers.Length];
                rotatedNumbers[0] = numbers[numbers.Length - 1];

                for (int j = 1; j < numbers.Length; j++)
                    rotatedNumbers[j] = numbers[j - 1];

                for (int j = 0; j < numbers.Length; j++)
                    sumRotatedNumbers[j] += rotatedNumbers[j];

                numbers = rotatedNumbers;
            }
            Console.WriteLine(string.Join(" ", sumRotatedNumbers));
        }
    }
}