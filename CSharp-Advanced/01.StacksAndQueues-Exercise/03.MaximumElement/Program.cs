using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int max = 0;
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {

                int[] tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int command = tokens[0];
                if (command == 1)
                {
                    stack.Push(tokens[1]);
                    if (tokens[1] > max)
                    {
                        max = tokens[1];
                    }
                }
                else if (command == 2)
                {
                    int currentElement = stack.Pop();
                    if (currentElement == max && stack.Count > 0)
                    {
                        max = stack.Max();
                    }
                    else if (currentElement == max && stack.Count == 0)
                    {
                        max = 0;
                    }
                }
                else if (command == 3)
                {
                    Console.WriteLine(max);
                }
            }
        }
    }
}
