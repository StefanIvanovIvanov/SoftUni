using System;

namespace PefectDiamond
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int spacesNumber = n - 1;
            int starNumer = 0;

            for (int i = 1; i <= n; i++)
            {
                Console.Write(new string(' ', spacesNumber));
                Console.Write('*');
                for (int j = 1; j <= starNumer; j++)
                {
                    Console.Write("-*");
                }
                Console.WriteLine();
                spacesNumber--;
                starNumer++;
            }
            spacesNumber += 1;
            for (int i = 1; i <= n - 1; i++)
            {
                starNumer--;
                spacesNumber++;
                Console.Write(new string(' ', spacesNumber));
                Console.Write('*');
                for (int l = starNumer-1; l>=1; l--)
                {
                    Console.Write("-*");
                }
                Console.WriteLine();
                
                
            }




        }
    }
}