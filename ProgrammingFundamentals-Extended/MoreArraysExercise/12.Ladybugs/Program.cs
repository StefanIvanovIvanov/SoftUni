using System;
using System.Linq;

namespace _12.Ladybugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] field = new int[n];
            int[] indexes = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            for (int i = 0; i < field.Length; i++)
            {
                if (indexes.Any(s => s == i))
                {
                    field[i] = 1;
                }
            }

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] arrgs = command.Split().ToArray();
                int index = int.Parse(arrgs[0]);
                string direction = arrgs[1];
                int length = int.Parse(arrgs[2]);


                if (direction == "right")
                {
                    if (index < 0 || index >= field.Length||field[index]!=1)
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    field[index] = 0;
                    while (true)
                    {
                        int newPosition = index + length;
                        if (newPosition >= field.Length)
                        {
                            break;
                        }
                        if (field[newPosition] == 0)
                        {
                            field[newPosition] = 1;
                            break;
                        }
                        length *= 2;
                    }                 
                }
                else if (direction == "left")
                {
                    if (index < 0 || index >= field.Length || field[index] != 1)
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    field[index] = 0;

                    while (true)
                    {
                        int newPostion = index - length;
                        if (newPostion < 0)
                        {
                            break;
                        }
                        if (field[newPostion] == 0)
                        {
                            field[newPostion] = 1;
                            break;
                        }
                        length *= 2;
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", field));
        }
    }
}