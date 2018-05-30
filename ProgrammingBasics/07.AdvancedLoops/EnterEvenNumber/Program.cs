using System;

namespace EnterEvenNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1;
            
                while (true)
                {
                try
                {
                    
                    Console.Write("Enter even number: ");
                    n = int.Parse(Console.ReadLine());
                    if (n % 2 == 0)
                    {
                        break;
                    }
                    Console.WriteLine("The number is not even.");
                }
                catch
                {
                    Console.WriteLine("Invalid number!");
                }
            }
            
           
            if (n%2==0)
            Console.WriteLine("You have entered: " + n);
        }
    }
}