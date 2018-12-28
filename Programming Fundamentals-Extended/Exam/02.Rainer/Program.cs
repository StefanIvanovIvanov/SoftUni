using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Rainer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> field = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int index = field[field.Count - 1];
            field.RemoveAt(field.Count - 1);

            int[] remember = new int[field.Count];

            for (int i = 0; i < field.Count; i++)
            {
                remember[i] = field[i];
            }
            bool isWet = false;
            int count = 0;
            while (true)
            {
                for (int i = 0; i < field.Count; i++)
                {
                    field[i] = field[i] - 1;

                    if (field[i] == 0 && index == i)
                    {
                        isWet = true;
                    }                 
                }
                if (isWet)
                {
                    break;
                }
                for (int i = 0; i < field.Count; i++)
                {
                    if (field[i]==0&&i!=index)
                    {
                        field[i] = remember[i];
                    }
                }               
                index = int.Parse(Console.ReadLine());
                count++;
            }
            Console.WriteLine(String.Join(" ", field));
            Console.WriteLine(count);
        }
    }
}