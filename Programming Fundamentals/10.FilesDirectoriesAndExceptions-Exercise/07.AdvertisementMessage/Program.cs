using System;
using System.IO;

namespace _07.AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(File.ReadAllText("input.txt"));
            string[] phrases = { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
            string[] events = { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great" };
            string[] author = {"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"};
            string[] cities = {"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"};

            Random rnd=new Random();

            for (int i = 1; i <= n; i++)
            {
                File.AppendAllText("output.txt", phrases[rnd.Next(0, phrases.Length)] + " " + events[rnd.Next(0, events.Length)] + " " + author[rnd.Next(0, author.Length)] + " - " + cities[rnd.Next(0, cities.Length)]+Environment.NewLine);
            }
        }
    }
}