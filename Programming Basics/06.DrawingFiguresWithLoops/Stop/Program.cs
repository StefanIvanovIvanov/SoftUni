using System;

namespace Stop
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var dots = n + 1;
            var underlinesFirstLast = 2 * n + 1;
            var underlinesMiddle = 2 * n - 1;
            var left = "//";
            var right = "\\";
            var middleRow = (dots * 2 + underlinesFirstLast - 9) / 2;
            var heigth = 2 * n + 2;

            Console.Write(new string('.', dots));
            Console.Write(new string('_', underlinesFirstLast));
            Console.Write(new string('.', dots));
            Console.WriteLine();
            dots -= 1;
            for (int row = 1; row <= (heigth - 2) / 2; row++)
            {
                Console.Write(new string('.', dots));
                Console.Write(left);
                Console.Write(new string('_', underlinesMiddle));
                Console.Write(right);
                Console.Write(right);
                Console.Write(new string('.', dots));
                Console.WriteLine();
                dots -= 1;
                underlinesMiddle += 2;
            }
            Console.Write(left);
            Console.Write(new string('_', middleRow));
            Console.Write("STOP!");
            Console.Write(new string('_', middleRow));
            Console.Write(right);
            Console.Write(right);
            Console.WriteLine();

            for (int row = 1; row <= (heigth - 2) / 2; row++)
            {
                Console.Write(new string('.', dots));
                Console.Write(right);
                Console.Write(right);
                Console.Write(new string('_', underlinesMiddle));
                Console.Write(left);
                Console.Write(new string('.', dots));
                Console.WriteLine();
                dots += 1;
                underlinesMiddle -= 2;
            }
        }
    }
}