using System;
using System.Collections.Generic;
using System.Linq;

namespace _14.TrackDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] banned = Console.ReadLine().Split().ToArray();
            string input = Console.ReadLine();
            List<string> result = new List<string>();

            while (input != "end")
            {
                result.Add(input);
                for (int i = 0; i < banned.Length; i++)              
                {
                    if (input.Contains(banned[i]))
                    {
                        result.Remove(input);
                    }
                }
                input = Console.ReadLine();
            }
            result.Sort();
            foreach (var song in result)
            {
                Console.WriteLine(song);
            }
        }
    }
}