using System;
using System.Linq;
using BookShop.Data;
using BookShop;

namespace _01.AgeRestriction
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (var db=new BookShopContext())
            {
                string command = Console.ReadLine();
                string result = GetBooksByAgeRestrictions(db, command);
                Console.WriteLine(result);
            }
        }

        public static string GetBooksByAgeRestrictions(BookShopContext context, string command)
        {
            BookShop.Models.AgeRestriction ageRestriction = (BookShop.Models.AgeRestriction)Enum.Parse(typeof(BookShop.Models.AgeRestriction), command, true);

            var books = context.Books
                .Where(x => x.AgeRestriction == ageRestriction)
                .OrderBy(x => x.Title)
                .Select(t => t.Title)
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }
    }
}
