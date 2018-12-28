using System;

namespace Between1And100_While_Break_
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1;
            while (true)
            {
                Console.Write("Enter a number: ");
                n = int.Parse(Console.ReadLine());

                if (1 <= n && n <= 100)
                    break;
                Console.WriteLine("Invalid number!");
            }
            Console.WriteLine("The number is: " + n);
        }
    }
}