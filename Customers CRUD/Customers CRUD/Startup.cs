using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Customers_CRUD.Startup))]
namespace Customers_CRUD
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
