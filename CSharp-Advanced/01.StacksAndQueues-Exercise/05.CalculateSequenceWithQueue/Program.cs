using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CalculateSequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            Queue<long> queue = new Queue<long>();

            queue.Enqueue(n);
            for (int i = 0, skip = 0; i < 49; i++)
            {
                int remain = i % 3;

                if (remain == 0)
                {
                    n = queue.ToArray().Skip(skip).Take(1).ToArray()[0];
                    queue.Enqueue(n + 1);
                    skip++;
                }
                else if (remain == 1)
                {
                    queue.Enqueue(2 * n + 1);
                }
                else if (remain == 2)
                {
                    queue.Enqueue(n + 2);
                }
            }
            Console.WriteLine(string.Join(" ", queue));
        }
    }
}
