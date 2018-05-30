using System;

namespace Cup
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = 5 * n;
            
            int hashTagNumber = n * 3;
            int dotsNumer = n;
            int halfN = n / 2;
            int danceLine = (width - 10)/2;
            
            int middleDots = (2 * n) - 2;
            int middleRows= (n / 2) + 1;
           
            for (int i = 1; i <= halfN; i++)
            {
                Console.Write(new string('.', dotsNumer));
                Console.Write(new string('#', hashTagNumber));
                Console.Write(new string('.', dotsNumer));
                Console.WriteLine();
                hashTagNumber -= 2;
                dotsNumer += 1;
            }
            for (int j = 1; j <= middleRows; j++)
            {
                Console.Write(new string('.', dotsNumer));
                Console.Write('#');
                Console.Write(new string('.', middleDots));
                Console.Write('#');
                Console.Write(new string('.', dotsNumer));
                dotsNumer += 1;
                middleDots -= 2;
                Console.WriteLine();
            }
            dotsNumer -= 1;
            Console.Write(new string('.', dotsNumer));
            Console.Write(new string('#', n));
            Console.Write(new string('.', dotsNumer));
            Console.WriteLine();
              dotsNumer -= 2;
               hashTagNumber += 4;
            //here
            int hashTagMiddle = width - (2 * dotsNumer);
            for (int k = 1; k <= halfN; k++)
            {
                Console.Write(new string('.', dotsNumer));
                Console.Write(new string('#', hashTagMiddle));
                Console.Write(new string('.', dotsNumer));
                Console.WriteLine();
            }

            Console.Write(new string('.', danceLine));
            Console.Write("D^A^N^C^E^");
            Console.Write(new string('.', danceLine));
            Console.WriteLine();

            for (int k = 1; k <= halfN+1; k++)
            {
                Console.Write(new string('.', dotsNumer));
                Console.Write(new string('#', hashTagMiddle));
                Console.Write(new string('.', dotsNumer));
                Console.WriteLine();
            }
        }
    }
}