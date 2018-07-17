using System;
using System.Linq;

namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                DbInitializer.ResetDatabase(db);


                string command = Console.ReadLine();
                string result = GetBooksByAgeRestriction(db, command);
                Console.WriteLine(result);
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
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
