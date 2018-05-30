using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rowsLength = tokens[0];
            int colLength = tokens[1];

            int[,]matrix=new int[rowsLength,colLength];
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[]colValues= Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colValues[col];
                   // sum += matrix[row, col];
                }
            }
            foreach (var pair in matrix)
            {
                sum += pair;
            }
            Console.WriteLine(rowsLength);
            Console.WriteLine(colLength);
            Console.WriteLine(sum);
        }
    }
}
