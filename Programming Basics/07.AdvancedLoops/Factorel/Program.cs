using System;

namespace Factorel
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int total = 1;

            do {
                total = total * n;
                n--;
                }
            while (n > 0);


            Console.Write("n!=");
            Console.WriteLine(total);
        }
    }
}