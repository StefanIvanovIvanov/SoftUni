using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> stations = new Queue<string>();
            int index = 0;
            bool willReach = false;
            for (int i = 0; i < n; i++)
            {
                stations.Enqueue(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                long petrol = 0;
                foreach (string pair in stations)
                {
        
                    petrol += pair.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray()[0];
                    petrol -= pair.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray()[1];

                    if (petrol < 0)
                    {
                        willReach = false;
                        break;
                    }
                    else
                    {
                        willReach = true;
                    }
                }
                if (willReach)
                {
                    Console.WriteLine(i);
                    return;
                }
                string looper = stations.Dequeue();
                stations.Enqueue(looper);
            }
        }
    }
}
