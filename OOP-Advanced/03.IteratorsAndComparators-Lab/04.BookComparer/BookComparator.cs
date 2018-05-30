﻿using System.Collections.Generic;
public class BookComparator : IComparer<Book>
{
    public int Compare(Book firstBook, Book secondBook)
    {
        int result = firstBook.Title.CompareTo(secondBook.Title);

        if (result == 0)
        {
            result = secondBook.Year.CompareTo(firstBook.Year);
        }

        return result;
    }
}