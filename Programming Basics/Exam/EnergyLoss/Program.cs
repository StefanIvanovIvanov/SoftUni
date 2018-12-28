using System;

namespace EnergyLoss
{
    class Program
    {
        static void Main(string[] args)
        {
            double days = int.Parse(Console.ReadLine());
            double dancers = int.Parse(Console.ReadLine());

            double totalEnergy = (dancers*days)*100;
            double energyPerDay = 0;
            double totalEnergyDays = 0;
            double energyPerDancer = 0;
            for (int i = 1; i <= days; i++)
            {
                int hours = int.Parse(Console.ReadLine());

                if (i % 2 == 0 && hours % 2 == 0)
                {
                    energyPerDay = dancers * 68;
                }
                else if (i % 2 != 0 && hours % 2 == 0)
                {
                    energyPerDay = dancers * 49;
                }
                else if (i % 2 == 0 && hours % 2 != 0)
                {
                    energyPerDay = dancers * 65;
                }
                else if (i % 2!= 0 && hours % 2 != 0)
                {
                    energyPerDay = dancers * 30;
                }
                totalEnergyDays = totalEnergyDays + energyPerDay;
            }

            totalEnergy = totalEnergy - totalEnergyDays;
            energyPerDancer = totalEnergy / dancers / days;

            if (energyPerDancer > 50)
            {
                Console.WriteLine("They feel good! Energy left: {0:f2}", energyPerDancer);
            }
            else if (50 >= energyPerDancer)
            {
                Console.WriteLine("They are wasted! Energy left: {0:f2}", energyPerDancer);
            }
              

        }
    }
}