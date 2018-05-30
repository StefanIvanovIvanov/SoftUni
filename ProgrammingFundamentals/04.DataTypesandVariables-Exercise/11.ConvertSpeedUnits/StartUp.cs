using System;

namespace _11.ConvertSpeedUnits
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int metres = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());

            int timeInSeconds = (hours * 3600) + (minutes * 60) + seconds;
            float timeInHours = (float)timeInSeconds/3600;

            float metresPerSecond = (float)metres / timeInSeconds;
            float kilometres = (float)metres / 1000;
            float miles = (float)metres / 1609;
            float kmPerHour = kilometres / timeInHours;
            float milesPerHour = miles / timeInHours;

            Console.WriteLine(metresPerSecond);
            Console.WriteLine(kmPerHour);
            Console.WriteLine(milesPerHour);
        }
    }
}