using System;

namespace _02.PracticeFloatingPointNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //Input:
            //3.141592653589793238
            //1.60217657
            //7.8184261974584555216535342341

            decimal num1 = decimal.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            decimal num3 = decimal.Parse(Console.ReadLine());

            Console.WriteLine(num1);
            Console.WriteLine(num2);
            Console.WriteLine(num3);
        }
    }
}