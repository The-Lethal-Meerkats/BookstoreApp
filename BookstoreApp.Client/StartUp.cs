using Autofac;
using BookstoreApp.Client.Controllers;
using BookstoreApp.Client.DI;
using BookstoreApp.Data.DI;
using BookstoreApp.Models;
using BookstoreApp.Services.AutoMapper;
using BookstoreApp.Services.DI;
using Newtonsoft.Json;
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
            var shoppingController = container.Resolve<ShoppingCartController>();

            //var addToCart = shoppingController.AddBookToShoppingCart(10, 3);

            var list = shoppingController.ShowUserShoppingCart(3);

            //var place = shoppingController.PlaceOrderFromShoppingCart(3);

        }
    }
}
