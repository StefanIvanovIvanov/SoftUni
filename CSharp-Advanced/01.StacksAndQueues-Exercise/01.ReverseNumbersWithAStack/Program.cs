using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ReverseNumbersWithAStack
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(input);
            if (stack.Count > 0)
            {
                if (stack.Count > 0)
                {
                    while (stack.Count > 1)
                    {
                        Console.Write(stack.Pop() + " ");
                    }
                    Console.WriteLine(stack.Pop());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
