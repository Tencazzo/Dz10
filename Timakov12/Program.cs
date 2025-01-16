using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timakov12.Classes;

namespace Timakov12
{
        internal class Program
        {
            static void Main(string[] args)
            {
                //Упражнение 12_1
                var account1 = CreateAccount(12345, 1000m, BankAccountType.Savings);
                var account2 = CreateAccount(12345, 1000m, BankAccountType.Savings);
                var account3 = CreateAccount(67890, 2000m, BankAccountType.Current);

                CompareAccounts(account1, account2);
                CompareAccounts(account1, account3);

                PrintAccountInfo(account1);
                PrintAccountInfo(account2);
                PrintAccountInfo(account3);

                exersize12_2();
                Homework12_1();

                // Домашнее задание 12.2
                BookCollection bookCollection = InitializeBookCollection();
                DisplaySortedBooks(bookCollection);
                SearchBooks(bookCollection);
            }

            static void exersize12_2()
            {
                Rational r1 = new Rational(1, 2);
                Rational r2 = new Rational(3, 4);

                Console.WriteLine($"r1: {r1}");
                Console.WriteLine($"r2: {r2}");

                Rational sum = r1 + r2;
                Console.WriteLine($"Сумма: {sum}");

                Rational difference = r1 - r2;
                Console.WriteLine($"Разность: {difference}");

                Rational product = r1 * r2;
                Console.WriteLine($"Произведение: {product}");

                Rational quotient = r1 / r2;
                Console.WriteLine($"Частное: {quotient}");

                Rational remainder = r1 % r2;
                Console.WriteLine($"Остаток от деления: {remainder}");

                Console.WriteLine($"r1++: {r1++}");
                Console.WriteLine($"--r2: {--r2}");

                float floatValue = (float)r1;
                int intValue = (int)r2;
                Console.WriteLine($"r1 как float: {floatValue}");
                Console.WriteLine($"r2 как int: {intValue}");

                Console.WriteLine($"r1 == r2: {r1 == r2}");
                Console.WriteLine($"r1 < r2: {r1 < r2}");
            }

            static void Homework12_1()
            {
                ComplexNumber c1 = new ComplexNumber(3, 4);
                ComplexNumber c2 = new ComplexNumber(1, 2);

                Console.WriteLine($"Сложение: {c1} + {c2} = {c1 + c2}");
                Console.WriteLine($"Вычитание: {c1} - {c2} = {c1 - c2}");
                Console.WriteLine($"Умножение: {c1} * {c2} = {c1 * c2}");
                Console.WriteLine($"Равенство: {c1} == {c2} => {c1 == c2}");

                ComplexNumber c3 = new ComplexNumber(3, 4);
                Console.WriteLine($"Равенство: {c1} == {c3} => {c1 == c3}");
            }
        //Для Домашнее задание 12.2
        static BookCollection InitializeBookCollection()
            {
                BookCollection bookCollection = new BookCollection();

                bookCollection.AddBook(new Book("Война и мир", "Лев Толстой", "Эксмо", 1869, "978-5-699-10000-0"));
                bookCollection.AddBook(new Book("1984", "Джордж Оруэлл", "АСТ", 1949, "978-5-17-030357-3"));
                bookCollection.AddBook(new Book("Убить пересмешника", "Харпер Ли", "Иностранка", 1960, "978-5-699-10000-0"));
                bookCollection.AddBook(new Book("Гордость и предубеждение", "Джейн Остин", "Азбука", 1813, "978-5-389-10300-0"));

                return bookCollection;
            }

            static void DisplaySortedBooks(BookCollection bookCollection)
            {
                Console.WriteLine("Книги, отсортированные по названию:");
                bookCollection.Sort(CompareByTitle);
                bookCollection.Display();

                Console.WriteLine("\nКниги, отсортированные по автору:");
                bookCollection.Sort(CompareByAuthor);
                bookCollection.Display();

                Console.WriteLine("\nКниги, отсортированные по издательству:");
                bookCollection.Sort(CompareByPublisher);
                bookCollection.Display();
            }

            static void SearchBooks(BookCollection bookCollection)
            {
                Console.WriteLine("\nПоиск книг автора Джордж Оруэлл:");
                var searchResults = bookCollection.SearchByAuthor("Джордж Оруэлл");
                foreach (var book in searchResults)
                {
                    Console.WriteLine(book);
                }

                Console.WriteLine("\nПоиск книг с 'Гордость' в названии:");
                searchResults = bookCollection.SearchByTitle("Гордость");
                foreach (var book in searchResults)
                {
                    Console.WriteLine(book);
                }
            }


            static int CompareByTitle(Book book1, Book book2)
            {
                return string.Compare(book1.Title, book2.Title);
            }

            static int CompareByAuthor(Book book1, Book book2)
            {
                return string.Compare(book1.Author, book2.Author);
            }

            static int CompareByPublisher(Book book1, Book book2)
            {
                return string.Compare(book1.Publisher, book2.Publisher);
            }

        //Для Упражнение 12_1
        private static BankAccount CreateAccount(int accountNumber, decimal initialBalance, BankAccountType accountType)
        {
            return new BankAccount(accountNumber, initialBalance, accountType);
        }

        private static void CompareAccounts(BankAccount account1, BankAccount account2)
        {
            Console.WriteLine($"Сравнение {account1.AccountNumber} и {account2.AccountNumber}: {account1 == account2}");
            Console.WriteLine($"Equals {account1.AccountNumber} и {account2.AccountNumber}: {account1.Equals(account2)}");
        }

        private static void PrintAccountInfo(BankAccount account)
        {
            Console.WriteLine(account);
        }
    
        }
 }
   