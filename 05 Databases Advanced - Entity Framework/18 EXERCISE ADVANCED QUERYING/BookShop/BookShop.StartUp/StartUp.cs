namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;
    using BookShop.Models;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using System.Globalization;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            //using (var db = new BookShopContext())
            //{
            //    DbInitializer.ResetDatabase(db);
            //}

            var context = new BookShopContext();

            using (context)
            {

                //--1.Age Restriction

                //string ageRestriction = Console.ReadLine().ToLower();

                //string ageRestrictionTitles = GetBooksByAgeRestriction(context, ageRestriction);

                //Console.WriteLine(ageRestrictionTitles);

                //--2.Golden Books

                //string goldenBooksTitles = GetGoldenBooks(context);

                //Console.WriteLine(goldenBooksTitles);

                ////--3.Books by Price

                //string booksByPriceTitles = GetBooksByPrice(context);

                //Console.WriteLine(booksByPriceTitles);

                //--4.Not Released In

                //int year = int.Parse(Console.ReadLine());

                //string titleBooksNotRealeasedIn = GetBooksNotRealeasedIn(context, year);

                //Console.WriteLine(titleBooksNotRealeasedIn);

                //--5.Book Titles by Category

                //string input = Console.ReadLine();

                //string titleBooksByCategory = GetBooksByCategory(context, input);

                //Console.WriteLine(titleBooksByCategory);

                //--6.Released Before Date

                //string date = Console.ReadLine();

                //string booksReleasedBefore = GetBooksReleasedBefore(context, date);

                //Console.WriteLine(booksReleasedBefore);

                //--7.Author Search

                //string input = Console.ReadLine();

                //string authorNamesEndingIn = GetAuthorNamesEndingIn(context, input);

                //Console.WriteLine(authorNamesEndingIn);

                ////--8.Book Search

                //string input = Console.ReadLine().ToLower();

                //string bookTitlesContaining = GetBookTitlesContaining(context, input);

                //Console.WriteLine(bookTitlesContaining);

                ////--9.Book Search by Author

                //string input = Console.ReadLine().ToLower();

                //string booksByAuthor = GetBooksByAuthor(context, input);

                //Console.WriteLine(booksByAuthor);

                //--10.Count Books

                //int lengthCheck = int.Parse(Console.ReadLine());

                //int countBooks = CountBooks(context, lengthCheck);

                //Console.WriteLine(countBooks);

                //--11.Total Book Copies

                //string countCopiesByAuthor = CountCopiesByAuthor(context);

                //Console.WriteLine(countCopiesByAuthor);

                //--12.Profit by Category

                //string totalProfitByCategory = GetTotalProfitByCategory(context);

                //Console.WriteLine(totalProfitByCategory);

                //--13.Most Recent Books

                //string mostRecentBooks = GetMostRecentBooks(context);

                //Console.WriteLine(mostRecentBooks);

                //--14.Increase Prices

                //IncreasePrices(context);

                //--15.Remove Books

                //int removeBooks = RemoveBooks(context);

                //Console.WriteLine($"{removeBooks} books were deleted");
            }
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            context.RemoveRange(books);

            return context.SaveChanges();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToArray();
            
            foreach(var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                        .Select(c => new
                        {
                            CategoryName = c.Name,
                            categoryBookCount = c.CategoryBooks.Count(),
                            CategoryBooks = c.CategoryBooks
                            .OrderByDescending(x => x.Book.ReleaseDate.Value)
                            .Take(3)
                            .Select(y => new
                            {
                                y.Book.Title,
                                y.Book.ReleaseDate.Value.Year
                            }
                                )
                            .OrderByDescending(x => x.Year)
                        })
                        .OrderBy(x => x.CategoryName)
                        .ToArray();

            //return string.Join(Environment.NewLine, categories.Select(x => $"--{x.CategoryName}" + string.Join(Environment.NewLine, x.CategoryBooks.Select(y => $"{y.Title} ({y.Year})"))));
            return string.Join(Environment.NewLine, categories.Select(x => $"--{x.CategoryName}"+Environment.NewLine+ string.Join(Environment.NewLine, x.CategoryBooks.Select(y => $"{y.Title} ({y.Year})"))));
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
            .Select(c => new
            {
                c.Name,
                Profit = c.CategoryBooks.Sum(x => x.Book.Copies * x.Book.Price)
            })
            .OrderBy(x => x.Name)
            .OrderByDescending(x => x.Profit)
            .ToArray();

            return string.Join(Environment.NewLine, categories.Select(x => x.Name + " $" + x.Profit));
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var books = context.Books
            .Select(b => new
            {
                AuthorName = b.Author.FirstName + " " + b.Author.LastName,
                b.Copies
            })
            .GroupBy(b => b.AuthorName)
            .OrderByDescending(x => x.Sum(y => y.Copies))
            .ToArray();

            return string.Join(Environment.NewLine, books.Select(x => x.Key + " - " + x.Sum(y => y.Copies)));
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var count = context.Books.Where(b => b.Title.Length > lengthCheck).Count();

            return count;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            string pattern = $@"^{input}.*$";
            var books = context.Books
                .Where(b => Regex.Match(b.Author.LastName.ToLower(), pattern).Success)
                .OrderBy(b => b.BookId).Select(b => new
                {
                    b.Title,
                    AuthorName = b.Author.FirstName + " " + b.Author.LastName
                })
            .ToArray();

            return string.Join(Environment.NewLine, books.Select(x => $"{x.Title} ({x.AuthorName})"));
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            string pattern = $@"^.*{input}.*$";
            var titles = context.Books.Where(b => Regex.Match(b.Title.ToLower(), pattern).Success).Select(b => b.Title).OrderBy(x => x).ToArray();

            return string.Join(Environment.NewLine, titles);
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            string pattern = $@"\b.*{input}\b";
            var titles = context.Books.Where(b => Regex.Match(b.Author.FirstName, pattern).Success).Select(b => b.Author.FirstName + " " + b.Author.LastName).OrderBy(x => x).ToHashSet();

            return string.Join(Environment.NewLine, titles);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string input)
        {
            string format = "dd-MM-yyyy";
            DateTime date = DateTime.ParseExact(input, format, CultureInfo.InvariantCulture);

            var books = context.Books.Where(b => b.ReleaseDate != null && b.ReleaseDate.Value < date).OrderByDescending(b => b.ReleaseDate.Value).Select(b => new
            {
                b.Title,
                b.EditionType,
                b.Price
            }).ToArray();

            return string.Join(Environment.NewLine, books.Select(x => $"{x.Title} - {x.EditionType} - ${x.Price:F2}"));
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToLower()).ToArray();

            var titles = context.Books.Where(b => b.BookCategories.Select(c => c.Category.Name.ToLower()).Intersect(categories).Any()).OrderBy(b => b.Title).Select(b => b.Title).ToArray();

            return string.Join(Environment.NewLine, titles);
        }

        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {
            var titles = context.Books.Where(b => b.ReleaseDate != null && b.ReleaseDate.Value.Year != year).OrderBy(b => b.BookId).Select(b => b.Title).ToArray();

            return string.Join(Environment.NewLine, titles);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var titles = context.Books.Where(b => b.Price > 40).OrderByDescending(b => b.Price).Select(b => new
            {
                Title = b.Title,
                Price = b.Price
            }
            ).ToArray();

            return string.Join(Environment.NewLine, titles.Select(x => $"{x.Title} - ${x.Price:F2}"));
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var titles = context.Books.Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000).OrderBy(b => b.BookId).Select(b => b.Title).ToArray();

            return string.Join(Environment.NewLine, titles);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string ageRestriction)
        {
            int enumValue;
            switch (ageRestriction)
            {
                case "minor":
                    enumValue = 0;
                    break;
                case "teen":
                    enumValue = 1;
                    break;
                case "adult":
                    enumValue = 2;
                    break;
                default:
                    enumValue = -1;
                    break;
            }
            var titles = context.Books.Where(b => b.AgeRestriction == (AgeRestriction)enumValue).Select(b => b.Title).OrderBy(x => x).ToArray();

            return string.Join(Environment.NewLine, titles);
        }
    }
}
