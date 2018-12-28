using System;

namespace Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int remain = num;
            int num3 = remain % 10;
            remain = remain / 10;
            int num2 = remain % 10;
            remain = remain / 10;
            int num1 = remain % 10;

           // Console.WriteLine("{0}-{1}-{2}", num1, num2,num3);

            int n = num1 + num2;
            int m = num1 + num3;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (num % 5 == 0)
                    {
                        num = num - num1;
                    }
                    else if (num % 3 == 0)
                    {
                        num = num - num2;
                    }
                    else num = num + num3;

                    Console.Write(num+" ");
                }
                Console.WriteLine();
            }
        }
    }
}