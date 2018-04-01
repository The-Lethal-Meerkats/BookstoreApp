using Autofac;
using Autofac.Integration.Mvc;
using BookstoreApp.API.Identity;
using BookstoreApp.Data.DI;
using BookstoreApp.Models.Accounts;
using BookstoreApp.Services.DI;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace BookstoreApp.API.DI
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.Register(x => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>();
            builder.RegisterType<BookstoreUserStore>().As<IUserStore<BookstoreUser, int>>().InstancePerRequest();
            builder.RegisterType<BookstoreUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<BookstoreSignInManager>().AsSelf().InstancePerRequest();

            //Register modules
            builder.RegisterModule(new AutofacDataModule());
            builder.RegisterModule(new AutofacServiceModule());

            //Register MVC controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}