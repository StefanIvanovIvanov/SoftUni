using System;

namespace PrimeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var prime = true;

            if(n==1||n==0||n<0)
                Console.WriteLine("Not Prime");
            else { 

            for (int i = 2; i <= n-1; i++)
            {
                if (n % i == 0)
                {
                    prime = false;
                    break;
                }
            }
                if (prime)
                {
                    Console.WriteLine("Prime");
                }
                else Console.WriteLine("Not Prime");
            }



        }
    }
}