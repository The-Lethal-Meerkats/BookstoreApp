using Autofac;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Data.DI;
using BookstoreApp.Services.AutoMapper;
using System;
using System.Linq;
using System.Reflection;
using BookstoreApp.Services.Implementation;

namespace BookstoreApp.Client
{
    class StartUp
    {
        static void Main()
        {
            AutomapperConfig.Initialize();

            var builder = new ContainerBuilder();         
            builder.RegisterModule(new AutofacDataModule());
            var container = builder.Build();
            var unit = container.Resolve<IUnitOfWork>();

            // FOR TESTING PURPOSES
            var books = unit.BookRepository.All();
            Console.WriteLine(books.Count());
        }
    }
}
