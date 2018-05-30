using System;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            double L = double.Parse(Console.ReadLine());
            double W = double.Parse(Console.ReadLine());
            double A = double.Parse(Console.ReadLine());

            double LCM = L * 100;
            double WCM = W*100;
            double ACM = A * 10;
            double roomArea = LCM * WCM;
            double wardrobeArea = ACM * ACM;
            double benchArea = roomArea / 10;

            double roomAreaCM = roomArea;
            double wardrobeAreaCM = wardrobeArea * 100;
            double benchAreaCM = benchArea;
            double freeSpace = roomAreaCM - wardrobeAreaCM - benchAreaCM;
            double numberOfDancers = 40 + 7000;
            double result = Math.Floor(freeSpace/numberOfDancers);

            Console.WriteLine(result);

        }
    }
}