using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,]matrix = new int[n,n];

            for (int i = 0; i < n; i++)
            {
                int[] rowValues = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rowValues[j];
                }
            }

            int firstSum = 0;
            int secondSum = 0;

            for (int i = 0; i < n; i++)
            {
                firstSum += matrix[i, i];
            }
            int indexer = n - 1;
            for (int i = 0; i < n; i++)
            {
                secondSum += matrix[i, indexer];
                indexer--;
            }

            int result = Math.Abs(firstSum - secondSum);
            
            Console.WriteLine(result);
        }
    }
}
