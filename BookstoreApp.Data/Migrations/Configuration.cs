namespace BookstoreApp.Migrations
{
    using BookstoreApp.Data;
    using BookstoreApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookstoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BookstoreContext context)
        {
            try
            {
                this.SeedBooks(context);
            }
            catch (Exception ex)
            {

            }
        }

        private void SeedBooks(BookstoreContext context)
        {
            var booksToSeed = ReadBooksFromFile();

            foreach (var book in booksToSeed)
            {
                context.Books.AddOrUpdate(b => b.Isbn, book);
            }

            context.SaveChanges();
        }

        private List<Book> ReadBooksFromFile()
        {
            List<Book> books = new List<Book>();

            using (StreamReader reader = new StreamReader(@"D:\Telelrik Academy\Team Projects\BookstoreApp\book30-listing-test.csv"))
            {
                while (!reader.EndOfStream)
                {
                    try
                    {
                        var line = reader.ReadLine().Split(',').ToArray();
                        string author = line[4].Trim();
                        string category = line[6].Trim();
                        string isbn = line[0];
                        string bookName = line[3];
                        string url = line[2];

                        var authorToAdd = new Author()
                        {
                            AuthorName = author
                        };

                        var categoryToAdd = new Category()
                        {
                            CategoryName = category
                        };

                        var bookToAdd = new Book()
                        {
                            BookName = bookName,
                            Isbn = isbn,
                            Author = authorToAdd,
                            Category = categoryToAdd
                        };

                        books.Add(bookToAdd);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return books;
        }
    }
}
