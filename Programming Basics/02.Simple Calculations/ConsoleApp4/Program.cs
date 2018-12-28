using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            double nPrice = double.Parse(Console.ReadLine());
            double mPrice = double.Parse(Console.ReadLine());
            int nKG = int.Parse(Console.ReadLine());
            double mKG = int.Parse(Console.ReadLine());

            double nBGN = nPrice * nKG;
            double mBGN = mPrice * mKG;

            double nEUR = nBGN / 1.94;
            double mEUR = mBGN / 1.94;

            double result = nEUR + mEUR;
            Console.WriteLine(Math.Round(result, 2));

        }
    }
}
