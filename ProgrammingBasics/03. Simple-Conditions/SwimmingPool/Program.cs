using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingPool
{
    class Program
    {
        static void Main(string[] args)
        {
            double V = int.Parse(Console.ReadLine());
            double P1 = int.Parse(Console.ReadLine());
            double P2 = int.Parse(Console.ReadLine());
            double N = double.Parse(Console.ReadLine());

            double volumeP1 = P1 * N;
            double volumeP2 = P2 * N;
            double totalVolume = volumeP1 + volumeP2;
            double percentageP1 = Math.Truncate(volumeP1 / totalVolume * 100);
            double percentageP2 = Math.Truncate(volumeP2 / totalVolume * 100);
            
            double totalVolumePercentage = Math.Truncate(totalVolume / V * 100);
            double overFlow = Math.Abs(V - totalVolume);

            if (totalVolume <= V)
            {
                Console.WriteLine("The pool is {0}% full. Pipe 1: {1}%. Pipe 2: {2}%.", totalVolumePercentage, percentageP1, percentageP2);
            }
            else
            {
                Console.WriteLine("For {0} hours the pool overflows with {1} liters.", N, overFlow);
            }
        }
    }
}
