namespace BookstoreApp.Migrations
{
    using BookstoreApp.Data;
    using BookstoreApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Net.Http;

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
                this.SeedBookCategories(context);
                this.SeedBooks(context);

                context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        private void SeedBookCategories(BookstoreContext context)
        {
            foreach (var item in BookCategories)
            {
                var category = new Category()
                {
                    CategoryName = item
                };

                context.Categories.AddOrUpdate(c => c.CategoryName, category);
            }
        }

        private void SeedBooks(BookstoreContext context)
        {
            var client = new HttpClient();

            using (StreamReader reader = new StreamReader(@"D:\Telerik Academy\TeamProjects\BookstoreApp\bookstore.csv"))
            {
                while (!reader.EndOfStream)
                {
                    try
                    {
                        var line = reader.ReadLine().Split(',').ToArray();
                        string author = line[3].Trim();
                        string category = line[4].Trim();
                        string isbn = line[0];
                        string bookName = line[2];
                        string url = line[1];

                        var image = client.GetByteArrayAsync(url).GetAwaiter().GetResult();

                        var bookImageToAdd = new BookImage()
                        {
                            Image = image
                        };

                        var authorToAdd = new Author()
                        {
                            AuthorName = author
                        };

                        var categoryToAdd = context.Categories
                            .Where(c => c.CategoryName.Equals(category))
                            .First();

                        var bookToAdd = new Book()
                        {
                            Title = bookName,
                            Isbn = isbn,
                            Author = authorToAdd,
                            Category = categoryToAdd,
                            BookImage = bookImageToAdd
                        };

                        context.Books.AddOrUpdate(b => b.Isbn, bookToAdd);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        public static List<string> BookCategories = new List<string>()
        {
            "Arts & Photography",
            "Biographies & Memoirs",
            "Business & Money",
            "Calendars",
            "Children's Books",
            "Christian Books & Bibles",
            "Travel",
            "Test Preparation",
            "Teen & Young Adult",
            "Sports & Outdoors",
            "Self-Help",
            "Science Fiction & Fantasy",
            "Science & Math",
            "Romance",
            "Religion & Spirituality",
            "Reference",
            "Politics & Social Sciences",
            "Parenting & Relationships",
            "Mystery & Thriller & Suspense",
            "Medical Books",
            "Literature & Fiction",
            "Law",
            "Humor & Entertainment",
            "History",
            "Health & Fitness & Dieting",
            "Engineering & Transportation",
            "Crafts & Hobbies & Home",
            "Cookbooks & Food & Wine",
            "Computers & Technology",
            "Comics & Graphic Novels",
        };
    }
}
