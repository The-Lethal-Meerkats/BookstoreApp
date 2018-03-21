using Autofac;
using BookstoreApp.Client.Controllers;
using BookstoreApp.Client.DI;
using BookstoreApp.Data.DI;
using BookstoreApp.Services.AutoMapper;
using BookstoreApp.Services.DI;
using System;

namespace BookstoreApp.Client
{
    class StartUp
    {
        static void Main()
        {
            AutomapperConfig.Initialize();

            var builder = new ContainerBuilder();         
            builder.RegisterModule(new AutofacDataModule());
            builder.RegisterModule(new AutofacClientModule());
            builder.RegisterModule(new AutofacServiceModule());

            var container = builder.Build();
            var bookController = container.Resolve<BookController>();

            var books = bookController.GetAllBooks();

            foreach (var item in books)
            {
                Console.WriteLine($"Author: {item.Author}\nISBN: {item.ISBN}\nTitle: {item.Title}\n\n");
            }
        }
    }
}
