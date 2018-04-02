using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookstoreApp.API.Startup))]
namespace BookstoreApp.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
