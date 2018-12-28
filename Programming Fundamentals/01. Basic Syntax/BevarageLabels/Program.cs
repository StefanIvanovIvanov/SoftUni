using System;

namespace BevarageLabels
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            double volume = double.Parse(Console.ReadLine());
            double energy = double.Parse(Console.ReadLine());
            double sugar = double.Parse(Console.ReadLine());

            double currentEnergy = energy / 100 * volume;
            double currentSugar = sugar / 100 * volume;

            Console.WriteLine($"{volume}ml {name}:");
            Console.WriteLine($"{currentEnergy}kcal, {currentSugar}g sugars");
        }
    }
}