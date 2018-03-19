using Autofac;
using AutoMapper;
using BookstoreApp.Data;
using BookstoreApp.Models;
using BookstoreApp.Services;
using BookstoreApp.Services.ViewModels;
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
            // We initialize the automapper here. 
            // The automapper itself is placed in a separate class following the separation of concerns principle.
            AutomapperConfig.Initialize();

            // Registering Assembly Modules with Autofac
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            var container = builder.Build();

            // We can now resolve all the dependencies for our services.
            // For the moment we only have the BookService one. By resolving it, we will have a new instance of the BookService
            // with all of its dependencies down the line.

            var bookService = container.Resolve<BookService>();

            // FOR TESTING PURPOSES
            var books = bookService.GetAll();
            Console.WriteLine(books.Count());
        }
    }
}
