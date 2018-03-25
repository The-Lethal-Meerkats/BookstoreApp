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

            var country = new Country()
            {
                CountryName = "Bulgaria"
            };

            var city = new City()
            {
                CityName = "Sofia",
                Country = country
            };

            var userAddress = new UserAddress()
            {
                City = city,
                Street = "asdasd"
            };

            var output = JsonConvert.SerializeObject(userAddress);
            Console.WriteLine(output);
        }
    }
}
