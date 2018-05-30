using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _14.CubicArtillery
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());
            int freeCapacity = maxCapacity;
            string intput = Console.ReadLine();
            Queue<string> bunkers = new Queue<string>();
            Queue<int> weapons = new Queue<int>();
            string pattern = @"[A-Za-z]";
            Regex match = new Regex(pattern);
            while (intput != "Bunker Revision")
            {
                string[] tokens = intput.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();

                foreach (string tok in tokens)
                {
                    Match m = match.Match(tok);

                    if (m.Success)
                    {
                        bunkers.Enqueue(tok);
                    }
                    else
                    {
                        int weaponCapacity = int.Parse(tok);

                        bool weaponContained = false;
                        while (bunkers.Count > 1)
                        {
                            if (freeCapacity >= weaponCapacity)
                            {
                                weapons.Enqueue(weaponCapacity);
                                freeCapacity -= weaponCapacity;
                                weaponContained = true;
                                break;
                            }

                            if (weapons.Count == 0)
                            {
                                Console.WriteLine($"{bunkers.Peek()} -> Empty");
                            }
                            else
                            {
                                Console.WriteLine($"{bunkers.Peek()} -> {string.Join(", ", weapons)}");
                            }

                            bunkers.Dequeue();
                            weapons.Clear();
                            freeCapacity = maxCapacity;
                        }
                        if (!weaponContained && bunkers.Count == 1)
                        {
                            if (maxCapacity >= weaponCapacity)
                            {
                                if (freeCapacity < weaponCapacity)
                                {
                                    while (freeCapacity < weaponCapacity)
                                    {
                                        int removedWeapon = weapons.Dequeue();
                                        freeCapacity += removedWeapon;
                                    }
                                }

                                weapons.Enqueue(weaponCapacity);
                                freeCapacity -= weaponCapacity;
                            }
                        }
                    }

                    

                }
                intput = Console.ReadLine();
            }
        }
    }
}
