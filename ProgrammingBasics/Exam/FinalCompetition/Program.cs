using System;

namespace FinalCompetition
{
    class Program
    {
        static void Main(string[] args)
        {
            int dancers = int.Parse(Console.ReadLine());
            double points = double.Parse(Console.ReadLine());
            var season = Console.ReadLine();
            var place = Console.ReadLine();

            double expenses = 0;
            double price = dancers*points;
            
           if (place == "Abroad")
            {
                price = price + (price * 0.50);
            }
            /*
             if (place == "Bulgaria" && season == "summer")
             {
                 expenses = price * 0.05;
             }
             else if (place == "Bulgaria" && season == "winter")
             {
                 expenses = price * 0.08;
             }
             else if (place == "Abroad" && season == "summer")
             {
                 expenses = price * 0.10;
             }
             else if (place == "Abroad" && season == "winter")
             {
                 expenses = price * 0.15;
             }*/

            if (place == "Bulgaria")
            {
                if (season == "summer")
                {
                    expenses = price * 0.05;
                }
                else if (season == "winter")
                {
                    expenses = price * 0.08;
                }
            }
            else if (place == "Abroad")
            {
                if (season == "summer")
                {
                    expenses = price * 0.10;
                }
                else if (season == "winter")
                {
                    expenses = price * 0.15;
                }
            }


                double remain = price - expenses;
            double charity = remain * 0.75;
            double remainingPriceMoney = remain - charity;
            double perPerson = remainingPriceMoney / dancers;

            Console.WriteLine("Charity - {0:f2}", charity);
            Console.WriteLine("Money per dancer - {0:f2}", perPerson);



        }
    }
}