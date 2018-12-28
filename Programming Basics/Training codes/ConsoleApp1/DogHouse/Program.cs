using System;

namespace DogHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            double A = double.Parse(Console.ReadLine());
            double B = double.Parse(Console.ReadLine());

            double heightA = (A/2);
            double side = A * heightA;
            double backSideDownPart = heightA * heightA;
            double triangleH = B - heightA;
            double backSideTriangle = (heightA*triangleH)/ 2;
            double backSide = backSideDownPart + backSideTriangle;
            double door = (A / 5)* (A / 5);
            double frontSide = backSide - door;
            double roofSide = A * heightA;

            double walls = backSide + frontSide + (side * 2);
            double roofTotal = roofSide *2;

            double greenPaint = walls / 3;
            double redPaint = roofTotal / 5;

            Console.WriteLine("{0:f2}", greenPaint);
            Console.WriteLine("{0:f2}", redPaint);


        }
    }
}