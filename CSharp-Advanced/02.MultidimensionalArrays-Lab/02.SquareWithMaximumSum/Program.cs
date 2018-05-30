using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int rowSize = tokens[0];
            int colSize = tokens[1];
            int maxSum = 0;
            int maxUpperLeft = 0;
            int maxUpperRight = 0;
            int maxLowerLeft = 0;
            int maxLowerRight = 0;
            int[,] matrix = new int[rowSize, colSize];
            //filling the matrix
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowValue = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowValue[col];
                }
            }

            //summing the values of each square
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] +
                                     matrix[row + 1, col + 1];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxUpperLeft = matrix[row, col];
                        maxUpperRight = matrix[row, col + 1];
                        maxLowerLeft = matrix[row + 1, col];
                        maxLowerRight = matrix[row + 1, col + 1];
                    }
                }
            }

            //printing
            Console.WriteLine($"{maxUpperLeft} {maxUpperRight}");
            Console.WriteLine($"{maxLowerLeft} {maxLowerRight}");
            Console.WriteLine(maxSum);
        }
    }
}
