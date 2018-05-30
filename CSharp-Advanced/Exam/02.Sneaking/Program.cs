using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[] col = Console.ReadLine().ToCharArray();
            char[,] matrix = new char[n, col.Length];

            int samRow = 0;
            int SamCol = 0;


            for (int i = 0; i < n; i++)
            {
                if (i > 0)
                {
                    col = Console.ReadLine().ToCharArray();
                }
                for (int j = 0; j < col.Length; j++)
                {
                    matrix[i, j] = col[j];
                    if (col[j] == 'S')
                    {
                        samRow = i;
                        SamCol = j;
                    }

                }
            }
            char[] directions = Console.ReadLine().ToCharArray();
            int rows = n;
            int collums = col.Length;


            int turns = 1;
            for (int i = 0; i < directions.Length; i++)
            {
                //enemies movement
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < collums; c++)
                    {
                        int currentCol = c;
                        if (matrix[r, c] == 'd'&&c==0)
                        {
                           
                                matrix[r, c] = 'b';
                            break;

                        }else if (matrix[r, c] == 'd')
                        {
                            matrix[r, c - 1] = 'd';
                            matrix[r, c] = '.';
                            break;
                        }
                        else if (matrix[r, c] == 'b'&& c == collums - 1)
                        {
                            matrix[r, c] = 'd';
                            break;

                        }
                        else if (matrix[r, c] == 'b')
                        {
                                matrix[r, c + 1] = 'b';
                                matrix[r, c] = '.';
                            break;
                        }
                    }
                }
                //check if sam is dead

                for (int j = 0; j < SamCol; j++)
                {
                    if (matrix[samRow, j] == 'b')
                    {
                        matrix[samRow, SamCol] = 'X';
                        Console.WriteLine($"Sam died at {samRow}, {SamCol}");
                        PrintMatrix(matrix, rows, collums);
                        return;
                    }
                }

                for (int j = SamCol + 1; j < collums; j++)
                {
                    if (matrix[samRow, j] == 'd')
                    {
                        matrix[samRow, SamCol] = 'X';
                        Console.WriteLine($"Sam died at {samRow}, {SamCol}");
                        PrintMatrix(matrix, rows, collums);
                        return;
                    }
                }



                //sam movement
                if (directions[i] == 'U')
                {
                    if (matrix[samRow - 1, SamCol] == '.' || matrix[samRow - 1, SamCol] == 'd' || matrix[samRow - 1, SamCol] == 'b')
                    {
                        matrix[samRow - 1, SamCol] = 'S';
                        matrix[samRow, SamCol] = '.';
                        samRow = samRow - 1;
                    }
                }
                else if (directions[i] == 'D')
                {
                    if (matrix[samRow + 1, SamCol] == '.' || matrix[samRow + 1, SamCol] == 'd' || matrix[samRow + 1, SamCol] == 'b')
                    {
                        matrix[samRow + 1, SamCol] = 'S';
                        matrix[samRow, SamCol] = '.';
                        samRow = samRow + 1;
                    }
                }
                else if (directions[i] == 'R')
                {
                    matrix[samRow, SamCol + 1] = 'S';
                    matrix[samRow, SamCol] = '.';
                    SamCol = SamCol + 1;
                }
                else if (directions[i] == 'L')
                {
                    matrix[samRow, SamCol - 1] = 'S';
                    matrix[samRow, SamCol] = '.';
                    SamCol = SamCol - 1;
                }


                //check Nikoldaze
                for (int j = 0; j < collums; j++)
                {
                    if (matrix[samRow, j] == 'N')
                    {
                        matrix[samRow, j] = 'X';
                        Console.WriteLine("Nikoladze killed!");
                        PrintMatrix(matrix, rows, collums);
                        return;
                    }
                }
              // Console.WriteLine(turns++);
              // PrintMatrix(matrix, rows, collums);
              // Console.WriteLine();
            }
        }

        //print the matrix
        public static void PrintMatrix(char[,] matrix, int rows, int collums)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < collums; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}