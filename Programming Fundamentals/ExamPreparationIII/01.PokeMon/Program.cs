using System;
using System.Numerics;

namespace PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            var pokePowerN = int.Parse(Console.ReadLine());
            var distanceM = int.Parse(Console.ReadLine());
            var exhaustionY = int.Parse(Console.ReadLine());
            var count = 0;
            var halfN = pokePowerN / 2;
            while (pokePowerN >= distanceM)
            {
                if (pokePowerN == halfN && exhaustionY > 0)
                {
                    pokePowerN = pokePowerN / exhaustionY;
                }

                if (pokePowerN - distanceM < 0)
                {
                    break;
                }
                pokePowerN = pokePowerN - distanceM;

                count += 1;
            }
            Console.WriteLine(pokePowerN);
            Console.WriteLine(count);
        }
    }
}