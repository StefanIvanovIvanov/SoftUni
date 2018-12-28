using System;

namespace Tiles
{
    class Program
    {
        static void Main(string[] args)
        {
            double saving = double.Parse(Console.ReadLine());
            double floorWidth = double.Parse(Console.ReadLine());
            double floorLength = double.Parse(Console.ReadLine());
            double triangleSide = double.Parse(Console.ReadLine());
            double triangleH = double.Parse(Console.ReadLine());
            double pricePerTile = double.Parse(Console.ReadLine());
            double priceForHandyman = double.Parse(Console.ReadLine());

            double roomArea = floorLength * floorWidth;
            double triangleArea = (triangleSide * triangleH) / 2;
            double numberOfTiles = Math.Ceiling((roomArea / triangleArea) + 5);
            double costForTiles = numberOfTiles * pricePerTile;
            double totalCost = costForTiles + priceForHandyman;

            if (saving >= totalCost)
            {
                Console.WriteLine("{0:f2} lv left.", Math.Abs(saving - totalCost));
            }
            else {
                Console.WriteLine("You'll need {0:f2} lv more.", Math.Abs(totalCost-saving));
            }


         
        }
    }
}