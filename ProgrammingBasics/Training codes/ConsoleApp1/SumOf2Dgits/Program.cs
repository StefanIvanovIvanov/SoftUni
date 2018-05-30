using System;

namespace SumOf2Dgits
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int count = 0;
            int test = 0;
            int i = 0;
            int j = 0;

            for (i = num1; i <= num2; i++)
            {
                for (j = num1; j <= num2; j++)
                {
                    count++;
                    if (i + j == magicNumber)
                    {
                        test++;
                        Console.WriteLine("Combination N:{0} ({1} + {2} = {3})", count, i, j, magicNumber);                   
                       return;
                    } 
                }
            }
            if (test == 0)
                Console.WriteLine("{0} combinations - neither equals {1}", count, magicNumber);
        }
    }
}