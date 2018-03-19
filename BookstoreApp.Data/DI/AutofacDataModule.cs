using Autofac;
using BookstoreApp.Data.Contracts;

namespace BookstoreApp.Data.DI
{
    public class AutofacDataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookstoreContext>().As<IBookstoreContext>().InstancePerDependency();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerDependency();      
        }
    }
}
