using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timakov12.Delegated;

namespace Timakov12.Classes
{
    public class BookCollection
    {
        private List<Book> books;

        public BookCollection()
        {
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void Sort(CompareBooks compare)
        {
            books.Sort(new Comparison<Book>(compare));
        }

        public void Display()
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        public List<Book> SearchByAuthor(string author)
        {
            return books.FindAll(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase));
        }

        public List<Book> SearchByTitle(string title)
        {
            return books.FindAll(b => b.Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}
