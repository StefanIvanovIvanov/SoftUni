using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Triple_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> Numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            bool Contains = false;
            for (int a = 0; a < Numbers.Count; a++)
            {
                for (int b = a + 1; b < Numbers.Count;b++)
                {
                    int c = Numbers[a] + Numbers[b];
                    if (Numbers.Contains(c))
                    {
                        Console.WriteLine($"{Numbers[a]} + {Numbers[b]} == {c}");
                        Contains = true;
                    }
                }
            }
            if (!Contains) Console.WriteLine("No");
        }
    }
}