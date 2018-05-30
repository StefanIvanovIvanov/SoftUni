using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = tokens[0];
            int cols = tokens[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowValue = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowValue[col];
                }
            }

            int maxSum = 0;
            int firstNum = 0;
            int secondNum = 0;
            int thirdNum = 0;
            int fourthNum = 0;
            int fifthNum = 0;
            int sixthNum = 0;
            int seventhNum = 0;
            int eigthNum = 0;
            int ninthNum = 0;

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col+1] + matrix[row, col+2] + matrix[row+1, col] +
                              matrix[row+1, col+1] + matrix[row+1, col+2] + matrix[row+2, col] + matrix[row+2, col+1] +
                              matrix[row+2, col+2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                         firstNum = matrix[row, col];
                         secondNum = matrix[row, col + 1];
                         thirdNum = matrix[row, col + 2];
                         fourthNum = matrix[row + 1, col];
                         fifthNum = matrix[row + 1, col + 1];
                         sixthNum = matrix[row + 1, col + 2];
                         seventhNum = matrix[row + 2, col];
                         eigthNum = matrix[row + 2, col + 1];
                         ninthNum = matrix[row + 2, col + 2];
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{firstNum} {secondNum} {thirdNum}");
            Console.WriteLine($"{fourthNum} {fifthNum} {sixthNum}");
            Console.WriteLine($"{seventhNum} {eigthNum} {ninthNum}");
        }
    }
}
