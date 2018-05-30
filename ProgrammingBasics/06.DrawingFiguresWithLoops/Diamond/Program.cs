using System;

namespace Diamond
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var middle = -1;
            if (n % 2 == 0)
                middle = 0;

            //upper part
            for (int row = 1; row <= (n + 1) / 2; row++)
            {
                var left = (n - 2 - middle)/2;
                Console.Write(new string('-', left));
                Console.Write('*');
                if (middle >= 0)
                {
                    Console.Write(new string('-', middle));
                    Console.Write('*');
                }
                Console.Write(new string('-', left));
                Console.WriteLine();
                middle += 2;
            }
            //lower part
            middle = n - 4;
            for (int row = 1; row < (n + 1) / 2; row++)
            {
                var left = (n - 2 - middle) / 2;
                Console.Write(new string('-', left));
                Console.Write('*');

                if (middle >= 0)
                {
                    Console.Write(new string('-', middle));
                    Console.Write('*');
                }
                Console.Write(new string('-', left));
                Console.WriteLine();
                middle=middle-2;
            }
        
        }
    }

}
