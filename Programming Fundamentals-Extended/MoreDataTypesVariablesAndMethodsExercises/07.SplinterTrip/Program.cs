using System;

namespace _07.SplinterTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            double miles = double.Parse(Console.ReadLine());
            double fuelTankCapacity = double.Parse(Console.ReadLine());
            double milesInHeavyWind = double.Parse(Console.ReadLine());

            double milesInCalmWind = miles - milesInHeavyWind;
            double totalFuel = milesInCalmWind * 25 + milesInHeavyWind * 25 * 1.5;
            double totalFuelAmount = totalFuel + (totalFuel * 0.05);

            Console.WriteLine($"Fuel needed: {totalFuelAmount:f2}L");
            if (fuelTankCapacity < totalFuelAmount)
            {
                Console.WriteLine($"We need {Math.Abs(fuelTankCapacity-totalFuelAmount):f2}L more fuel.");
            }
            else
            {
                Console.WriteLine($"Enough with {fuelTankCapacity-totalFuelAmount:f2}L to spare!");
            }

        }
    }
}