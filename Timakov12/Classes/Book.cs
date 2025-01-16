using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timakov12.Interfaces;

namespace Timakov12.Classes
{
    public class Book : IBook, IComparable<IBook>
    {
        public string Title { get; }
        public string Author { get; }
        public string Publisher { get; }
        public int Year { get; }
        public string ISBN { get; }

        public Book(string title, string author, string publisher, int year, string isbn)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title), "Title cannot be null.");
            Author = author ?? throw new ArgumentNullException(nameof(author), "Author cannot be null.");
            Publisher = publisher ?? throw new ArgumentNullException(nameof(publisher), "Publisher cannot be null.");
            Year = year;
            ISBN = isbn ?? throw new ArgumentNullException(nameof(isbn), "ISBN cannot be null.");
        }

        public override string ToString()
        {
            return $"{Title} автор: {Author}, издательство: {Publisher}, год: {Year}, ISBN: {ISBN}";
        }

        public int CompareTo(IBook other)
        {
            if (other == null) return 1;

            return string.Compare(Title, other.Title, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (obj is IBook otherBook)
            {
                return ISBN == otherBook.ISBN;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ISBN.GetHashCode();
        }
    }
}
