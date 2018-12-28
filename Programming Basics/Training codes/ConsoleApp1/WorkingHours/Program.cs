using System;

namespace WorkingHours
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int workingHours = days * 8;
            int totalWorkingHours = workingHours * workers;

            int result = totalWorkingHours - hours;
            int absResult = Math.Abs(result);
            if (result >= 0)
            {
                Console.WriteLine("{0} hours left", result);
            }
            else
            {
                Console.WriteLine("{0} overtime", absResult);
                Console.WriteLine("Penalties: {0}", days*absResult);
            }

        }
    }
}