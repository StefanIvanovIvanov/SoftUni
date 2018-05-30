using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int start = numbers[0];
            int end = numbers[1];
            string target = Console.ReadLine().Trim().ToLower();

            Predicate<int> predicate;


            switch (target)
            {
                case "even":
                    predicate = n => n % 2 == 0;
                    break;
                case "odd":
                    predicate = n => n % 2 != 0;
                    break;
                default:
                    predicate = null;
                    break;
            }
            var results = EvensOrOdds(start, end, predicate);
            Console.WriteLine(string.Join(" ", results));
        }

        public static Queue<int> EvensOrOdds(int start, int end, Predicate<int> filter)
        {
            Queue<int> results = new Queue<int>();
            for (int i = start; i <= end; i++)
            {
                if (filter(i))
                {
                    results.Enqueue(i);
                }
            }
            return results;
        }
    }
}