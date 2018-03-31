using Autofac;
using Autofac.Integration.Mvc;
using BookstoreApp.Data.DI;
using BookstoreApp.Services.DI;
using System.Reflection;
using System.Web.Mvc;

namespace BookstoreApp.API.DI
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            //Register modules
            builder.RegisterModule(new AutofacDataModule());
            builder.RegisterModule(new AutofacServiceModule());

            //Register MVC controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}