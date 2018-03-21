using Autofac;
using BookstoreApp.Client.Controllers;

namespace BookstoreApp.Client.DI
{
    public class AutofacClientModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(BookController).Assembly)
                .Where(t => t.Name.EndsWith("Controller"))
                .AsSelf()
                .InstancePerDependency();

            base.Load(builder); 
        }
    }
}
