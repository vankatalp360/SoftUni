using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace _5.Book_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            int numbers = int.Parse(Console.ReadLine());
            Library myLibrary = ReadLibrary(numbers, "myLibrary");
            Dictionary<string, double> AutorsTotalPrices = DetermineAutorsTotalPrices(myLibrary);
            foreach(var autor in AutorsTotalPrices.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{autor.Key} -> {autor.Value:f2}");
            }
        }

        private static Dictionary<string, double> DetermineAutorsTotalPrices(Library currentLibrary)
        {
            Dictionary<string, double> totalAutorsTotalPrices = new Dictionary<string, double>();
            List<Book> libraryBooks = currentLibrary.Books;
            foreach(var book in libraryBooks)
            {
                if (!totalAutorsTotalPrices.ContainsKey(book.Author))
                {
                    totalAutorsTotalPrices[book.Author] = 0;
                }
                totalAutorsTotalPrices[book.Author] += book.Price;
            }
            return totalAutorsTotalPrices;
        }

        private static Library ReadLibrary(int number , string name)
        {            
            List<Book> books = new List<Book>();
            for (int i = 1; i <= number;i++)
            {                
                books.Add(ReadBook());
            }            
            Library currentLibrary = new Library();
            currentLibrary.Name = name;
            currentLibrary.Books = books;
            return currentLibrary;
        }

        private static Book ReadBook()
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            Book thisBook = new Book();
            thisBook.Title = input[0];
            thisBook.Author = input[1];
            thisBook.Publisher = input[2];
            thisBook.ReleaseDate = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            thisBook.ISBNNumber = input[4];
            thisBook.Price = double.Parse(input[5]);
            return thisBook;
        }
    }

    class Library
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBNNumber { get; set; }
        public double Price { get; set; }
    }
}
