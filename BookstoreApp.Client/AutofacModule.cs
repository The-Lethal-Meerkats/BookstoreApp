using Autofac;
using BookstoreApp.Data;
using BookstoreApp.Services;
using BookstoreApp.Services.Implementation;

namespace BookstoreApp.Client
{
    public class AutofacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookstoreContext>().As<IBookstoreContext>().InstancePerDependency();

            // Registering the Services. For the moment we don't have interfaces. The moment we need to use the interfaces
            // of the services we will need to reconfigure this part.
            builder.RegisterType<BookService>().AsSelf();
           
        }
    }
}
