using System;
using System.Linq;

namespace _06.Icarus
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] planes = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int damage = 1;
            int index = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            while (command != "Supernova")
            {
                string[] arrgs = command.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string direction = arrgs[0];
                int steps = int.Parse(arrgs[1]);

                //right
                if (direction == "right")
                {
                    while (steps-- > 0)
                    {
                        if (index == planes.Length - 1)
                        {
                            index = 0;
                            damage += 1;
                            planes[index] -= damage;                         
                            continue;
                        }
                        index++;
                        planes[index] -= damage;
                    }
                }
                //left
                else if (direction == "left")
                {
                   
                    while (steps-- > 0)
                    {
                        if (index == 0)
                        {
                            index = planes.Length - 1;
                            damage += 1;
                            planes[index] -= damage;
                            continue;
                        }
                        index--;
                        planes[index] -= damage;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", planes));
        }
    }
}