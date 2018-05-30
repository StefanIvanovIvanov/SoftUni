using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace _09.BookLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            int n = int.Parse(input[0]);

            Library library = new Library();
            List<Book> books = new List<Book>();
            for (int i = 1; i <= n; i++)
            {
                string[] newInput = input[i].Split(new[] {' '}).ToArray();
                Book book = ReadBook(newInput);
                books.Add(book);
            }
            library.Books = books;
            PrintBooks(library);
        }

        private static void PrintBooks(Library library)
        {
            var ordered = library.Books.GroupBy(x => x.Author)
                                        .Select(g => new
                                        {
                                            Author = g.Key,
                                            Prices = g.Sum(s => s.Price)
                                        })
                                        .OrderByDescending(x => x.Prices)
                                        .ThenBy(x => x.Author)
                                        .ToList();
            foreach (var author in ordered)
            {var result = author.Author+" -> "+author.Prices;
                File.AppendAllLines("output.txt", new[] {result});
            }
        }
        private static Book ReadBook(string [] newInput)
        {
            Book book = new Book();
            string[] bookInfo = newInput.ToArray();
            book.Title = bookInfo[0];
            book.Author = bookInfo[1];
            book.Publisher = bookInfo[2];
            book.ReleaseDate = DateTime.ParseExact(bookInfo[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            book.ISBN = bookInfo[4];
            book.Price = decimal.Parse(bookInfo[5], CultureInfo.InvariantCulture);
            return book;
        }
    }

    class Library
    {
        string Name { get; set; }
        public List<Book> Books { get; set; }
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
}