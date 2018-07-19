using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using BookShop.Models;
using Microsoft.EntityFrameworkCore;

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


                string input = Console.ReadLine();
                string result = GetBooksByAgeRestriction(db, input);
                Console.WriteLine(result);

                result = GetGoldenBooks(db);
                Console.WriteLine(result);

                result = GetBooksByPrice(db);
                Console.WriteLine(result);

                int year = int.Parse(Console.ReadLine());
                result = GetBooksNotRealeasedIn(db, year);
                Console.WriteLine(result);

                input = Console.ReadLine();
                result = GetBooksByCategory(db, input);
                Console.WriteLine(result);

                string date = Console.ReadLine();
                result = GetBooksReleasedBefore(db, date);
                Console.WriteLine(result);

                input = Console.ReadLine();
                result = GetAuthorNamesEndingIn(db, input);
                Console.WriteLine(result);

                input = Console.ReadLine();
                result = GetBookTitlesContaining(db, input);
                Console.WriteLine(result);

                input = Console.ReadLine();
                result = GetBooksByAuthor(db, input);
                Console.WriteLine(result);

                int length = int.Parse(Console.ReadLine());
                int count = CountBooks(db, length);
                Console.WriteLine(count);

                result = CountCopiesByAuthor(db);
                Console.WriteLine(result);

                result = GetTotalProfitByCategory(db);
                Console.WriteLine(result);

                result = GetMostRecentBooks(db);
                Console.WriteLine(result);

                IncreasePrices(db);

                int bookCount = RemoveBooks(db);
                Console.WriteLine(bookCount);

            }
        }

        //01.Age Restriction
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

        //02.Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(c => c.Copies < 5000 && c.EditionType == EditionType.Gold)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        //03.Books By Price
        public static string GetBooksByPrice(BookShopContext context)
        {

            var books = context.Books
                .Where(p => p.Price > 40)
                .OrderByDescending(x => x.Price)
                .Select(x => $"{x.Title} - ${x.Price:F2}")
                .ToArray();


            return String.Join(Environment.NewLine, books);
        }

        //04.Not Released In
        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(x => x.Title)
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        //05.Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var books = context.Books
                .Where(x => x.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
                .Select(t => t.Title)
                .OrderBy(x => x)
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        //06.Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            DateTime inputDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(x => x.ReleaseDate.Value < inputDate)
                .OrderByDescending(x => x.ReleaseDate)
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.Price
                })
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //07.Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorNames = context.Authors
                .Where(a => EF.Functions.Like(a.FirstName, "%" + input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .OrderBy(a => a)
                .ToList();

            return String.Join(Environment.NewLine, authorNames);
        }

        //08.Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => EF.Functions.Like(x.Title, $"%{input}%"))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        //09.Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(l => EF.Functions.Like(l.Author.LastName, $"{input}%"))
                .OrderBy(x => x.BookId)
                .Select(x => $"{x.Title} ({x.Author.FirstName} {x.Author.LastName})")
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        //10.Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .Count();

            return books;
        }

        //11.Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Select(x => new
                {
                    FullName = x.FirstName + " " + x.LastName,
                    TotalCopies = x.Books.Sum(s => s.Copies)
                })
                .OrderByDescending(c => c.TotalCopies)
                .ToArray();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FullName} - {author.TotalCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        //12.Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context.Categories
                .Select(x => new
                {
                    x.Name,
                    TotalProfit = x.CategoryBooks.Sum(s => s.Book.Price * s.Book.Copies)
                })
                .OrderByDescending(x => x.TotalProfit)
                .ThenBy(x => x.Name)
                .ToArray();

            foreach (var catergory in categories)
            {
                sb.AppendLine($"{catergory.Name} ${catergory.TotalProfit:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //13.Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context.Categories
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    x.Name,
                    Books = x.CategoryBooks.Select(s => new
                    {
                        s.Book.Title,
                        s.Book.ReleaseDate
                    })
                        .OrderByDescending(r => r.ReleaseDate)
                        .Take(3)
                        .ToArray()
                })
                .ToArray();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }
            return sb.ToString().TrimEnd();
        }

        //14.Increase Prices
        //Install Z.EntityFramework.Plus.EFCore
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var book in books)
            {
                book.Price += 5m;
            }
        }

        //15.Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200);
            int result = books.Count();

            context.Books.RemoveRange(books);
            context.SaveChanges();

            return result;
        }
    }
}
