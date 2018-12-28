using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 биткойн = 1168 лева.
            //1 китайски юан = 0.15 долара.
            //1 долар = 1.76 лева.
            // 1 евро = 1.95 лева.

            double bitCoin = double.Parse(Console.ReadLine());
            double yuan = double.Parse(Console.ReadLine());
            double comission = double.Parse(Console.ReadLine());

            double bitCoinToLeva = bitCoin * 1168;
            double yuanToUSD = yuan * 0.15;
            double USDToBGN = yuanToUSD * 1.76;
            double levaResult = bitCoinToLeva + USDToBGN;
            double eurResult = levaResult / 1.95;
            double percent = comission * 0.01;
            double agencyCommision = eurResult * percent;
            double final = eurResult - agencyCommision;
            Console.WriteLine(final.ToString("F"));

        }
    }
}
