using System;
using System.Linq;

namespace _02.Icarus
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] planes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int index = int.Parse(Console.ReadLine());
            int damage = 1;
            int rememberIndex = index;

            string input = Console.ReadLine();
            while (input != "Supernova")
            {
                string[] commands = input.Split(new char[] {' '}).ToArray();

                string direction = commands[0];
                int steps = int.Parse(commands[1]);

                if (direction == "left")
                {
                    while (steps --> 0)
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
                else if (direction == "right")
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


                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ",planes));
        }
    }
}