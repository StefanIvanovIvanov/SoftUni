using System;

namespace _13.GameOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int nMagic = 0;
            int mMagic = 0;
            int turn = 0;
            int count = 0;

            for (int i = n; i <=m; i++)
            {
                for (int j = n; j <= m; j++)
                {
                    if (i + j == magicNumber)
                    {
                        nMagic = i;
                        mMagic = j;
                        count++;
                    }
                    turn++;
                }
                
            }
            if (count != 0)
            {
                Console.WriteLine($"Number found! {nMagic} + {mMagic} = {magicNumber}");
            }
            else
                Console.WriteLine($"{turn} combinations - neither equals {magicNumber}");
        }
    }
}