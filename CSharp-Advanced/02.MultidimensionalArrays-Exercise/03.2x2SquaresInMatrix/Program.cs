using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._2x2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = tokens[0];
            int cols = tokens[1];

            char[,]matrix = new char[rows,cols];

            for (int row = 0; row < rows; row++)
            {
                char[] chars = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = chars[col];
                }
            }
            int counter = 0;
            for (int row = 0; row < rows-1; row++)
            {
                for (int col = 0; col < cols-1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] && matrix[row + 1, col] == matrix[row + 1, col + 1] &&
                        matrix[row, col] == matrix[row + 1, col])
                    {
                        counter++;
                    }
                }
            }
            if (counter > 0)
            {
                Console.WriteLine(counter);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
