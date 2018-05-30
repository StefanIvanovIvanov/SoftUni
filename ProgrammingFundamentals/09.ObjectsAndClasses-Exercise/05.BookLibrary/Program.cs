using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Collections.Specialized;
using System.Globalization;

namespace _05.BookLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Library booksByAutor = new Library();

            List<Book> books = new List<Book>();


            for (int i = 0; i < n; i++)
            {
                books.Add(ReadBook());
            }

            booksByAutor.Books = books;

            Dictionary<string, double> pricePerAutor = AddValuesToDictionary(booksByAutor);

            PrintResults(pricePerAutor);
        }

        static void PrintResults(Dictionary<string, double> pricePerAutor)
        {
            foreach (var autor in pricePerAutor.OrderByDescending(a => a.Value).ThenBy(b => b.Key))
            {
                Console.WriteLine("{0} -> {1:f2}", autor.Key, autor.Value);
            }
        }

        public static Dictionary<string, double> AddValuesToDictionary(Library booksByAutor)
        {
            Dictionary<string, double> pricePerAutor = new Dictionary<string, double>();

            for (int i = 0; i < booksByAutor.Books.Count; i++)
            {
                if (!pricePerAutor.ContainsKey(booksByAutor.Books[i].Author))
                {
                    pricePerAutor.Add(booksByAutor.Books[i].Author, 0);
                }

                pricePerAutor[booksByAutor.Books[i].Author] += booksByAutor.Books[i].Price;
            }

            return pricePerAutor;
        }

        private static Book ReadBook()
        {
            Book book = new Book();
            string[] booksData = Console.ReadLine().Split(' ').ToArray();

            book.Title = booksData[0];
            book.Author = booksData[1];
            book.Publisher = booksData[2];
            book.ReleaseDate = DateTime.ParseExact(booksData[3], "d.M.yyyy", CultureInfo.InvariantCulture);
            book.ISBN = booksData[4];
            book.Price = double.Parse(booksData[5]);

            return book;
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBN { get; set; }
        public double Price { get; set; }
    }

    class Library
    {
        public string Name { get; set; }
        public List<Book> Books {get; set;}
        
    }
}