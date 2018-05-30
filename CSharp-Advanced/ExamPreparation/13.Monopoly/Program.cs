using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] dimentions = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse).ToArray();

            long row = dimentions[0];
            long col = dimentions[1];

            char[,]field=new char[row,col];

            for (long i = 0; i < row; i++)
            {
                char[]input = Console.ReadLine().ToCharArray();
                for (long j = 0; j < col; j++)
                {
                    field[i, j] = input[j];
                }
            }

            long money = 50;
            long turns = 0;
            long stepRow = 0;
            long stepCol = 0;
            long totalHotels = 0;
            long hotelIncome = 10 * totalHotels;
            while (stepRow < row)
            {
                while (stepCol < col&& stepRow < row)
                {
                    if (field[stepRow, stepCol] == 'H')
                    {
                        Console.WriteLine($"Bought a hotel for {money}. Total hotels: {++totalHotels}.");
                        money = 0;
                        turns++;
                        money += 10 * totalHotels;

                    }
                    else if (field[stepRow, stepCol] == 'F')
                    {
                        money += 10 * totalHotels;                       
                        turns++;

                    }
                    else if (field[stepRow, stepCol] == 'J')
                    {
                        Console.WriteLine($"Gone to jail at turn {turns}.");
                        money += 10 * totalHotels;
                        money += 10 * totalHotels;
                        money += 10 * totalHotels;
                        turns++;
                        turns++;
                        turns++;

                    }
                    else if (field[stepRow, stepCol] == 'S')
                    {
                        long product = (stepRow+1) * (stepCol+1);
                        Console.WriteLine($"Spent {product} money at the shop.");
                        money -= product;
                        if (money < 0)
                        {
                            money = 0;
                        }

                        turns++;
                        money += 10 * totalHotels;
                    }
                    stepCol++;
                }
                stepCol--;
                stepRow++;
                while (stepCol >= 0&&stepRow < row)
                {
                    if (field[stepRow, stepCol] == 'H')
                    {
                        Console.WriteLine($"Bought a hotel for {money}. Total hotels: {++totalHotels}.");
                        money = 0;
                        turns++;
                        money += 10 * totalHotels;

                    }
                    else if (field[stepRow, stepCol] == 'F')
                    {
                        money += 10 * totalHotels;
                        turns++;

                    }
                    else if (field[stepRow, stepCol] == 'J')
                    {
                        Console.WriteLine($"Gone to jail at turn {turns}.");
                        money += 10 * totalHotels;
                        money += 10 * totalHotels;
                        money += 10 * totalHotels;
                        turns++;
                        turns++;
                        turns++;

                    }
                    else if (field[stepRow, stepCol] == 'S')
                    {
                        long product = (stepRow + 1) * (stepCol + 1);
                        Console.WriteLine($"Spent {product} money at the shop.");
                        money -= product;
                        if (money < 0)
                        {
                            money = 0;
                        }

                        turns++;
                        money += 10 * totalHotels;
                    }
                    stepCol--;
                }
                stepCol++;
                stepRow++;
            }
            Console.WriteLine($"Turns {turns}");
            Console.WriteLine($"Money {money}");

        }
    }
}
