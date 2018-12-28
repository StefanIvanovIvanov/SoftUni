using System;

namespace FrameWithStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int rows = n;
            int width = 2 * n;
            int midWidth = width - 2;
            int midMidWidth = (midWidth - 2)/2;

            if (n % 2 == 0)
            {
                rows = n - 1;
            }

            
            Console.Write(new string('%', width));
            Console.WriteLine();
            for (int i = 1; i <= rows; i++)
            {
                if (i == rows / 2 + 1)
                {
                    Console.Write("%");
                    Console.Write(new string(' ', midMidWidth));
                    Console.Write("**");
                    Console.Write(new string(' ', midMidWidth));
                    Console.Write("%");
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("%");
                    Console.Write(new string(' ', midWidth));
                    Console.Write("%");
                    Console.WriteLine();
                }
            }
            Console.Write(new string('%', width));

        }
    }
}