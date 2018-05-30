using System;
using System.Linq;

namespace _08.Wormhole
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] wormholes = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int index = 0;
            int count = 0;

            while (index<wormholes.Length)
            {
                if (wormholes[index] == 0)
                {
                    count++;
                    index++;
                }
                else
                {
                    int remember = wormholes[index];
                    wormholes[index]=0;
                    index=remember;
                }
            }
            Console.WriteLine(count);
        }
    }
}