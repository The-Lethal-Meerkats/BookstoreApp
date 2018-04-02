using Autofac;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Data.Repository;
using BookstoreApp.Data.Repository.Contracts;

namespace BookstoreApp.Data.DI
{
    public class AutofacDataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookstoreContext>()
                .As<IBookstoreContext>()
                .InstancePerRequest();
            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerRequest();

            builder.RegisterGeneric(typeof(GenericRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerRequest();
        }
    }
}
