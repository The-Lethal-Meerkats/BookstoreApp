using Autofac;
using AutoMapper;
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
                .InstancePerDependency();

            builder.Register(m => Mapper.Instance);

            base.Load(builder);
        }
    }
}
