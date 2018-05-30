using System.Collections;
using System.Collections.Generic;

public class Library : IEnumerable<Book>
{
    public Library(params Book[] books)
    {
        this.Books = new SortedSet<Book>(books, new BookComparator());
    }

    public IReadOnlyCollection<Book> Books { get; private set; }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.Books);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class LibraryIterator : IEnumerator<Book>
    {
        public LibraryIterator(IEnumerable<Book> books)
        {
            this.Books = new List<Book>(books);
            this.Reset();
        }

        public int CurrentIndex { get; private set; }

        public List<Book> Books { get; private set; }

        public bool MoveNext()
        {
            this.CurrentIndex++;

            return this.CurrentIndex < this.Books.Count;
        }

        public void Reset()
        {
            this.CurrentIndex = -1;
        }

        public Book Current => this.Books[this.CurrentIndex];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
        }
    }
}