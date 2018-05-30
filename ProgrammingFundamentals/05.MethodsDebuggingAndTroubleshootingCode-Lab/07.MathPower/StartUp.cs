using System;

namespace _07.MathPower
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double inputNumber = double.Parse(Console.ReadLine());
            double powerNumber = double.Parse(Console.ReadLine());
            double result = CalculatePower(inputNumber, powerNumber);
            Console.WriteLine(result);
        }

        static double CalculatePower(double number, double power)
        {
           return Math.Pow(number, power);
        }
    }
}