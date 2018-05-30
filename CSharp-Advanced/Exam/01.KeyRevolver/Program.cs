using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            long pricePerBullet = long.Parse(Console.ReadLine());
            long gunBarrelSize = long.Parse(Console.ReadLine());
            long[] bull = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse).ToArray();
            long[] lo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse).ToArray();

            Stack<long> bullets = new Stack<long>(bull);
            Queue<long> locks = new Queue<long>(lo);

            long valueOflongelligence = long.Parse(Console.ReadLine());
            long currentBarrelSize = gunBarrelSize;

            long numberOfBullets = bull.Length;
            long totalBulletsCost = 0;
            for (long i = 0; i < numberOfBullets; i++)
            {
                long currentBullet = bullets.Pop();
                totalBulletsCost += pricePerBullet;
                if (currentBullet > locks.Peek())
                {
                    currentBarrelSize--;
                    Console.WriteLine("Ping!");
                }
                else
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                    currentBarrelSize--;
                    if (locks.Count == 0)
                    {
                        if (currentBarrelSize == 0&&bullets.Count>0)
                        {
                            Console.WriteLine("Reloading!");
                            currentBarrelSize = gunBarrelSize;
                        }
                        Console.WriteLine($"{bullets.Count} bullets left. Earned ${valueOflongelligence - totalBulletsCost}");
                        return;
                    }                        
                }
                if (currentBarrelSize == 0&&bullets.Count>0)
                {
                    Console.WriteLine("Reloading!");
                    currentBarrelSize = gunBarrelSize;
                }
            }
            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        }
    }
}