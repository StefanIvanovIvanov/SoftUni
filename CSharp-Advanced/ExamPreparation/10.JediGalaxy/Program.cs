using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _10.JediGalaxy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int galaxyRow = dimentions[0];
            int galaxyCol = dimentions[1];

            int[,] galaxy = new int[galaxyRow, galaxyCol];

            int filler = 0;
            for (int i = 0; i < galaxyRow; i++)
            {
                for (int j = 0; j < galaxyCol; j++)
                {
                    galaxy[i, j] = filler;
                    filler++;
                }
            }
            long score = 0;
            string input = Console.ReadLine();

            while (input != "Let the Force be with you")
            {
                int[] ivoCordinates = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                int ivoRow = ivoCordinates[0];
                int ivoCol = ivoCordinates[1];
                input = Console.ReadLine();
                int[] evilCordinates = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                int evilRow = evilCordinates[0];
                int evilCol = evilCordinates[1];

                while (evilRow >= 0 && evilCol >= 0)
                {
                    if (0 <= evilRow && evilRow < galaxyRow && 0 <= evilCol && evilCol < galaxyCol)
                    {
                        galaxy[evilRow, evilCol] = 0;
                        evilRow--;
                        evilCol--;
                    }
                    else
                    {
                        evilRow--;
                        evilCol--;
                    }
                }

                while (evilRow >= 0 && evilCol >= 0)
                {
                    galaxy[evilRow, evilCol] = 0;
                    evilRow--;
                    evilCol--;
                }

                while (ivoRow >= 0 && ivoCol < galaxyCol)
                {
                    if (0 <= ivoRow && ivoRow < galaxyRow && 0 <= ivoCol && ivoCol < galaxyCol)
                    {
                        score += (uint)galaxy[ivoRow, ivoCol];
                        ivoRow--;
                        ivoCol++;
                    }
                    else
                    {
                        ivoRow--;
                        ivoCol++;
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(score);
        }
    }
}