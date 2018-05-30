using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            //finding out the size of each of the 3 arrays in jaggedArray
            int[] sizes = new int[3];

            foreach (var n in input)
            {
                int remainder = Math.Abs(n % 3);
                sizes[remainder]++;
            }
            //creating new arrays for each value of jaggedArray with their representive size
            int[][] jaggedArray = new int[3][];
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                jaggedArray[i]=new int[sizes[i]];
            }

            //filling the values of the array
            int[] index = new int[3];

            foreach (var num in input)
            {
                var newReminder = Math.Abs(num % 3);
                jaggedArray[newReminder][index[newReminder]] = num;
                index[newReminder]++;
            }
            //printing
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
