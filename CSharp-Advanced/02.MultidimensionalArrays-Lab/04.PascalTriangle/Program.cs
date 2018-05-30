using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long heigth = long.Parse(Console.ReadLine());

            long currentWidth = 1;

            long[][] triangle = new long[heigth][];

            for (int i = 0; i < heigth; i++)
            {
                triangle[i] = new long[currentWidth];
                long[] currentRow = triangle[i];
                currentRow[0] = 1;
                currentRow[currentRow.Length - 1] = 1;
                currentWidth++;
                if (currentRow.Length > 2)
                {
                    for (int widthCounter = 1; widthCounter < currentRow.Length - 1; widthCounter++)
                    {
                        long[] previousRow = triangle[i - 1];
                        long previousRowSum = previousRow[widthCounter] + previousRow[widthCounter - 1];
                        currentRow[widthCounter] = previousRowSum;

                    }
                }
            }
            for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < triangle[i].Length; j++)
                {
                    Console.Write(triangle[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
