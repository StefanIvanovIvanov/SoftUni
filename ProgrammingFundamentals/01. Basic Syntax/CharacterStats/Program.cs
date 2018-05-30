using System;

namespace CharacterStats
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            int currentHealth = int.Parse(Console.ReadLine());
            int maxHealth = int.Parse(Console.ReadLine());
            int currentEnergy = int.Parse(Console.ReadLine());
            int maxEnergy = int.Parse(Console.ReadLine());

            int emptyHealth = maxHealth - currentHealth;
            int emptyEnergy = maxEnergy - currentEnergy;

            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Health: |{new string('|', currentHealth)}{new string('.', emptyHealth)}|");
            Console.WriteLine($"Energy: |{new string('|', currentEnergy)}{new string('.', emptyEnergy)}|");

        }
    }
}