using System;

namespace _15.NeighbourWars
{
    class Program
    {
        static void Main(string[] args)
        {
            int peshoDamage = int.Parse(Console.ReadLine());
            int goshoDamage = int.Parse(Console.ReadLine());
            int peshoHP = 100;
            int goshoHP = 100;
            int round = 1;

            while (0 < peshoHP && 0 < goshoHP)
            {                
                if (round % 2 != 0)
                {
                    goshoHP = goshoHP - peshoDamage;
                }
                else if (round % 2 == 0)
                {
                    peshoHP = peshoHP - goshoDamage;
                }
                if (peshoHP <= 0 || goshoHP <= 0)
                {
                    break;
                }
                if (round % 2 != 0)
                {
                    Console.WriteLine($"Pesho used Roundhouse kick and reduced Gosho to {goshoHP} health.");
                }
                else if (round % 2 == 0)
                {
                    Console.WriteLine($"Gosho used Thunderous fist and reduced Pesho to {peshoHP} health.");
                }
                if (round % 3 == 0)
                {
                    peshoHP += 10;
                    goshoHP += 10;
                }              
                round++;
            }
            if (peshoHP > 0)
            {
                Console.WriteLine($"Pesho won in {round}th round.");
            }
            else if (goshoHP > 0)
            {
                Console.WriteLine($"Gosho won in {round}th round.");
            }
        }
    }
}