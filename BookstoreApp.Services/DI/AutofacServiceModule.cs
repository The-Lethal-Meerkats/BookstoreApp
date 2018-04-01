using Autofac;
using AutoMapper;
using BookstoreApp.Models.Accounts;
using BookstoreApp.Services.Contracts;

namespace BookstoreApp.Services.DI
{
    public class AutofacServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IBookService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.Register(m => Mapper.Instance);
            builder.RegisterType<BookstoreUserContext>().As<IBookstoreUserContext>().InstancePerRequest();

            base.Load(builder);
        }
    }
}
