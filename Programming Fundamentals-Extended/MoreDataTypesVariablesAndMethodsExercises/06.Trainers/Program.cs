using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal tecnicalSum = 0;
            decimal theoreticalSum = 0;
            decimal practicalSum = 0;
            for (int i = 0; i < n; i++)
            {
                int miles = int.Parse(Console.ReadLine());
                double tons = double.Parse(Console.ReadLine());
                string team = Console.ReadLine();

                int metres = miles * 1600;
                double kg = tons * 1000;

                decimal participantEarnedMoney = (decimal)((kg * 1.5) - (0.7 * metres * 2.5));

                if (team == "Technical")
                {
                    tecnicalSum += participantEarnedMoney;
                }
                else if (team == "Theoretical")
                {
                    theoreticalSum += participantEarnedMoney;
                }
                else if (team == "Practical")
                {
                    practicalSum += participantEarnedMoney;
                }
            }
            decimal biggestAmount = Math.Max(tecnicalSum, Math.Max(theoreticalSum, practicalSum));

            if (tecnicalSum == biggestAmount)
            {
                Console.WriteLine($"The Technical Trainers win with ${biggestAmount:f3}.");
            }
            else if (theoreticalSum == biggestAmount)
            {
                Console.WriteLine($"The Theoretical Trainers win with ${biggestAmount:f3}.");
            }
            else if (practicalSum==biggestAmount)
            {
                Console.WriteLine($"The Practical Trainers win with ${biggestAmount:f3}.");
            }

        }
    }
}