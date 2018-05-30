using System;

namespace _05.TemperatureConversion
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double fahrenheit = double.Parse(Console.ReadLine());
            double celsius = Calculate(fahrenheit);
            Console.WriteLine($"{celsius:f2}");
        }

        static double Calculate(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }
    }
}