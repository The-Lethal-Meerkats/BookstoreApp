namespace BookstoreApp.Migrations
{
    using BookstoreApp.Data;
    using BookstoreApp.Models;
    using BookstoreApp.Models.Accounts;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
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
                this.SeedUsers(context);
                this.SeedBookCategories(context);
                this.SeedBooks(context);
                this.SeedOrders(context);
                this.SeedShoppingCarts(context);
            }
            catch (Exception ex)
            {
                throw ex;
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

            context.SaveChanges();
        }

        private void SeedBooks(BookstoreContext context)
        {
            using (StreamReader reader = new StreamReader(@"D:\Coding\Telerik Academy Alpha\Module III\Databases\Teamwork Assignment\BookstoreApp\bookstore.csv"))
            {
                var client = new HttpClient();
                var Random = new Random();

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
                        decimal price = Random.Next(10,20);

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
                            BookImage = bookImageToAdd,
                            Price = price
                        };

                        context.Books.AddOrUpdate(b => b.Isbn, bookToAdd);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            context.SaveChanges();
        }

        private void SeedUsers(BookstoreContext context)
        {
            #region Users

            var userSofi = new BookstoreUser()
            {
                FirstName = "Sofia",
                LastName = "Kiryakova",
                Email = "sf@kiryakova.me",
                PhoneNumber = "123456",
                PasswordHash = "NeSiPomnqParolata",
                UserAddress = "asd",
                UserName = "sofilofi"
            };

            var userMe = new BookstoreUser()
            {
                FirstName = "Ivan",
                LastName = "Gargov",
                Email = "me@me",
                PhoneNumber = "123456",
                PasswordHash = "112312",
                UserAddress = "asd",
                UserName = "vanchopancho"
            };

            var userNick = new BookstoreUser()
            {
                FirstName = "Nikolay",
                LastName = "Nikolov",
                Email = "you@you",
                PhoneNumber = "123456",
                PasswordHash = "345dsfswe425",
                UserAddress = "asd",
                UserName = "nickpick"
            };
            #endregion

            context.Users.Add(userSofi);
            context.Users.Add(userMe);
            context.Users.Add(userNick);

            context.SaveChanges();
        }

        private void SeedOrders(BookstoreContext context)
        {
            var statusInProgress = new OrderStatus()
            {
                OrderStatusDescription = "InProgress"
            };

            var rand = new Random();
            var entries = context.ChangeTracker.Entries<BookstoreUser>();

            foreach (var entry in entries)
            {
                var books = context.Books
                .OrderBy(b => b.Id)
                .Skip(rand.Next(1, 100))
                .Take(3)
                .ToList();

                var order = new Order()
                {
                    Books = books,
                    OrderCompletedTime = DateTime.Now,
                    ReceivedOrderTime = DateTime.Now,
                    DeliveryAddress = "some address",
                    PhoneNumber = "1234567",
                    User = entry.Entity,
                    OrderStatus = statusInProgress
                };

                context.Orders.Add(order);
            }

            context.SaveChanges();
        }

        private void SeedShoppingCarts(BookstoreContext context)
        {
            var shoppingCartStatus = new ShoppingCartStatus()
            {
                ShoppingCartStatusDescription = "Created"
            };

            var rand = new Random();

            var books = context.Books
                .OrderBy(b => b.Id)
                .Skip(rand.Next(1, 100))
                .Take(5)
                .ToList();

            var user = context.Users.FirstOrDefault();

            var shoppingCart = new ShoppingCart()
            {
                Books = books,
                ShoppingCartStatus = shoppingCartStatus,
                User = user
            };

            context.ShoppingCarts.Add(shoppingCart);
            context.SaveChanges();
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
