using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace _10.BookLibraryModification
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadLines("input.txt").ToArray();
            int n = int.Parse(input[0]);
            
            List<Book> books = new List<Book>();

            for (int i = 1; i <= n; i++)
            {
                string[] newInput = input[i].Split(new[] {' '}).ToArray();
                books.Add(ReadBook(newInput));
            }

            Library library = new Library {Name = "Library", Books = books};

            DateTime date = DateTime.ParseExact(input[input.Length-1], "d.M.yyyy", CultureInfo.InvariantCulture);

            Dictionary<string, DateTime> booksByDate = new Dictionary<string, DateTime>();

            foreach (Book book in library.Books)
            {
                if (book.ReleaseDate.CompareTo(date) > 0)
                {
                    booksByDate.Add(book.Title, book.ReleaseDate);
                }
            }

            foreach (var pair in booksByDate.OrderBy(x => x.Value).ThenBy(x => x.Key))
            {
                File.AppendAllLines("output.txt", new[] {$"{pair.Key} -> {pair.Value:dd.MM.yyyy}"});
            }
        }

        static Book ReadBook(string[] input)
        {
            string[] tokens = input.ToArray();
            string title = tokens[0];
            string author = tokens[1];
            string publisher = tokens[2];
            DateTime releaseDate = DateTime.ParseExact(tokens[3], "d.M.yyyy", CultureInfo.InvariantCulture);
            string isbn = tokens[4];
            decimal price = decimal.Parse(tokens[5]);

            return new Book
            {
                Title = title,
                Author = author,
                Publisher = publisher,
                ReleaseDate = releaseDate,
                ISBN = isbn,
                Price = price
            };
        }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
    }

    class Library
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}