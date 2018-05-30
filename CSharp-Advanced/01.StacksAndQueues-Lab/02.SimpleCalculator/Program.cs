using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>(input.Reverse());
            while (stack.Count > 1)
            {
                int left = int.Parse(stack.Pop());
                string operation = stack.Pop();
                int right = int.Parse(stack.Pop());

                if (operation == "+")
                {
                    stack.Push((left + right).ToString());
                }
                else if (operation == "-")
                {
                    stack.Push((left - right).ToString());
                }
            }
            Console.WriteLine(stack.Peek());
        }
    }
}
