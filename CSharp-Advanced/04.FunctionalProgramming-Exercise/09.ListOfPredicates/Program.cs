using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] divisors = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<int>numbers = new List<int>();
            for (int i = 1; i <=n; i++)
            {
                numbers.Add(i);
            }
            Func<int,bool> predicate = CreatePredicate(divisors);
            numbers = numbers.Where(predicate).ToList();
            string result = string.Join(" ", numbers);
            Console.WriteLine(result);
        }

        private static Func<int, bool> CreatePredicate(int[]divisors)
        {
            return num =>
            {
                foreach (var div in divisors)
                {
                    if (num % div != 0)
                    {
                        return false;
                    }
                }
                return true;
            };
        }
    }
}
