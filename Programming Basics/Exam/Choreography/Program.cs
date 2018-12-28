using System;

namespace Choreography
{
    class Program
    {
        static void Main(string[] args)
        {
            int steps = int.Parse(Console.ReadLine());
            int dancers = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            
            double stepsPerDay = steps / days;
            double percentPerDay = Math.Ceiling((stepsPerDay / steps) * 100);
            double percentPerDancer = percentPerDay / dancers;

            if (percentPerDay <= 13)
            {
                Console.WriteLine("Yes, they will succeed in that goal! {0:f2}%.", percentPerDancer);
            }
            else if (13 < percentPerDay)
            {
                Console.WriteLine("No, They will not succeed in that goal! Required {0:f2}% steps to be learned per day.", percentPerDancer);
            }
        }
    }
}